using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net.PInvoke.Types
{
    [StructLayout(LayoutKind.Sequential, Pack =1, Size = 4)]
    internal struct GDesc
    {
        private uint _data;
    }
}
