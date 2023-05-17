// See https://aka.ms/new-console-template for more information
using GraphViz.Net;

namespace TestApp
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            using(var context = new GvContext())
            using(var graph = new Graph("Test", GraphType.Directed))
            {
                var root = graph.FindOrCreateNode("Root");
                var a = graph.FindOrCreateNode("A");
                var b = graph.FindOrCreateNode("B");
                graph.FindOrCreateEdge(root, a);
                graph.FindOrCreateEdge(root, b);
                var data = context.RenderSVG(graph);   
            }
        }
    }
}