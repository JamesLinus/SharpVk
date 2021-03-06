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

namespace SharpVk.Khronos
{
    /// <summary>
    /// 
    /// </summary>
    public static class InstanceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        public static unsafe SharpVk.Khronos.Surface CreateAndroidSurface(this SharpVk.Instance extendedHandle, IntPtr window, SharpVk.Khronos.AndroidSurfaceCreateFlags? flags = default(SharpVk.Khronos.AndroidSurfaceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Khronos.Surface result = default(SharpVk.Khronos.Surface);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.AndroidSurfaceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.Khronos.AndroidSurfaceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Khronos.Surface marshalledSurface = default(SharpVk.Interop.Khronos.Surface);
                commandCache = extendedHandle.commandCache;
                marshalledCreateInfo = (SharpVk.Interop.Khronos.AndroidSurfaceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Khronos.AndroidSurfaceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.AndroidSurfaceCreateInfoKhr;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.Khronos.AndroidSurfaceCreateFlags);
                }
                marshalledCreateInfo->Window = (IntPtr*)(Interop.HeapUtil.Allocate<IntPtr>());
                *marshalledCreateInfo->Window = window;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.Khronos.VkInstanceCreateAndroidSurfaceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Khronos.VkInstanceCreateAndroidSurfaceDelegate>("vkCreateAndroidSurfaceKHR", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSurface);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Khronos.Surface(extendedHandle, marshalledSurface);
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
        public static unsafe SharpVk.Khronos.Surface CreateDisplayPlaneSurface(this SharpVk.Instance extendedHandle, SharpVk.Khronos.DisplayMode displayMode, uint planeIndex, uint planeStackIndex, SharpVk.Khronos.SurfaceTransformFlags transform, float globalAlpha, SharpVk.Khronos.DisplayPlaneAlphaFlags alphaMode, SharpVk.Extent2D imageExtent, SharpVk.Khronos.DisplaySurfaceCreateFlags? flags = default(SharpVk.Khronos.DisplaySurfaceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Khronos.Surface result = default(SharpVk.Khronos.Surface);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.DisplaySurfaceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.Khronos.DisplaySurfaceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Khronos.Surface marshalledSurface = default(SharpVk.Interop.Khronos.Surface);
                commandCache = extendedHandle.commandCache;
                marshalledCreateInfo = (SharpVk.Interop.Khronos.DisplaySurfaceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Khronos.DisplaySurfaceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.DisplaySurfaceCreateInfoKhr;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.Khronos.DisplaySurfaceCreateFlags);
                }
                marshalledCreateInfo->DisplayMode = displayMode?.handle ?? default(SharpVk.Interop.Khronos.DisplayMode);
                marshalledCreateInfo->PlaneIndex = planeIndex;
                marshalledCreateInfo->PlaneStackIndex = planeStackIndex;
                marshalledCreateInfo->Transform = transform;
                marshalledCreateInfo->GlobalAlpha = globalAlpha;
                marshalledCreateInfo->AlphaMode = alphaMode;
                marshalledCreateInfo->ImageExtent = imageExtent;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.Khronos.VkInstanceCreateDisplayPlaneSurfaceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Khronos.VkInstanceCreateDisplayPlaneSurfaceDelegate>("vkCreateDisplayPlaneSurfaceKHR", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSurface);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Khronos.Surface(extendedHandle, marshalledSurface);
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
        public static unsafe SharpVk.Khronos.Surface CreateMirSurface(this SharpVk.Instance extendedHandle, IntPtr connection, IntPtr mirSurface, SharpVk.Khronos.MirSurfaceCreateFlags? flags = default(SharpVk.Khronos.MirSurfaceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Khronos.Surface result = default(SharpVk.Khronos.Surface);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.MirSurfaceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.Khronos.MirSurfaceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Khronos.Surface marshalledSurface = default(SharpVk.Interop.Khronos.Surface);
                commandCache = extendedHandle.commandCache;
                marshalledCreateInfo = (SharpVk.Interop.Khronos.MirSurfaceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Khronos.MirSurfaceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.MirSurfaceCreateInfoKhr;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.Khronos.MirSurfaceCreateFlags);
                }
                marshalledCreateInfo->Connection = (IntPtr*)(Interop.HeapUtil.Allocate<IntPtr>());
                *marshalledCreateInfo->Connection = connection;
                marshalledCreateInfo->MirSurface = (IntPtr*)(Interop.HeapUtil.Allocate<IntPtr>());
                *marshalledCreateInfo->MirSurface = mirSurface;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.Khronos.VkInstanceCreateMirSurfaceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Khronos.VkInstanceCreateMirSurfaceDelegate>("vkCreateMirSurfaceKHR", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSurface);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Khronos.Surface(extendedHandle, marshalledSurface);
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
        public static unsafe SharpVk.Khronos.Surface CreateWaylandSurface(this SharpVk.Instance extendedHandle, IntPtr display, IntPtr surface, SharpVk.Khronos.WaylandSurfaceCreateFlags? flags = default(SharpVk.Khronos.WaylandSurfaceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Khronos.Surface result = default(SharpVk.Khronos.Surface);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.WaylandSurfaceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.Khronos.WaylandSurfaceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Khronos.Surface marshalledSurface = default(SharpVk.Interop.Khronos.Surface);
                commandCache = extendedHandle.commandCache;
                marshalledCreateInfo = (SharpVk.Interop.Khronos.WaylandSurfaceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Khronos.WaylandSurfaceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.WaylandSurfaceCreateInfoKhr;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.Khronos.WaylandSurfaceCreateFlags);
                }
                marshalledCreateInfo->Display = display;
                marshalledCreateInfo->Surface = surface;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.Khronos.VkInstanceCreateWaylandSurfaceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Khronos.VkInstanceCreateWaylandSurfaceDelegate>("vkCreateWaylandSurfaceKHR", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSurface);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Khronos.Surface(extendedHandle, marshalledSurface);
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
        public static unsafe SharpVk.Khronos.Surface CreateWin32Surface(this SharpVk.Instance extendedHandle, IntPtr hinstance, IntPtr hwnd, SharpVk.Khronos.Win32SurfaceCreateFlags? flags = default(SharpVk.Khronos.Win32SurfaceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Khronos.Surface result = default(SharpVk.Khronos.Surface);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.Win32SurfaceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.Khronos.Win32SurfaceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Khronos.Surface marshalledSurface = default(SharpVk.Interop.Khronos.Surface);
                commandCache = extendedHandle.commandCache;
                marshalledCreateInfo = (SharpVk.Interop.Khronos.Win32SurfaceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Khronos.Win32SurfaceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.Win32SurfaceCreateInfoKhr;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.Khronos.Win32SurfaceCreateFlags);
                }
                marshalledCreateInfo->Hinstance = hinstance;
                marshalledCreateInfo->Hwnd = hwnd;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.Khronos.VkInstanceCreateWin32SurfaceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Khronos.VkInstanceCreateWin32SurfaceDelegate>("vkCreateWin32SurfaceKHR", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSurface);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Khronos.Surface(extendedHandle, marshalledSurface);
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
        public static unsafe SharpVk.Khronos.Surface CreateXlibSurface(this SharpVk.Instance extendedHandle, IntPtr dpy, IntPtr window, SharpVk.Khronos.XlibSurfaceCreateFlags? flags = default(SharpVk.Khronos.XlibSurfaceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Khronos.Surface result = default(SharpVk.Khronos.Surface);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.XlibSurfaceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.Khronos.XlibSurfaceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Khronos.Surface marshalledSurface = default(SharpVk.Interop.Khronos.Surface);
                commandCache = extendedHandle.commandCache;
                marshalledCreateInfo = (SharpVk.Interop.Khronos.XlibSurfaceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Khronos.XlibSurfaceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.XlibSurfaceCreateInfoKhr;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.Khronos.XlibSurfaceCreateFlags);
                }
                marshalledCreateInfo->Dpy = (IntPtr*)(Interop.HeapUtil.Allocate<IntPtr>());
                *marshalledCreateInfo->Dpy = dpy;
                marshalledCreateInfo->Window = window;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.Khronos.VkInstanceCreateXlibSurfaceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Khronos.VkInstanceCreateXlibSurfaceDelegate>("vkCreateXlibSurfaceKHR", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSurface);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Khronos.Surface(extendedHandle, marshalledSurface);
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
        public static unsafe SharpVk.Khronos.Surface CreateXcbSurface(this SharpVk.Instance extendedHandle, IntPtr connection, IntPtr window, SharpVk.Khronos.XcbSurfaceCreateFlags? flags = default(SharpVk.Khronos.XcbSurfaceCreateFlags?), SharpVk.AllocationCallbacks? allocator = default(SharpVk.AllocationCallbacks?))
        {
            try
            {
                SharpVk.Khronos.Surface result = default(SharpVk.Khronos.Surface);
                CommandCache commandCache = default(CommandCache);
                SharpVk.Interop.Khronos.XcbSurfaceCreateInfo* marshalledCreateInfo = default(SharpVk.Interop.Khronos.XcbSurfaceCreateInfo*);
                SharpVk.Interop.AllocationCallbacks* marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                SharpVk.Interop.Khronos.Surface marshalledSurface = default(SharpVk.Interop.Khronos.Surface);
                commandCache = extendedHandle.commandCache;
                marshalledCreateInfo = (SharpVk.Interop.Khronos.XcbSurfaceCreateInfo*)(Interop.HeapUtil.Allocate<SharpVk.Interop.Khronos.XcbSurfaceCreateInfo>());
                marshalledCreateInfo->SType = StructureType.XcbSurfaceCreateInfoKhr;
                marshalledCreateInfo->Next = null;
                if (flags != null)
                {
                    marshalledCreateInfo->Flags = flags.Value;
                }
                else
                {
                    marshalledCreateInfo->Flags = default(SharpVk.Khronos.XcbSurfaceCreateFlags);
                }
                marshalledCreateInfo->Connection = (IntPtr*)(Interop.HeapUtil.Allocate<IntPtr>());
                *marshalledCreateInfo->Connection = connection;
                marshalledCreateInfo->Window = window;
                if (allocator != null)
                {
                    marshalledAllocator = (SharpVk.Interop.AllocationCallbacks*)(Interop.HeapUtil.Allocate<SharpVk.Interop.AllocationCallbacks>());
                    allocator.Value.MarshalTo(marshalledAllocator);
                }
                else
                {
                    marshalledAllocator = default(SharpVk.Interop.AllocationCallbacks*);
                }
                SharpVk.Interop.Khronos.VkInstanceCreateXcbSurfaceDelegate commandDelegate = commandCache.GetCommandDelegate<SharpVk.Interop.Khronos.VkInstanceCreateXcbSurfaceDelegate>("vkCreateXcbSurfaceKHR", "instance");
                Result methodResult = commandDelegate(extendedHandle.handle, marshalledCreateInfo, marshalledAllocator, &marshalledSurface);
                if (SharpVkException.IsError(methodResult))
                {
                    throw SharpVkException.Create(methodResult);
                }
                result = new SharpVk.Khronos.Surface(extendedHandle, marshalledSurface);
                return result;
            }
            finally
            {
                Interop.HeapUtil.FreeAll();
            }
        }
    }
}
