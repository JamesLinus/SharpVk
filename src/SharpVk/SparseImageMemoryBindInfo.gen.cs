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
    public struct SparseImageMemoryBindInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Image Image
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.SparseImageMemoryBind[] Binds
        {
            get;
            set;
        }
        
        internal unsafe void MarshalTo(SharpVk.Interop.SparseImageMemoryBindInfo* pointer)
        {
            pointer->Image = this.Image?.handle ?? default(SharpVk.Interop.Image);
            pointer->BindCount = (uint)(this.Binds?.Length ?? 0);
            if (this.Binds != null)
            {
                var fieldPointer = (SharpVk.Interop.SparseImageMemoryBind*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.SparseImageMemoryBind>(this.Binds.Length).ToPointer());
                for(int index = 0; index < (uint)(this.Binds.Length); index++)
                {
                    this.Binds[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->Binds = fieldPointer;
            }
            else
            {
                pointer->Binds = null;
            }
        }
    }
}
