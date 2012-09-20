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
        public static extern void StartFaceRecognition(string databasePath, string modelPath, string testImagePath, int* rec, int* lbl, ref int count, short train);
    }
}
