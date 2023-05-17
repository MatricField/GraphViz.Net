using GraphViz.Net.PInvoke.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net.PInvoke
{
    internal static class Globals
    {
        internal static class GraphDescriptors
        {
            public static GDesc Directed { get; }
            public static GDesc StrictDirected { get; }
            public static GDesc Undirected { get; }
            public static GDesc StrictUndirected { get; }

            static GraphDescriptors()
            {
                using(var dll = NativeDLL.Open("cgraph.dll"))
                {
                    var ptr = dll.GetSymbolAddress("Agdirected");
                    Directed = Marshal.PtrToStructure<GDesc>(ptr.Address);
                    ptr = dll.GetSymbolAddress("Agstrictdirected");
                    StrictDirected = Marshal.PtrToStructure<GDesc>(ptr.Address);
                    ptr = dll.GetSymbolAddress("Agundirected");
                    Undirected = Marshal.PtrToStructure<GDesc>(ptr.Address);
                    ptr = dll.GetSymbolAddress("Agstrictundirected");
                    StrictUndirected = Marshal.PtrToStructure<GDesc>(ptr.Address);
                }
            }
        }
    }
}
