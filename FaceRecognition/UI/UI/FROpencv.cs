using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace UI
{
   public static class FROpencv
    {
       
       const string dllLocation = "FaceRecOpenCV.dll";
        [DllImport(dllLocation, EntryPoint = "StartFaceRecognition", CallingConvention = CallingConvention.Cdecl)]
       unsafe
        public static extern void StartFaceRecognition(string testImagePath, string modelPath, string[] paths, int[] labels, ref int* rec, ref int* ilbl, ref int count, bool train);
       

    }
}