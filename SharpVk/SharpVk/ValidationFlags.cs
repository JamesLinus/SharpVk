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
    /// Specify validation checks to disable for a Vulkan instance.
    /// </summary>
    public struct ValidationFlags
    {
        /// <summary>
        /// pname:pDisabledValidationChecks is a pointer to an array of values
        /// specifying the validation checks to be disabled. Checks which may:
        /// be specified include: + --
        /// </summary>
        public ValidationCheck[] DisabledValidationChecks
        {
            get;
            set;
        }
        
        internal unsafe Interop.ValidationFlags* MarshalTo()
        {
            var result = (Interop.ValidationFlags*)Interop.HeapUtil.AllocateAndClear<Interop.ValidationFlags>().ToPointer();
            this.MarshalTo(result);
            return result;
        }
        
        internal unsafe void MarshalTo(Interop.ValidationFlags* pointer)
        {
            pointer->SType = StructureType.ValidationFlags;
            pointer->Next = null;
            
            //DisabledValidationChecks
            if (this.DisabledValidationChecks != null)
            {
                pointer->DisabledValidationChecks = (ValidationCheck*)Interop.HeapUtil.Allocate<int>(this.DisabledValidationChecks.Length).ToPointer();
                for (int index = 0; index < this.DisabledValidationChecks.Length; index++)
                {
                    pointer->DisabledValidationChecks[index] = this.DisabledValidationChecks[index];
                }
            }
            else
            {
                pointer->DisabledValidationChecks = null;
            }
            pointer->DisabledValidationCheckCount = (uint)(this.DisabledValidationChecks?.Length ?? 0);
        }
    }
}
