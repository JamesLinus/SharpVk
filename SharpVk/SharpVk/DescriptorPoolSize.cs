// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2017
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This file was automatically generated and should not be edited directly.

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpVk
{
    /// <summary>
    /// Structure specifying descriptor pool size.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct DescriptorPoolSize
    {
        /// <summary>
        /// 
        /// </summary>
        public DescriptorPoolSize(DescriptorType type, uint descriptorCount)
        {
            this.Type = type;
            this.DescriptorCount = descriptorCount;
        }
        
        /// <summary>
        /// pname:type is the type of descriptor.
        /// </summary>
        public DescriptorType Type; 
        
        /// <summary>
        /// pname:descriptorCount is the number of descriptors of that type to
        /// allocate.
        /// </summary>
        public uint DescriptorCount; 
        
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("DescriptorPoolSize");
            builder.AppendLine("{");
            builder.AppendLine($"Type: {this.Type}");
            builder.AppendLine($"DescriptorCount: {this.DescriptorCount}");
            builder.Append("}");
            return builder.ToString();
        }
    }
}
