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
    /// Structure specifying physical device sparse memory properties.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct PhysicalDeviceSparseProperties
    {
        /// <summary>
        /// 
        /// </summary>
        public PhysicalDeviceSparseProperties(Bool32 residencyStandard2DBlockShape, Bool32 residencyStandard2DMultisampleBlockShape, Bool32 residencyStandard3DBlockShape, Bool32 residencyAlignedMipSize, Bool32 residencyNonResidentStrict)
        {
            this.ResidencyStandard2DBlockShape = residencyStandard2DBlockShape;
            this.ResidencyStandard2DMultisampleBlockShape = residencyStandard2DMultisampleBlockShape;
            this.ResidencyStandard3DBlockShape = residencyStandard3DBlockShape;
            this.ResidencyAlignedMipSize = residencyAlignedMipSize;
            this.ResidencyNonResidentStrict = residencyNonResidentStrict;
        }
        
        /// <summary>
        /// pname:residencyStandard2DBlockShape is ename:VK_TRUE if the
        /// physical device will access all single-sample 2D sparse resources
        /// using the standard sparse image block shapes (based on image
        /// format), as described in the
        /// &lt;&lt;sparsememory-sparseblockshapessingle,Standard Sparse Image
        /// Block Shapes (Single Sample)&gt;&gt; table. If this property is not
        /// supported the value returned in the pname:imageGranularity member
        /// of the sname:VkSparseImageFormatProperties structure for
        /// single-sample 2D images is not required: to match the standard
        /// sparse image block dimensions listed in the table.
        /// </summary>
        public Bool32 ResidencyStandard2DBlockShape; 
        
        /// <summary>
        /// pname:residencyStandard2DMultisampleBlockShape is ename:VK_TRUE if
        /// the physical device will access all multisample 2D sparse resources
        /// using the standard sparse image block shapes (based on image
        /// format), as described in the
        /// &lt;&lt;sparsememory-sparseblockshapesmsaa,Standard Sparse Image
        /// Block Shapes (MSAA)&gt;&gt; table. If this property is not
        /// supported, the value returned in the pname:imageGranularity member
        /// of the sname:VkSparseImageFormatProperties structure for
        /// multisample 2D images is not required: to match the standard sparse
        /// image block dimensions listed in the table.
        /// </summary>
        public Bool32 ResidencyStandard2DMultisampleBlockShape; 
        
        /// <summary>
        /// pname:residencyStandard3DBlockShape is ename:VK_TRUE if the
        /// physical device will access all 3D sparse resources using the
        /// standard sparse image block shapes (based on image format), as
        /// described in the
        /// &lt;&lt;sparsememory-sparseblockshapessingle,Standard Sparse Image
        /// Block Shapes (Single Sample)&gt;&gt; table. If this property is not
        /// supported, the value returned in the pname:imageGranularity member
        /// of the sname:VkSparseImageFormatProperties structure for 3D images
        /// is not required: to match the standard sparse image block
        /// dimensions listed in the table.
        /// </summary>
        public Bool32 ResidencyStandard3DBlockShape; 
        
        /// <summary>
        /// pname:residencyAlignedMipSize is ename:VK_TRUE if images with mip
        /// level dimensions that are not integer multiples of the
        /// corresponding dimensions of the sparse image block may: be placed
        /// in the mip tail. If this property is not reported, only mip levels
        /// with dimensions smaller than the pname:imageGranularity member of
        /// the sname:VkSparseImageFormatProperties structure will be placed in
        /// the mip tail. If this property is reported the implementation is
        /// allowed to return ename:VK_SPARSE_IMAGE_FORMAT_ALIGNED_MIP_SIZE_BIT
        /// in the pname:flags member of sname:VkSparseImageFormatProperties,
        /// indicating that mip level dimensions that are not integer multiples
        /// of the corresponding dimensions of the sparse image block will be
        /// placed in the mip tail.
        /// </summary>
        public Bool32 ResidencyAlignedMipSize; 
        
        /// <summary>
        /// pname:residencyNonResidentStrict specifies whether the physical
        /// device can: consistently access non-resident regions of a resource.
        /// If this property is ename:VK_TRUE, access to non-resident regions
        /// of resources will be guaranteed to return values as if the resource
        /// were populated with 0; writes to non-resident regions will be
        /// discarded.
        /// </summary>
        public Bool32 ResidencyNonResidentStrict; 
        
        /// <summary>
        /// 
        /// </summary>
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("PhysicalDeviceSparseProperties");
            builder.AppendLine("{");
            builder.AppendLine($"ResidencyStandard2DBlockShape: {this.ResidencyStandard2DBlockShape}");
            builder.AppendLine($"ResidencyStandard2DMultisampleBlockShape: {this.ResidencyStandard2DMultisampleBlockShape}");
            builder.AppendLine($"ResidencyStandard3DBlockShape: {this.ResidencyStandard3DBlockShape}");
            builder.AppendLine($"ResidencyAlignedMipSize: {this.ResidencyAlignedMipSize}");
            builder.AppendLine($"ResidencyNonResidentStrict: {this.ResidencyNonResidentStrict}");
            builder.Append("}");
            return builder.ToString();
        }
    }
}
