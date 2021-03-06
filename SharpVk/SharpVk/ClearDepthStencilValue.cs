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
    /// Structure specifying a clear depth stencil value.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct ClearDepthStencilValue
    {
        /// <summary>
        /// 
        /// </summary>
        public ClearDepthStencilValue(float depth, uint stencil)
        {
            this.Depth = depth;
            this.Stencil = stencil;
        }
        
        /// <summary>
        /// pname:depth is the clear value for the depth aspect of the
        /// depth/stencil attachment. It is a floating-point value which is
        /// automatically converted to the attachment's format.
        /// </summary>
        public float Depth; 
        
        /// <summary>
        /// pname:stencil is the clear value for the stencil aspect of the
        /// depth/stencil attachment. It is a 32-bit integer value which is
        /// converted to the attachment's format by taking the appropriate
        /// number of LSBs.
        /// </summary>
        public uint Stencil; 
        
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("ClearDepthStencilValue");
            builder.AppendLine("{");
            builder.AppendLine($"Depth: {this.Depth}");
            builder.AppendLine($"Stencil: {this.Stencil}");
            builder.Append("}");
            return builder.ToString();
        }
    }
}
