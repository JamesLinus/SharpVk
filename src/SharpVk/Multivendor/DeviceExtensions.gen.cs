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

namespace SharpVk.Multivendor
{
    /// <summary>
    /// 
    /// </summary>
    public static class DeviceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static unsafe void DebugMarkerSetObjectName(this SharpVk.Device extendedHandle, SharpVk.Multivendor.DebugMarkerObjectNameInfo nameInfo)
        {
            try
            {
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Multivendor.DebugMarkerObjectNameInfo* marshalledNameInfo = default(SharpVk.Interop.Multivendor.DebugMarkerObjectNameInfo*);
                commandCache = extendedHandle.commandCache;
                marshalledNameInfo = (SharpVk.Interop.Multivendor.DebugMarkerObjectNameInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Multivendor.DebugMarkerObjectNameInfo>());
                nameInfo.MarshalTo(marshalledNameInfo);
                SharpVk.Interop.Multivendor.VkDeviceDebugMarkerSetObjectNameDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Multivendor.VkDeviceDebugMarkerSetObjectNameDelegate>("vkDebugMarkerSetObjectNameEXT", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledNameInfo);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static unsafe void DebugMarkerSetObjectTag(this SharpVk.Device extendedHandle, SharpVk.Multivendor.DebugMarkerObjectTagInfo tagInfo)
        {
            try
            {
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Multivendor.DebugMarkerObjectTagInfo* marshalledTagInfo = default(SharpVk.Interop.Multivendor.DebugMarkerObjectTagInfo*);
                commandCache = extendedHandle.commandCache;
                marshalledTagInfo = (SharpVk.Interop.Multivendor.DebugMarkerObjectTagInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Multivendor.DebugMarkerObjectTagInfo>());
                tagInfo.MarshalTo(marshalledTagInfo);
                SharpVk.Interop.Multivendor.VkDeviceDebugMarkerSetObjectTagDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Multivendor.VkDeviceDebugMarkerSetObjectTagDelegate>("vkDebugMarkerSetObjectTagEXT", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledTagInfo);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static unsafe void DisplayPowerControl(this SharpVk.Device extendedHandle, SharpVk.Khronos.Display display, SharpVk.Multivendor.DisplayPowerInfo displayPowerInfo)
        {
            try
            {
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Multivendor.DisplayPowerInfo* marshalledDisplayPowerInfo = default(SharpVk.Interop.Multivendor.DisplayPowerInfo*);
                commandCache = extendedHandle.commandCache;
                marshalledDisplayPowerInfo = (SharpVk.Interop.Multivendor.DisplayPowerInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Multivendor.DisplayPowerInfo>());
                displayPowerInfo.MarshalTo(marshalledDisplayPowerInfo);
                SharpVk.Interop.Multivendor.VkDeviceDisplayPowerControlDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Multivendor.VkDeviceDisplayPowerControlDelegate>("vkDisplayPowerControlEXT", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, display?.handle ?? default(SharpVk.Interop.Khronos.Display), marshalledDisplayPowerInfo);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static unsafe SharpVk.Fence RegisterEvent(this SharpVk.Device extendedHandle, SharpVk.Multivendor.DeviceEventInfo deviceEventInfo, SharpVk.AllocationCallbacks allocator)
        {
            try
            {
                SharpVk.Fence result = default(SharpVk.Fence);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Multivendor.DeviceEventInfo* marshalledDeviceEventInfo = default(SharpVk.Interop.Multivendor.DeviceEventInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Fence marshalledFence = default(SharpVk.Interop.Fence);
                commandCache = extendedHandle.commandCache;
                marshalledDeviceEventInfo = (SharpVk.Interop.Multivendor.DeviceEventInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Multivendor.DeviceEventInfo>());
                deviceEventInfo.MarshalTo(marshalledDeviceEventInfo);
                marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                allocator.MarshalTo(marshalledAllocator);
                SharpVk.Interop.Multivendor.VkDeviceRegisterEventDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Multivendor.VkDeviceRegisterEventDelegate>("vkRegisterDeviceEventEXT", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledDeviceEventInfo, marshalledAllocator, &marshalledFence);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Fence(extendedHandle, marshalledFence);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static unsafe SharpVk.Fence RegisterDisplayEvent(this SharpVk.Device extendedHandle, SharpVk.Khronos.Display display, SharpVk.Multivendor.DisplayEventInfo displayEventInfo, SharpVk.AllocationCallbacks allocator)
        {
            try
            {
                SharpVk.Fence result = default(SharpVk.Fence);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Multivendor.DisplayEventInfo* marshalledDisplayEventInfo = default(SharpVk.Interop.Multivendor.DisplayEventInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Fence marshalledFence = default(SharpVk.Interop.Fence);
                commandCache = extendedHandle.commandCache;
                marshalledDisplayEventInfo = (SharpVk.Interop.Multivendor.DisplayEventInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Multivendor.DisplayEventInfo>());
                displayEventInfo.MarshalTo(marshalledDisplayEventInfo);
                marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                allocator.MarshalTo(marshalledAllocator);
                SharpVk.Interop.Multivendor.VkDeviceRegisterDisplayEventDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Multivendor.VkDeviceRegisterDisplayEventDelegate>("vkRegisterDisplayEventEXT", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, display?.handle ?? default(SharpVk.Interop.Khronos.Display), marshalledDisplayEventInfo, marshalledAllocator, &marshalledFence);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Fence(extendedHandle, marshalledFence);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public static unsafe void SetHdrMetadata(this SharpVk.Device extendedHandle, SharpVk.Khronos.Swapchain[] swapchains, SharpVk.Multivendor.HdrMetadata[] metadata)
        {
            try
            {
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.Swapchain* marshalledSwapchains = default(SharpVk.Interop.Khronos.Swapchain*);
                SharpVk.Interop.Multivendor.HdrMetadata* marshalledMetadata = default(SharpVk.Interop.Multivendor.HdrMetadata*);
                commandCache = extendedHandle.commandCache;
                if (swapchains != null)
                {
                    var fieldPointer = (SharpVk.Interop.Khronos.Swapchain*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.Khronos.Swapchain>(swapchains.Length).ToPointer());
                    for(int index = 0; index < (uint)(swapchains.Length); index++)
                    {
                        fieldPointer[index] = swapchains[index]?.handle ?? default(SharpVk.Interop.Khronos.Swapchain);
                    }
                    marshalledSwapchains = fieldPointer;
                }
                else
                {
                    marshalledSwapchains = null;
                }
                if (metadata != null)
                {
                    var fieldPointer = (SharpVk.Interop.Multivendor.HdrMetadata*)(Interop.HeapUtil.AllocateAndClear<SharpVk.Interop.Multivendor.HdrMetadata>(metadata.Length).ToPointer());
                    for(int index = 0; index < (uint)(metadata.Length); index++)
                    {
                        metadata[index].MarshalTo(&fieldPointer[index]);
                    }
                    marshalledMetadata = fieldPointer;
                }
                else
                {
                    marshalledMetadata = null;
                }
                SharpVk.Interop.Multivendor.VkDeviceSetHdrMetadataDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Multivendor.VkDeviceSetHdrMetadataDelegate>("vkSetHdrMetadataEXT", "instance");
                commandDelegate(extendedHandle.handle, (uint)(swapchains?.Length ?? 0), marshalledSwapchains, marshalledMetadata);
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
    }
}
