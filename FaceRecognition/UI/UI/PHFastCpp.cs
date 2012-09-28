using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace UI
{
    class PHFastCpp
    {
        const string dllLocation = "PHFast.dll";
       
        [DllImport(dllLocation, EntryPoint = "PHGaussian1DFilter", CallingConvention = CallingConvention.Cdecl)]
        public static extern void PHGaussian1DFilter(int addressOriginal, int addressNew, int width, int height, int oldExtraBytes, int newExtraBytes, double sigma);

    }
}
