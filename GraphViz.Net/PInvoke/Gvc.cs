using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net.PInvoke
{
    internal static class Gvc
    {
        [DllImport("gvc.dll")]
        internal static extern IntPtr gvContext();

        [DllImport("gvc.dll")]
        internal static extern int gvFreeContext(IntPtr gvc);

        [DllImport("gvc.dll")]
        internal static extern int gvLayout(IntPtr gvc, IntPtr g, [MarshalAs(UnmanagedType.LPUTF8Str)] string engine);

        [DllImport("gvc.dll")]
        internal static extern int gvFreeLayout(IntPtr gvc, IntPtr g);

        [DllImport("gvc.dll")]
        internal static extern int gvRenderData(
            IntPtr gvc,
            IntPtr g,
            [MarshalAs(UnmanagedType.LPUTF8Str)]
            string format,
            out IntPtr result,
            out int length);

        [DllImport("gvc.dll")]
        internal static extern void gvFreeRenderData(IntPtr data);
    }
}
