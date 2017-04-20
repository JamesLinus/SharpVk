﻿using SharpVk.Emit;
using SharpVk.Generator.Generation;
using SharpVk.Generator.Pipeline;
using System.Collections.Generic;
using System.Linq;

using static SharpVk.Emit.AccessModifier;
using static SharpVk.Emit.ExpressionBuilder;

namespace SharpVk.Generator.Emission
{
    class HandleEmitter
        : IOutputWorker
    {
        private readonly IEnumerable<HandleDefinition> handles;
        private readonly FileBuilderFactory builderFactory;

        public HandleEmitter(IEnumerable<HandleDefinition> handles, FileBuilderFactory builderFactory)
        {
            this.handles = handles;
            this.builderFactory = builderFactory;
        }

        public void Execute()
        {
            foreach (var handle in this.handles)
            {
                string path = null;
                string @namespace = "SharpVk";

                string interopPath = "Interop";
                string interopNamespace = "SharpVk.Interop";

                if (handle.Namespace?.Any() ?? false)
                {
                    path = string.Join("\\", handle.Namespace);
                    @namespace += "." + string.Join(".", handle.Namespace);

                    interopPath += "\\" + string.Join("\\", handle.Namespace);
                    interopNamespace += "." + string.Join(".", handle.Namespace);
                }

                string rawType = handle.IsDispatch ? "UIntPtr" : "ulong";

                this.builderFactory.Generate(handle.Name, interopPath, fileBuilder =>
                {
                    fileBuilder.EmitUsing("System");

                    fileBuilder.EmitNamespace(interopNamespace, namespaceBuilder =>
                    {
                        namespaceBuilder.EmitType(TypeKind.Struct, handle.Name, typeBuilder =>
                        {
                            typeBuilder.EmitField(rawType, "handle", Internal);

                            typeBuilder.EmitConstructor(body =>
                            {
                                body.EmitAssignment(Member(This, "handle"), Variable("handle"));
                            },
                            parameters =>
                            {
                                parameters.EmitParam(rawType, "handle");
                            }, Public);

                            typeBuilder.EmitProperty(handle.Name, "Null", New(handle.Name, Default(rawType)), Public);

                            typeBuilder.EmitMethod("ulong", "ToUInt64", body =>
                            {
                                var returnValue = Member(This, "handle");

                                if (handle.IsDispatch)
                                {
                                    returnValue = Call(returnValue, "ToUInt64");
                                }

                                body.EmitReturn(returnValue);
                            },
                            parameters => { }, Public);
                        }, Public);
                    });

                });

                this.builderFactory.Generate(handle.Name, path, fileBuilder =>
                {
                    fileBuilder.EmitUsing("System");

                    string interopTypeName = $"{interopNamespace}.{handle.Name}";

                    fileBuilder.EmitNamespace(@namespace, namespaceBuilder =>
                    {
                        namespaceBuilder.EmitType(TypeKind.Class, handle.Name, typeBuilder =>
                        {
                            typeBuilder.EmitField(interopTypeName, "handle", Internal, MemberModifier.Readonly);

                            typeBuilder.EmitConstructor(body =>
                            {
                                body.EmitAssignment(Member(This, "handle"), Variable("handle"));
                            },
                            parameters =>
                            {
                                parameters.EmitParam(interopTypeName, "handle");
                            }, Internal);
                        }, Public, modifiers: TypeModifier.Partial);
                    });
                });
            }
        }
    }
}