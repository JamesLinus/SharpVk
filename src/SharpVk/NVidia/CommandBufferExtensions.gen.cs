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

namespace SharpVk.NVidia
{
    /// <summary>
    /// 
    /// </summary>
    public static class CommandBufferExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static unsafe void SetViewportWScaling(this SharpVk.CommandBuffer extendedHandle, uint firstViewport, SharpVk.NVidia.ViewportWScaling[] viewportWScalings)
        {
            try
            {
                CommandCache commandCache = default(CommandCache);
                SharpVk.NVidia.ViewportWScaling* marshalledViewportWScalings = default(SharpVk.NVidia.ViewportWScaling*);
                commandCache = extendedHandle.commandCache;
                if (viewportWScalings != null)
                {
                    var fieldPointer = (SharpVk.NVidia.ViewportWScaling*)(Interop.HeapUtil.AllocateAndClear<SharpVk.NVidia.ViewportWScaling>(viewportWScalings.Length).ToPointer());
                    for(int index = 0; index < (uint)(viewportWScalings.Length); index++)
                    {
                        fieldPointer[index] = viewportWScalings[index];
                    }
                    marshalledViewportWScalings = fieldPointer;
                }
                else
                {
                    marshalledViewportWScalings = null;
                }
                SharpVk.Interop.NVidia.VkCommandBufferSetViewportWScalingDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.NVidia.VkCommandBufferSetViewportWScalingDelegate>("vkCmdSetViewportWScalingNV", "instance");
                commandDelegate(extendedHandle.handle, firstViewport, (uint)(viewportWScalings?.Length ?? 0), marshalledViewportWScalings);
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
    }
}
