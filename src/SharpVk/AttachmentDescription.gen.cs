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
    public struct AttachmentDescription
    {
        /// <summary>
        /// 
        /// </summary>
        public AttachmentDescription(SharpVk.AttachmentDescriptionFlags flags, SharpVk.Format format, SharpVk.SampleCountFlags samples, SharpVk.AttachmentLoadOp loadOp, SharpVk.AttachmentStoreOp storeOp, SharpVk.AttachmentLoadOp stencilLoadOp, SharpVk.AttachmentStoreOp stencilStoreOp, SharpVk.ImageLayout initialLayout, SharpVk.ImageLayout finalLayout)
        {
            this.Flags = flags;
            this.Format = format;
            this.Samples = samples;
            this.LoadOp = loadOp;
            this.StoreOp = storeOp;
            this.StencilLoadOp = stencilLoadOp;
            this.StencilStoreOp = stencilStoreOp;
            this.InitialLayout = initialLayout;
            this.FinalLayout = finalLayout;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.AttachmentDescriptionFlags Flags; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.Format Format; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.SampleCountFlags Samples; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.AttachmentLoadOp LoadOp; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.AttachmentStoreOp StoreOp; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.AttachmentLoadOp StencilLoadOp; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.AttachmentStoreOp StencilStoreOp; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.ImageLayout InitialLayout; 
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.ImageLayout FinalLayout; 
    }
}
