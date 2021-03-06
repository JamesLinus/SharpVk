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
    public struct RenderPassCreateInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.RenderPassCreateFlags? Flags
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.AttachmentDescription[] Attachments
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.SubpassDescription[] Subpasses
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.SubpassDependency[] Dependencies
        {
            get;
            set;
        }
        
        internal unsafe void MarshalTo(SharpVk.Interop.RenderPassCreateInfo* pointer)
        {
            pointer->SType = StructureType.RenderPassCreateInfo;
            pointer->Next = null;
            if (this.Flags != null)
            {
                pointer->Flags = this.Flags.Value;
            }
            else
            {
                pointer->Flags = default(SharpVk.RenderPassCreateFlags);
            }
            pointer->AttachmentCount = (uint)(this.Attachments?.Length ?? 0);
            if (this.Attachments != null)
            {
                var fieldPointer = (SharpVk.AttachmentDescription*)(Interop.HeapUtil.AllocateAndClear<SharpVk.AttachmentDescription>(this.Attachments.Length).ToPointer());
                for(int index = 0; index < (uint)(this.Attachments.Length); index++)
                {
                    fieldPointer[index] = this.Attachments[index];
                }
                pointer->Attachments = fieldPointer;
            }
            else
            {
                pointer->Attachments = null;
            }
            pointer->SubpassCount = (uint)(this.Subpasses?.Length ?? 0);
            if (this.Subpasses != null)
            {
                var fieldPointer = (SharpVk.Interop.SubpassDescription*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.SubpassDescription>(this.Subpasses.Length).ToPointer());
                for(int index = 0; index < (uint)(this.Subpasses.Length); index++)
                {
                    this.Subpasses[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->Subpasses = fieldPointer;
            }
            else
            {
                pointer->Subpasses = null;
            }
            pointer->DependencyCount = (uint)(this.Dependencies?.Length ?? 0);
            if (this.Dependencies != null)
            {
                var fieldPointer = (SharpVk.SubpassDependency*)(Interop.HeapUtil.AllocateAndClear<SharpVk.SubpassDependency>(this.Dependencies.Length).ToPointer());
                for(int index = 0; index < (uint)(this.Dependencies.Length); index++)
                {
                    fieldPointer[index] = this.Dependencies[index];
                }
                pointer->Dependencies = fieldPointer;
            }
            else
            {
                pointer->Dependencies = null;
            }
        }
    }
}
