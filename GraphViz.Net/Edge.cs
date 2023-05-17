using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net
{
    public class Edge
    {
        internal protected readonly IntPtr _pEdge;

        internal protected Edge(IntPtr pEdge)
        {
            _pEdge = pEdge;
        }
    }
}
