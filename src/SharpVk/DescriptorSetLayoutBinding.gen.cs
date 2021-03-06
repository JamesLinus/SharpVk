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

namespace SharpVk
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DescriptorSetLayoutBinding
    {
        /// <summary>
        /// 
        /// </summary>
        public uint Binding
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.DescriptorType DescriptorType
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public uint? DescriptorCount
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.ShaderStageFlags StageFlags
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Sampler[] ImmutableSamplers
        {
            get;
            set;
        }
        
        internal unsafe void MarshalTo(SharpVk.Interop.DescriptorSetLayoutBinding* pointer)
        {
            pointer->Binding = this.Binding;
            pointer->DescriptorType = this.DescriptorType;
            if (this.DescriptorCount != null)
            {
                pointer->DescriptorCount = this.DescriptorCount.Value;
            }
            else
            {
                pointer->DescriptorCount = (uint)(this.ImmutableSamplers?.Length ?? 0);
            }
            pointer->StageFlags = this.StageFlags;
            if (this.ImmutableSamplers != null)
            {
                var fieldPointer = (SharpVk.Interop.Sampler*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.Sampler>(this.ImmutableSamplers.Length).ToPointer());
                for(int index = 0; index < (uint)(this.ImmutableSamplers.Length); index++)
                {
                    fieldPointer[index] = this.ImmutableSamplers[index]?.handle ?? default(SharpVk.Interop.Sampler);
                }
                pointer->ImmutableSamplers = fieldPointer;
            }
            else
            {
                pointer->ImmutableSamplers = null;
            }
        }
    }
}
