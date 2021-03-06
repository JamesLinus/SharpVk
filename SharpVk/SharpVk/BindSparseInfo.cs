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
    /// Structure specifying a sparse binding operation.
    /// </summary>
    public struct BindSparseInfo
    {
        /// <summary>
        /// pname:pWaitSemaphores is a pointer to an array of semaphores upon
        /// which to wait on before the sparse binding operations for this
        /// batch begin execution. If semaphores to wait on are provided, they
        /// define a &lt;&lt;synchronization-semaphores-waiting, semaphore wait
        /// operation&gt;&gt;.
        /// </summary>
        public Semaphore[] WaitSemaphores
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:pBufferBinds is a pointer to an array of
        /// slink:VkSparseBufferMemoryBindInfo structures.
        /// </summary>
        public SparseBufferMemoryBindInfo[] BufferBinds
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:pImageOpaqueBinds is a pointer to an array of
        /// slink:VkSparseImageOpaqueMemoryBindInfo structures, indicating
        /// opaque sparse image bindings to perform.
        /// </summary>
        public SparseImageOpaqueMemoryBindInfo[] ImageOpaqueBinds
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:pImageBinds is a pointer to an array of
        /// slink:VkSparseImageMemoryBindInfo structures, indicating sparse
        /// image bindings to perform.
        /// </summary>
        public SparseImageMemoryBindInfo[] ImageBinds
        {
            get;
            set;
        }
        
        /// <summary>
        /// pname:pSignalSemaphores is a pointer to an array of semaphores
        /// which will be signaled when the sparse binding operations for this
        /// batch have completed execution. If semaphores to be signaled are
        /// provided, they define a
        /// &lt;&lt;synchronization-semaphores-signaling, semaphore signal
        /// operation&gt;&gt;.
        /// </summary>
        public Semaphore[] SignalSemaphores
        {
            get;
            set;
        }
        
        internal unsafe Interop.BindSparseInfo* MarshalTo()
        {
            var result = (Interop.BindSparseInfo*)Interop.HeapUtil.AllocateAndClear<Interop.BindSparseInfo>().ToPointer();
            this.MarshalTo(result);
            return result;
        }
        
        internal unsafe void MarshalTo(Interop.BindSparseInfo* pointer)
        {
            pointer->SType = StructureType.BindSparseInfo;
            pointer->Next = null;
            
            //WaitSemaphores
            if (this.WaitSemaphores != null)
            {
                var fieldPointer = (Interop.Semaphore*)Interop.HeapUtil.AllocateAndClear<Interop.Semaphore>(this.WaitSemaphores.Length);
                for (int index = 0; index < this.WaitSemaphores.Length; index++)
                {
                    this.WaitSemaphores[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->WaitSemaphores = fieldPointer;
            }
            else
            {
                pointer->WaitSemaphores = null;
            }
            
            //BufferBinds
            if (this.BufferBinds != null)
            {
                var fieldPointer = (Interop.SparseBufferMemoryBindInfo*)Interop.HeapUtil.AllocateAndClear<Interop.SparseBufferMemoryBindInfo>(this.BufferBinds.Length);
                for (int index = 0; index < this.BufferBinds.Length; index++)
                {
                    this.BufferBinds[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->BufferBinds = fieldPointer;
            }
            else
            {
                pointer->BufferBinds = null;
            }
            
            //ImageOpaqueBinds
            if (this.ImageOpaqueBinds != null)
            {
                var fieldPointer = (Interop.SparseImageOpaqueMemoryBindInfo*)Interop.HeapUtil.AllocateAndClear<Interop.SparseImageOpaqueMemoryBindInfo>(this.ImageOpaqueBinds.Length);
                for (int index = 0; index < this.ImageOpaqueBinds.Length; index++)
                {
                    this.ImageOpaqueBinds[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->ImageOpaqueBinds = fieldPointer;
            }
            else
            {
                pointer->ImageOpaqueBinds = null;
            }
            
            //ImageBinds
            if (this.ImageBinds != null)
            {
                var fieldPointer = (Interop.SparseImageMemoryBindInfo*)Interop.HeapUtil.AllocateAndClear<Interop.SparseImageMemoryBindInfo>(this.ImageBinds.Length);
                for (int index = 0; index < this.ImageBinds.Length; index++)
                {
                    this.ImageBinds[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->ImageBinds = fieldPointer;
            }
            else
            {
                pointer->ImageBinds = null;
            }
            
            //SignalSemaphores
            if (this.SignalSemaphores != null)
            {
                var fieldPointer = (Interop.Semaphore*)Interop.HeapUtil.AllocateAndClear<Interop.Semaphore>(this.SignalSemaphores.Length);
                for (int index = 0; index < this.SignalSemaphores.Length; index++)
                {
                    this.SignalSemaphores[index].MarshalTo(&fieldPointer[index]);
                }
                pointer->SignalSemaphores = fieldPointer;
            }
            else
            {
                pointer->SignalSemaphores = null;
            }
            pointer->WaitSemaphoreCount = (uint)(this.WaitSemaphores?.Length ?? 0);
            pointer->BufferBindCount = (uint)(this.BufferBinds?.Length ?? 0);
            pointer->ImageOpaqueBindCount = (uint)(this.ImageOpaqueBinds?.Length ?? 0);
            pointer->ImageBindCount = (uint)(this.ImageBinds?.Length ?? 0);
            pointer->SignalSemaphoreCount = (uint)(this.SignalSemaphores?.Length ?? 0);
        }
    }
}
