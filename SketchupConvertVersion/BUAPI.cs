using System;
using System.Runtime;
using System.Runtime.InteropServices;

namespace SketchupConvertVersion
{
    public class BUAPI
    {
        public const string LIB = "BUAPI.dll";

        [DllImport(LIB, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool BUSaveAs(string oldFile, string newFile, int version);
    }
}
