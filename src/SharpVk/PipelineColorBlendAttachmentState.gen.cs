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
    public struct PipelineColorBlendAttachmentState
    {
        /// <summary>
        /// 
        /// </summary>
        public bool BlendEnable
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.BlendFactor SourceColorBlendFactor
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.BlendFactor DestinationColorBlendFactor
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.BlendOp ColorBlendOp
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.BlendFactor SourceAlphaBlendFactor
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.BlendFactor DestinationAlphaBlendFactor
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.BlendOp AlphaBlendOp
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SharpVk.ColorComponentFlags? ColorWriteMask
        {
            get;
            set;
        }
        
        internal unsafe void MarshalTo(SharpVk.Interop.PipelineColorBlendAttachmentState* pointer)
        {
            pointer->BlendEnable = this.BlendEnable;
            pointer->SourceColorBlendFactor = this.SourceColorBlendFactor;
            pointer->DestinationColorBlendFactor = this.DestinationColorBlendFactor;
            pointer->ColorBlendOp = this.ColorBlendOp;
            pointer->SourceAlphaBlendFactor = this.SourceAlphaBlendFactor;
            pointer->DestinationAlphaBlendFactor = this.DestinationAlphaBlendFactor;
            pointer->AlphaBlendOp = this.AlphaBlendOp;
            if (this.ColorWriteMask != null)
            {
                pointer->ColorWriteMask = this.ColorWriteMask.Value;
            }
            else
            {
                pointer->ColorWriteMask = default(SharpVk.ColorComponentFlags);
            }
        }
        
        internal static unsafe PipelineColorBlendAttachmentState MarshalFrom(SharpVk.Interop.PipelineColorBlendAttachmentState* pointer)
        {
            PipelineColorBlendAttachmentState result = default(PipelineColorBlendAttachmentState);
            result.BlendEnable = pointer->BlendEnable;
            result.SourceColorBlendFactor = pointer->SourceColorBlendFactor;
            result.DestinationColorBlendFactor = pointer->DestinationColorBlendFactor;
            result.ColorBlendOp = pointer->ColorBlendOp;
            result.SourceAlphaBlendFactor = pointer->SourceAlphaBlendFactor;
            result.DestinationAlphaBlendFactor = pointer->DestinationAlphaBlendFactor;
            result.AlphaBlendOp = pointer->AlphaBlendOp;
            result.ColorWriteMask = pointer->ColorWriteMask;
            return result;
        }
    }
}
