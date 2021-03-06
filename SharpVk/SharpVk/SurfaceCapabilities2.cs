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
    /// Structure describing capabilities of a surface.
    /// </summary>
    public struct SurfaceCapabilities2
    {
        /// <summary>
        /// -
        /// </summary>
        public uint MinImageCount
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public uint MaxImageCount
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public Extent2D CurrentExtent
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public Extent2D MinImageExtent
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public Extent2D MaxImageExtent
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public uint MaxImageArrayLayers
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public SurfaceTransformFlags SupportedTransforms
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public SurfaceTransformFlags CurrentTransform
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public CompositeAlphaFlags SupportedCompositeAlpha
        {
            get;
            set;
        }
        
        /// <summary>
        /// -
        /// </summary>
        public ImageUsageFlags SupportedUsageFlags
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:supportedSurfaceCounters is a bitfield containing one bit set
        /// for each surface counter type supported.
        /// </summary>
        public SurfaceCounterFlags SupportedSurfaceCounters
        {
            get;
            set;
        }
        
        internal static unsafe SurfaceCapabilities2 MarshalFrom(Interop.SurfaceCapabilities2* value)
        {
            SurfaceCapabilities2 result = new SurfaceCapabilities2();
            result.MinImageCount = value->MinImageCount;
            result.MaxImageCount = value->MaxImageCount;
            result.CurrentExtent = value->CurrentExtent;
            result.MinImageExtent = value->MinImageExtent;
            result.MaxImageExtent = value->MaxImageExtent;
            result.MaxImageArrayLayers = value->MaxImageArrayLayers;
            result.SupportedTransforms = value->SupportedTransforms;
            result.CurrentTransform = value->CurrentTransform;
            result.SupportedCompositeAlpha = value->SupportedCompositeAlpha;
            result.SupportedUsageFlags = value->SupportedUsageFlags;
            result.SupportedSurfaceCounters = value->SupportedSurfaceCounters;
            return result;
        }
    }
}
