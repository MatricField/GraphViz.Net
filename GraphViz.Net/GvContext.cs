using GraphViz.Net.PInvoke;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GraphViz.Net
{
    public class GvContext :
        NativeHandle<IntPtr>
    {
        #region Fields
        private readonly IntPtr pContext;
        #endregion
        public GvContext()
        {
            pContext = Gvc.gvContext();
        }
        private T DoRender<T>(Func<IntPtr, int, T> Convert, Graph graph, string format, string layoutEngine = "dot")
        {
            IntPtr pGraph = graph.Handle;
            IntPtr pData = default;
            try
            {
                Gvc.gvLayout(pContext, pGraph, layoutEngine);
                Gvc.gvRenderData(pContext, pGraph, format, out pData, out var size);
                return Convert(pData, size);
            }
            finally
            {
                Gvc.gvFreeLayout(pContext, pGraph);
                Gvc.gvFreeRenderData(pData);
            }
        }
        private static byte[] CopyRawData(IntPtr pData, int size)
        {
            var resultBuffer = new byte[size];
            Marshal.Copy(pData, resultBuffer, 0, size);
            return resultBuffer;
        }
        private static string MarshalSVG(IntPtr pData, int size)
        {
            return Marshal.PtrToStringUTF8(pData, size);
        }
        public string RenderSVG(Graph graph, string layoutEngine = "dot")
        {
            return DoRender(MarshalSVG, graph, "svg");
        }
        #region NativeHandle
        internal override IntPtr Handle => throw new NotImplementedException();
        protected override void FreeNativeResources()
        {
            var result = Gvc.gvFreeContext(pContext);
            if (result != 0)
            {
                throw new Win32Exception(result);
            }
        }
        #endregion
    }
}
