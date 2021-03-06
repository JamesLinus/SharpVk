﻿using System.Runtime.InteropServices;

namespace SharpVk.Glfw
{
    [StructLayout(LayoutKind.Sequential)]
    public struct VideoMode
    {
        public int Width;
        
        public int Height;
        
        public int RedBits;
        
        public int GreenBits;
        
        public int BlueBits;
        
        public int RefreshRate;
    }
}
