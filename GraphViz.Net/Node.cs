using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net
{
    public class Node
    {
        internal protected readonly IntPtr _pNode;

        internal protected Node(IntPtr pNode)
        {
            _pNode = pNode;
        }
    }
}
