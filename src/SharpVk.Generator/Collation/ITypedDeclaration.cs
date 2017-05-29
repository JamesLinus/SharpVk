﻿namespace SharpVk.Generator.Collation
{
    public interface ITypedDeclaration
    {
        string VkName { get; }

        string Name { get; }

        string FixedValue { get; }

        TypeReference Type { get; }

        MemberLen[] Dimensions { get; }
    }
}