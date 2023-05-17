using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net.PInvoke
{
    [Flags]
    internal enum CreateFlag: int
    {
        Default = 0,
        Create = 1,
    }
}
