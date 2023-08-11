using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimCraskalAlgorithm
{

    // Класс представляющий граф
    internal class ownGraph
    {
        // Поле, хранящее список всех рёбер графа
        public List<Edge> edges;


        // Конструктор без параметров генерирует случайный граф
        public ownGraph()
        {
            this.edges = GraphGenerator.generateRandomGraph();
        }


        public ownGraph(List<Edge> edges)
        {
            this.edges = edges;
        }
        public ownGraph(string filePath)
        {
            this.edges = GraphGenerator.generateFromFile(filePath);
        }




        
        
    }
}
