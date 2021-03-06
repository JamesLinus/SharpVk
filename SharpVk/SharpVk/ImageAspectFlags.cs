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

namespace SharpVk
{
    /// <summary>
    /// <para>
    /// Bitmask specifying which aspects of an image are included in a view.
    /// </para>
    /// <para>
    /// The mask must: be only ename:VK_IMAGE_ASPECT_COLOR_BIT,
    /// ename:VK_IMAGE_ASPECT_DEPTH_BIT or ename:VK_IMAGE_ASPECT_STENCIL_BIT if
    /// pname:format is a color, depth-only or stencil-only format,
    /// respectively. If using a depth/stencil format with both depth and
    /// stencil components, pname:aspectMask must: include at least one of
    /// ename:VK_IMAGE_ASPECT_DEPTH_BIT and ename:VK_IMAGE_ASPECT_STENCIL_BIT,
    /// and can: include both.
    /// </para>
    /// <para>
    /// When using an imageView of a depth/stencil image to populate a
    /// descriptor set (e.g. for sampling in the shader, or for use as an input
    /// attachment), the pname:aspectMask must: only include one bit and
    /// selects whether the imageView is used for depth reads (i.e. using a
    /// floating-point sampler or input attachment in the shader) or stencil
    /// reads (i.e. using an unsigned integer sampler or input attachment in
    /// the shader). When an imageView of a depth/stencil image is used as a
    /// depth/stencil framebuffer attachment, the pname:aspectMask is ignored
    /// and both depth and stencil image subresources are used.
    /// </para>
    /// <para>
    /// The pname:components member is of type slink:VkComponentMapping, and
    /// describes a remapping from components of the image to components of the
    /// vector returned by shader image instructions. This remapping must: be
    /// identity for storage image descriptors, input attachment descriptors,
    /// and framebuffer attachments.
    /// </para>
    /// <para>
    /// ****
    /// </para>
    /// </summary>
    [Flags]
    public enum ImageAspectFlags
    {
        /// <summary>
        /// -
        /// </summary>
        None = 0, 
        
        /// <summary>
        /// -
        /// </summary>
        Color = 1 << 0, 
        
        /// <summary>
        /// -
        /// </summary>
        Depth = 1 << 1, 
        
        /// <summary>
        /// -
        /// </summary>
        Stencil = 1 << 2, 
        
        /// <summary>
        /// -
        /// </summary>
        Metadata = 1 << 3, 
    }
}
