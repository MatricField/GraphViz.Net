using GraphViz.Net.PInvoke;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net
{
    public class Graph:
        NativeHandle<IntPtr>
    {
        #region Fields
        protected readonly IntPtr pGraph;
        #endregion
        public Graph(string name, GraphType type)
        {
            pGraph = type switch
            {
                GraphType.Directed => CGraph.agopen(name, Globals.GraphDescriptors.Directed),
                GraphType.Undirected => CGraph.agopen(name, Globals.GraphDescriptors.Undirected),
                GraphType.StrictDirected => CGraph.agopen(name, Globals.GraphDescriptors.StrictDirected),
                GraphType.StrictUndirected => CGraph.agopen(name, Globals.GraphDescriptors.StrictUndirected),
                _ => throw new InvalidOperationException()
            };
        }
        public Node FindOrCreateNode(string name)
        {
            var pNode = CGraph.agnode(pGraph, name, CreateFlag.Create);
            return pNode switch
            {
                0 => throw new InvalidOperationException(),
                _ => new Node(pNode)
            };
        }
        public Node? FindNode(string name)
        {
            var pNode = CGraph.agnode(pGraph, name, CreateFlag.Default);
            return pNode switch
            {
                0 => null,
                _ => new Node(pNode)
            };
        }
        public Edge FindOrCreateEdge(Node tail, Node head, string? name = null)
        {
            var pEdge = CGraph.agedge(pGraph, tail: tail._pNode, head: head._pNode, name, CreateFlag.Create);
            return pEdge switch
            {
                0 => throw new InvalidOperationException(),
                _ => new Edge(pEdge)
            };
        }
        public Edge? FindEdge(Node tail, Node head, string? name = null)
        {
            var pEdge = CGraph.agedge(pGraph, tail: tail._pNode, head: head._pNode, name, CreateFlag.Default);
            return pEdge switch
            {
                0 => null,
                IntPtr nonNull => new Edge(nonNull)
            };
        }
        #region NativeHandle
        internal override IntPtr Handle => pGraph;
        protected override void FreeNativeResources()
        {
            CGraph.agclose(pGraph);
        }
        #endregion
    }
}
