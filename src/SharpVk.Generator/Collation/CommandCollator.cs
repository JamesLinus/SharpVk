﻿using Microsoft.Extensions.DependencyInjection;
using SharpVk.Generator.Pipeline;
using SharpVk.Generator.Specification.Elements;
using System.Collections.Generic;
using System.Linq;

namespace SharpVk.Generator.Collation
{
    public class CommandCollator
        : IWorker
    {
        private readonly IEnumerable<CommandElement> commands;
        private readonly NameFormatter nameFormatter;
        private readonly Dictionary<string, TypeElement> typeData;

        public CommandCollator(IEnumerable<CommandElement> commands, NameFormatter nameFormatter, IEnumerable<TypeElement> types)
        {
            this.commands = commands;
            this.nameFormatter = nameFormatter;
            this.typeData = types.ToDictionary(x => x.VkName);
        }

        public void Execute(IServiceCollection services)
        {
            var associatedHandles = new Dictionary<string, string>();

            foreach (var command in this.commands)
            {
                if (command.Verb == "create")
                {
                    var handle = typeData[command.Params.Last().Type];

                    string associatedHandleName = command.Params.First().Type;

                    if (typeData[associatedHandleName].Category == TypeCategory.handle
                            && handle.Parent != associatedHandleName)
                    {
                        associatedHandles[handle.VkName] = associatedHandleName;
                    }
                }
            }

            foreach (var command in this.commands)
            {
                bool IsHandle(ParamElement param)
                {
                    return typeData[param.Type].Category == TypeCategory.handle;
                }

                var handleParams = command.Params.TakeWhile((x, index) =>
                {
                    if (!IsHandle(x))
                    {
                        return false;
                    }
                    else if (index == 0)
                    {
                        return true;
                    }
                    else if(x.IsOptional && command.Verb == "create")
                    {
                        return false;
                    }
                    else
                    {
                        var paramHandle = typeData[x.Type];
                        var previousParamHandle = typeData[command.Params[index - 1].Type];
                        associatedHandles.TryGetValue(x.Type, out string associatedHandle);

                        return previousParamHandle.VkName == paramHandle.Parent || previousParamHandle.VkName == associatedHandle;
                    }
                }).ToArray();

                var handleTypeName = handleParams.Any()
                                        ? handleParams.Last().Type
                                        : IsHandle(command.Params.Last())
                                            ? command.Params.Last().Type
                                            : "VkInstance";
                
                services.AddSingleton(new CommandDeclaration
                {
                    VkName = command.VkName,
                    Name = this.nameFormatter.FormatName(command, typeData[handleTypeName]),
                    Verb = command.Verb,
                    Extension = command.Extension,
                    HandleTypeName = handleTypeName,
                    HandleParamsCount = handleParams.Length,
                    ReturnType = command.Type,
                    Params = command.Params.Select(x => new ParamDeclaration
                    {
                        VkName = x.VkName,
                        Name = this.nameFormatter.FormatName(x, true),
                        Type = new TypeReference
                        {
                            VkName = x.Type,
                            PointerType = x.PointerType,
                            FixedLength = x.FixedLength
                        },
                        Dimensions = x.Dimensions,
                        IsOptional = x.IsOptional,
                        NoAutoValidity = x.NoAutoValidity
                    }).ToList()
                });
            }
        }
    }
}
