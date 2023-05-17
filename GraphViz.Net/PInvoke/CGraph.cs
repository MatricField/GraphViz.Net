using GraphViz.Net.PInvoke.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net.PInvoke
{
    internal static class CGraph
    {
        #region Graphs
        [DllImport("cgraph.dll")]
        public static extern IntPtr agopen(
            [MarshalAs(UnmanagedType.LPUTF8Str)]
            string name,
            GDesc desc,
            IntPtr disc = default);
        [DllImport("cgraph.dll")]
        public static extern IntPtr agclose(IntPtr g);
        #endregion
        #region Subgraphs
        #endregion
        #region Nodes
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createflag">
        /// If the node with given <paramref name="name"> does not exist,
        /// the function will create the specified object if
        /// <paramref name="createflag"/> is non-zero; otherwise, it will return <see cref="IntPtr.Zero"/>
        /// </param>
        [DllImport("cgraph.dll")]
        public static extern IntPtr agnode(
            IntPtr graph,
            [MarshalAs(UnmanagedType.LPUTF8Str)]
            string name,
            CreateFlag createflag);
        #endregion
        #region Edges
        /// <summary>
        /// Searches in a graph or subgraph for an edge between the given endpoints
        /// (with an optional multi-edge selector name) and returns it if found or created.
        /// </summary>
        /// <param name="createflag">
        /// If the edge with given <paramref name="name"> does not exist,
        /// the function will create the specified object if
        /// <paramref name="createflag"/> is non-zero; otherwise, it will return <see cref="IntPtr.Zero"/>
        /// </param>
        /// <param name="name">
        /// If the name is null, then an anonymous internal value is generated.
        /// </param>
        /// <remark>
        /// In undirected graphs, a search tries both orderings of the tail and head nodes
        /// </remark>
        [DllImport("cgraph.dll")]
        public static extern IntPtr agedge(
            IntPtr graph,
            IntPtr tail,
            IntPtr head,
            [MarshalAs(UnmanagedType.LPUTF8Str)]
            string? name,
            CreateFlag createflag);
        #endregion
    }
}
