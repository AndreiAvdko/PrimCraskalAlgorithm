using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimCraskalAlgorithm
{

    // Класс представляющий ребро графа
    internal class Edge
    {
        public int firstVertex;
        public int secondVertex;
        public int weight;

        public Edge(int firstVertex, int secondVertex, int weight)
        {
            this.firstVertex = firstVertex;
            this.secondVertex = secondVertex;
            this.weight = weight;
        }
    }
}
