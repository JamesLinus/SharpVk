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
    /// Structure specifying the parameters of a newly created image object.
    /// </para>
    /// <para>
    /// Images created with pname:tiling equal to ename:VK_IMAGE_TILING_LINEAR
    /// have further restrictions on their limits and capabilities compared to
    /// images created with pname:tiling equal to
    /// ename:VK_IMAGE_TILING_OPTIMAL. Creation of images with tiling
    /// ename:VK_IMAGE_TILING_LINEAR may: not be supported unless other
    /// parameters meet all of the constraints:
    /// </para>
    /// <para>
    /// * pname:imageType is ename:VK_IMAGE_TYPE_2D * pname:format is not a
    /// depth/stencil format * pname:mipLevels is 1 * pname:arrayLayers is 1 *
    /// pname:samples is ename:VK_SAMPLE_COUNT_1_BIT * pname:usage only
    /// includes ename:VK_IMAGE_USAGE_TRANSFER_SRC_BIT and/or
    /// ename:VK_IMAGE_USAGE_TRANSFER_DST_BIT
    /// </para>
    /// <para>
    /// Implementations may: support additional limits and capabilities beyond
    /// those listed above.
    /// </para>
    /// <para>
    /// To query an implementation's specific capabilities for a given
    /// combination of pname:format, pname:type, pname:tiling, pname:usage, and
    /// pname:flags, call flink:vkGetPhysicalDeviceImageFormatProperties. The
    /// return value indicates whether that combination of image settings is
    /// supported. On success, the sname:VkImageFormatProperties output
    /// parameter indicates the set of valid pname:samples bits and the limits
    /// for pname:extent, pname:mipLevels, and pname:arrayLayers.
    /// </para>
    /// <para>
    /// To determine the set of valid pname:usage bits for a given format, call
    /// flink:vkGetPhysicalDeviceFormatProperties.
    /// </para>
    /// </summary>
    public struct ImageCreateInfo
    {
        /// <summary>
        /// pname:flags is a bitmask describing additional parameters of the
        /// image. See elink:VkImageCreateFlagBits below for a description of
        /// the supported bits.
        /// </summary>
        public ImageCreateFlags Flags
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:imageType is a elink:VkImageType specifying the basic
        /// dimensionality of the image, as described below. Layers in array
        /// textures do not count as a dimension for the purposes of the image
        /// type.
        /// </summary>
        public ImageType ImageType
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:format is a elink:VkFormat describing the format and type of
        /// the data elements that will be contained in the image.
        /// </summary>
        public Format Format
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:extent is a slink:VkExtent3D describing the number of data
        /// elements in each dimension of the base level.
        /// </summary>
        public Extent3D Extent
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:mipLevels describes the number of levels of detail available
        /// for minified sampling of the image.
        /// </summary>
        public uint MipLevels
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:arrayLayers is the number of layers in the image.
        /// </summary>
        public uint ArrayLayers
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:samples is the number of sub-data element samples in the
        /// image as defined in elink:VkSampleCountFlagBits. See
        /// &lt;&lt;primsrast-multisampling,Multisampling&gt;&gt;.
        /// </summary>
        public SampleCountFlags Samples
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:tiling is a elink:VkImageTiling specifying the tiling
        /// arrangement of the data elements in memory, as described below.
        /// </summary>
        public ImageTiling Tiling
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:usage is a bitmask describing the intended usage of the
        /// image. See elink:VkImageUsageFlagBits below for a description of
        /// the supported bits.
        /// </summary>
        public ImageUsageFlags Usage
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:sharingMode is the sharing mode of the image when it will be
        /// accessed by multiple queue families, and must: be one of the values
        /// described for elink:VkSharingMode in the
        /// &lt;&lt;resources-sharing,Resource Sharing&gt;&gt; section below.
        /// </summary>
        public SharingMode SharingMode
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:pQueueFamilyIndices is a list of queue families that will
        /// access this image (ignored if pname:sharingMode is not
        /// ename:VK_SHARING_MODE_CONCURRENT).
        /// </summary>
        public uint[] QueueFamilyIndices
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:initialLayout selects the initial elink:VkImageLayout state
        /// of all image subresources of the image. See
        /// &lt;&lt;resources-image-layouts,Image Layouts&gt;&gt;.
        /// pname:initialLayout must: be ename:VK_IMAGE_LAYOUT_UNDEFINED or
        /// ename:VK_IMAGE_LAYOUT_PREINITIALIZED.
        /// </summary>
        public ImageLayout InitialLayout
        {
            get;
            set;
        }
        
        internal unsafe Interop.ImageCreateInfo* MarshalTo()
        {
            var result = (Interop.ImageCreateInfo*)Interop.HeapUtil.AllocateAndClear<Interop.ImageCreateInfo>().ToPointer();
            this.MarshalTo(result);
            return result;
        }
        
        internal unsafe void MarshalTo(Interop.ImageCreateInfo* pointer)
        {
            pointer->SType = StructureType.ImageCreateInfo;
            pointer->Next = null;
            pointer->QueueFamilyIndices = this.QueueFamilyIndices == null ? null : Interop.HeapUtil.MarshalTo(this.QueueFamilyIndices);
            pointer->QueueFamilyIndexCount = (uint)(this.QueueFamilyIndices?.Length ?? 0);
            pointer->Flags = this.Flags;
            pointer->ImageType = this.ImageType;
            pointer->Format = this.Format;
            pointer->Extent = this.Extent;
            pointer->MipLevels = this.MipLevels;
            pointer->ArrayLayers = this.ArrayLayers;
            pointer->Samples = this.Samples;
            pointer->Tiling = this.Tiling;
            pointer->Usage = this.Usage;
            pointer->SharingMode = this.SharingMode;
            pointer->InitialLayout = this.InitialLayout;
        }
    }
}
