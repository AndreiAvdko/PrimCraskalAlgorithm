using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Msagl.Drawing;


namespace PrimCraskalAlgorithm
{
    internal class DrawGraph
    {
        Graph graph;


        //public DrawGraph()
        //{
        //    graph = new Graph();
        //}

        public DrawGraph(ownGraph owngraph)
        {
            graph = new Graph();
            foreach (Edge i in owngraph.edges)
            {
                graph.AddEdge(i.firstVertex.ToString(), i.weight.ToString(), i.secondVertex.ToString());
                graph.FindNode(i.firstVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
                graph.FindNode(i.secondVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
            }
            //graph.AddEdge("Box", "House");
            //graph.AddEdge("House", "InvHouse");
            //graph.AddEdge("InvHouse", "Diamond");
            //graph.AddEdge("Diamond", "Octagon");
            //graph.AddEdge("Octagon", "Hexagon");
            //graph.AddEdge("Hexagon", "2 Circle");
            //graph.AddEdge("2 Circle", "Box");

            //graph.FindNode("Box").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
            //graph.FindNode("House").Attr.Shape = Microsoft.Msagl.Drawing.Shape.House;
            //graph.FindNode("InvHouse").Attr.Shape = Microsoft.Msagl.Drawing.Shape.InvHouse;
            //graph.FindNode("Diamond").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //graph.FindNode("Octagon").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Octagon;
            //graph.FindNode("Hexagon").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Hexagon;
            //graph.FindNode("2 Circle").Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;

            this.graph.Attr.LayerDirection = LayerDirection.LR;
            foreach (var item in this.graph.Edges)
            {
                item.Attr.Color = Microsoft.Msagl.Drawing.Color.Bisque;
                item.Attr.ArrowheadAtTarget = ArrowStyle.None;
            }
        }

        public DrawGraph(ownGraph owngraph, MinimalSpanTree minspantree)
        {
            graph = new Graph();
            foreach (Edge i in owngraph.edges)
            {
                if (minspantree.edges.Contains(i))
                {
                    graph.AddEdge(i.firstVertex.ToString(), i.weight.ToString(), i.secondVertex.ToString());

                    graph.FindNode(i.firstVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
                    graph.FindNode(i.secondVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
                }
                else
                {

                    //Microsoft.Msagl.Drawing.Edge temp = new Microsoft.Msagl.Drawing.Edge(i.firstVertex.ToString(), i.weight.ToString(), i.secondVertex.ToString());
                    //temp.Attr.Color = Microsoft.Msagl.Drawing.Color.White;
                    //graph.AddPrecalculatedEdge(temp);
                    //graph.FindNode(i.firstVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
                    //graph.FindNode(i.secondVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
                    graph.AddEdge(i.firstVertex.ToString(), i.weight.ToString(), i.secondVertex.ToString());


                    graph.FindNode(i.firstVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
                    graph.FindNode(i.secondVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;

                }

            }


            foreach (var item in graph.Edges)
            {
                item.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
                item.Attr.ArrowheadAtTarget = ArrowStyle.None;
            }

            foreach (var p in graph.Edges)
            {
                foreach (var edge in owngraph.edges)
                {
                    if (!minspantree.edges.Contains(edge))
                    {
                        if (p.Target.ToString() == edge.secondVertex.ToString())
                        {
                            if (p.Source.ToString() == edge.firstVertex.ToString())
                            {
                                if (p.LabelText.ToString() == edge.weight.ToString())
                                {
                                    p.Attr.Color = Microsoft.Msagl.Drawing.Color.Bisque;
                                    // Удалить комментарий, чтобы сделать рёбра не принадлежащие мин ост дереву бесцветными 
                                    // p.Attr.Color = Microsoft.Msagl.Drawing.Color.Transparent;
                                    p.Label = null;
                                }
                            }
                        }
                    }
                }
            }


            graph.Attr.LayerDirection = LayerDirection.LR;
        }




        // Возвращает хранимый экземпляр для отрисовки графа
        public Graph drawGraph()
        {
            return this.graph;
        }
    }
}
