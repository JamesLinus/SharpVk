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

namespace SharpVk.Khronos.Experimental
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct AcquireNextImageInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Khronos.Swapchain Swapchain
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public ulong Timeout
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Semaphore Semaphore
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Fence Fence
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public uint DeviceMask
        {
            get;
            set;
        }
        
        internal unsafe void MarshalTo(SharpVk.Interop.Khronos.Experimental.AcquireNextImageInfo* pointer)
        {
            pointer->SType = StructureType.AcquireNextImageInfoKhx;
            pointer->Next = null;
            pointer->Swapchain = this.Swapchain?.handle ?? default(SharpVk.Interop.Khronos.Swapchain);
            pointer->Timeout = this.Timeout;
            pointer->Semaphore = this.Semaphore?.handle ?? default(SharpVk.Interop.Semaphore);
            pointer->Fence = this.Fence?.handle ?? default(SharpVk.Interop.Fence);
            pointer->DeviceMask = this.DeviceMask;
        }
    }
}
