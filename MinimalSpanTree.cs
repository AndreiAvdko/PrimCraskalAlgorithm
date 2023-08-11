using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimCraskalAlgorithm
{
    internal class MinimalSpanTree
    {
        public List<Edge> edges;
        private DateTime startTime;
        private DateTime finalTime;
        public SortedSet<int> vertex;


        private MinimalSpanTree()
        {
            this.edges = new List<Edge>();
            this.vertex = new SortedSet<int>();
        }

        public MinimalSpanTree(ownGraph graph, bool choiceKraskalPirmAlgorithm)
        {
            this.edges = new List<Edge>();
            this.vertex = new SortedSet<int>();
            foreach (Edge edge in graph.edges)
            {
                this.vertex.Add(edge.firstVertex);
                this.vertex.Add(edge.secondVertex);
            }
            this.startTime = DateTime.Now;
            if (choiceKraskalPirmAlgorithm)
            {
                this.edges = findMinSpanTreeKrask(graph, this.vertex);
            }
            else
            {
                this.edges = findMinSpanTreePrim(graph);
            }
            this.finalTime = DateTime.Now;
        }

        public static List<Edge> findMinSpanTreeKrask(ownGraph graph, SortedSet<int> minSpanTreeVertex)
        {
            Console.WriteLine("Запускаем алгоритм Краскала");
            List<Edge> minSpanTreeEdges = new List<Edge>();
            // Отсортировать рёбра
            // Выбрать ребро с наименьшим весом и проверить не создает ли оно цикла
            // Если цикла нет, то добавить его к минимальному остовному дереву
            // Если цикл есть --- перейти к следующему ребру



            // Сортируем рёбра графа по весу
            List<Edge> sortedEdges = new List<Edge>();
            sortedEdges = graph.edges.OrderBy(e => e.weight).ToList();

            Console.WriteLine("Отсортированные ребра ");
            foreach (var e in sortedEdges)
            {
                Console.Write("ребро, вес " + " " + e.weight + " ");
                Console.WriteLine(e.firstVertex + "  " + e.secondVertex);
            }

            int[,] connectivityComponents = new int[minSpanTreeVertex.Count, minSpanTreeVertex.Count];

            for (int i = 0; i < minSpanTreeVertex.Count; i++)
            {
                connectivityComponents[i, i] = 1;
            }

            foreach (Edge edge in sortedEdges)
            {
                Console.WriteLine("Пытаемся присоединить ребро " + edge.firstVertex + "->" + edge.secondVertex);
                if (minSpanTreeEdges.Count == 0)
                {
                    // Присоединяем ребро
                    minSpanTreeEdges.Add(edge);
                    Console.WriteLine("Присоединяем ребро " + edge.firstVertex + "->" + edge.secondVertex);

                    connectivityComponents[edge.firstVertex - 1, edge.secondVertex - 1] = 1;
                    for (int i = 0; i < connectivityComponents.GetLength(1); i++)
                    {
                        connectivityComponents[edge.secondVertex - 1, i] = 3;
                    }

                    // Закомментировать
                    for (int j = 0; j < connectivityComponents.GetLength(0); j++)
                    {
                        for (int k = 0; k < connectivityComponents.GetLength(1); k++)
                        {
                            Console.Write(connectivityComponents[j, k] + " ");
                        }
                        Console.WriteLine("\n");
                    }


                    int[,] tempArray = new int[connectivityComponents.GetLength(0) - 1, minSpanTreeVertex.Count];
                    bool verification = false;

                    for (int i = 0; i < connectivityComponents.GetLength(0); i++)
                    {
                        if (connectivityComponents[i, 0] != 3 && !verification)
                        {
                            for (int j = 0; j < connectivityComponents.GetLength(1); j++)
                            {
                                tempArray[i, j] = (int)connectivityComponents[i, j];
                            }
                        }
                        if (verification == true)
                        {
                            for (int j = 0; j < connectivityComponents.GetLength(1); j++)
                            {
                                tempArray[i - 1, j] = (int)connectivityComponents[i, j];
                            }
                        }
                        if (connectivityComponents[i, 0] == 3)
                        {
                            verification = true;
                        }
                    }

                    connectivityComponents = tempArray;
                    tempArray = null;

                    // Закомментировать
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    for (int j = 0; j < connectivityComponents.GetLength(0); j++)
                    {
                        for (int k = 0; k < connectivityComponents.GetLength(1); k++)
                        {
                            Console.Write(connectivityComponents[j, k] + " ");
                        }
                        Console.WriteLine("\n");
                    }
                        //for (int i = 0; i < minSpanTreeVertex.Count; i++)
                        //{
                        //    // Симметричное заполнение матрицы
                        //    if (connectivityComponents[edge.firstVertex - 1, i] == 1 || connectivityComponents[edge.secondVertex - 1, i] == 1)
                        //    {
                        //        connectivityComponents[edge.firstVertex - 1, i] = 1;
                        //        connectivityComponents[edge.secondVertex - 1, i] = 1;
                        //    }


                        //    //
                        //    if (connectivityComponents[edge.firstVertex - 1, i] == 1 || connectivityComponents[edge.secondVertex - 1, i] == 1)
                        //    {
                        //        connectivityComponents[]
                        //    }

                        //}
                        //// Закомментировать
                        //for (int j = 0; j < connectivityComponents.GetLength(0); j++)
                        //{
                        //    for (int k = 0; k < connectivityComponents.GetLength(1); k++)
                        //    {
                        //        Console.Write(connectivityComponents[j, k] + " ");
                        //    }
                        //    Console.WriteLine("\n");
                        //}
                        ///

                    
                }
                else
                {
                    // переменная разрешающая добавление ребра
                    bool addFlag = true;
                    for (int i = 0; i < connectivityComponents.GetLength(0); i++)
                    {
                        if (connectivityComponents[i, edge.firstVertex - 1] == 1 && connectivityComponents[i, edge.secondVertex - 1] == 1)
                        {
                            addFlag = false;
                        }
                    }
                    if (addFlag)
                    {
                        minSpanTreeEdges.Add(edge);
                        Console.WriteLine("Присоединяем ребро " + edge.firstVertex + "->" + edge.secondVertex);

                        int firstRow = 10000;
                        int secondRow = 10000;
                        for (int i = 0; i < connectivityComponents.GetLength(0); i++)
                        {
                            if (connectivityComponents[i, edge.firstVertex - 1] == 1)
                            {
                                firstRow = i;
                            }
                            if (connectivityComponents[i, edge.secondVertex - 1] == 1)
                            {
                                secondRow = i;
                            }
                        }



                        for (int i = 0; i < connectivityComponents.GetLength(1); i++)
                        {
                            if (connectivityComponents[firstRow, i] == 0)
                            {
                                connectivityComponents[firstRow, i] = connectivityComponents[secondRow, i];
                            }
                        }
                        connectivityComponents[firstRow, edge.secondVertex - 1] = 1;
                        for (int i = 0; i < connectivityComponents.GetLength(1); i++)
                        {
                            connectivityComponents[secondRow, i] = 3;
                        }

                        // Закомментировать
                        for (int j = 0; j < connectivityComponents.GetLength(0); j++)
                        {
                            for (int k = 0; k < connectivityComponents.GetLength(1); k++)
                            {
                                Console.Write(connectivityComponents[j, k] + " ");
                            }
                            Console.WriteLine("\n");
                        }


                        int[,] tempArray = new int[connectivityComponents.GetLength(0) - 1, minSpanTreeVertex.Count];
                        bool verification = false;

                        for (int i = 0; i < connectivityComponents.GetLength(0); i++)
                        {
                            if (connectivityComponents[i, 0] != 3 && !verification)
                            {
                                for (int j = 0; j < connectivityComponents.GetLength(1); j++)
                                {
                                    tempArray[i, j] = (int)connectivityComponents[i, j];
                                }
                            }
                            if (verification == true)
                            {
                                for (int j = 0; j < connectivityComponents.GetLength(1); j++)
                                {
                                    tempArray[i - 1, j] = (int)connectivityComponents[i, j];
                                }
                            }
                            if (connectivityComponents[i, 0] == 3)
                            {
                                verification = true;
                            }
                        }

                        connectivityComponents = tempArray;
                        tempArray = null;

                        // Закомментировать
                        Console.WriteLine("\n");
                        Console.WriteLine("\n");
                        for (int j = 0; j < connectivityComponents.GetLength(0); j++)
                        {
                            for (int k = 0; k < connectivityComponents.GetLength(1); k++)
                            {
                                Console.Write(connectivityComponents[j, k] + " ");
                            }
                            Console.WriteLine("\n");
                        }
                    }



                    //// переменная разрешающая добавление ребра
                    //bool addFlag = true;

                    //for (int i = 0; i < connectivityComponents.GetLength(1); i++)
                    //{
                    //    if ((connectivityComponents[i, edge.firstVertex - 1] == 1) && (connectivityComponents[i, edge.secondVertex - 1] == 1))
                    //    {
                    //        Console.WriteLine("Запрещаем присоединение ребра " + edge.firstVertex + "->" + edge.secondVertex);
                    //        addFlag = false;
                    //    }
                    //}
                    //if (addFlag)
                    //{
                    //    Console.WriteLine("Присоединяем ребро " + edge.firstVertex + "->" + edge.secondVertex);


                    //    minSpanTreeEdges.Add(edge);
                    //    // int[,] tempConComp = new int[connectivityComponents.GetLength(1) - 1, connectivityComponents.GetLength(2)];
                    //    for (int i = 0; i < minSpanTreeVertex.Count; i++)
                    //    {
                    //        if (connectivityComponents[edge.firstVertex - 1, i] == 1 || connectivityComponents[edge.secondVertex - 1, i] == 1)
                    //        {
                    //            connectivityComponents[edge.firstVertex - 1, i] = 1;
                    //            // connectivityComponents[edge.secondVertex - 1, i] = 0;


                    //            connectivityComponents[edge.secondVertex - 1, i] = 1;



                    //            // tempConComp[edge.firstVertex, i] = 1;
                    //        }
                    //    }


                    //    // Закомментировать
                    //    for (int j = 0; j < connectivityComponents.GetLength(0); j++)
                    //    {
                    //        for (int k = 0; k < connectivityComponents.GetLength(1); k++)
                    //        {
                    //            Console.Write(connectivityComponents[j, k] + " ");
                    //        }
                    //        Console.WriteLine("\n");
                    //    }
                    //}
                }
            }

            

            return minSpanTreeEdges;
        }

        
        


        public static List<Edge> findMinSpanTreePrim(ownGraph graph)
        {

            // Сначала берётся произвольная вершина и находится ребро,
            // инцидентное данной вершине и обладающее наименьшей стоимостью.
            // Найденное ребро и соединяемые им две вершины образуют дерево.
            // Затем, рассматриваются рёбра графа, один конец которых — уже принадлежащая дереву вершина,
            // а другой — нет;
            // из этих рёбер выбирается ребро наименьшей стоимости.
            // Выбираемое на каждом шаге ребро присоединяется к дереву.
            // Рост дерева происходит до тех пор, пока не будут исчерпаны все вершины исходного графа.
            Console.WriteLine("Запускаем алгоритм Прима");
            List<Edge> minSpanTreeEdges = new List<Edge>();

            List<Edge> edgesOrigingraph = new List<Edge>(graph.edges);
            // edgesOrigingraph = graph.edges;


            Console.WriteLine("Список всех рёбер");
            foreach (var item in edgesOrigingraph)
            {
                Console.WriteLine("Ребро " + item.firstVertex + " -> " + item.secondVertex + " с весом " + item.weight);
            }

            SortedSet<int> allVertexes = new SortedSet<int>();
            
            foreach (Edge edge in graph.edges)
            {
                allVertexes.Add(edge.firstVertex);
                allVertexes.Add(edge.secondVertex);
            }

            Console.WriteLine("Список всех вершин:");
            foreach (var item in allVertexes)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            // Количество вершин в графе
            int countOfVertex = allVertexes.Count;

            // Список добавленных вершин
            SortedSet<int> addedVertex = new SortedSet<int>();
            
           
            
            int tempfirstVertex = 0;
            int tempsecondVertex = 0;
            int tempWeigth = int.MaxValue;


            if (countOfVertex == allVertexes.Count)
            {
                // Выбираем случайную вершину
                 tempfirstVertex = (new Random()).Next(1, countOfVertex);
                // tempfirstVertex = 4;
                foreach (Edge edge in edgesOrigingraph)
                {
                    if (edge.firstVertex == tempfirstVertex)
                    {
                       // Console.WriteLine("Вершина " + tempfirstVertex + " смежна c " + edge.secondVertex);
                       if (edge.weight < tempWeigth)
                       {
                           tempWeigth = edge.weight;
                           tempsecondVertex = edge.secondVertex;
                       }
                     }
                    if (edge.secondVertex == tempfirstVertex)
                    {
                        // Console.WriteLine("Вершина " + tempfirstVertex + " смежна c " + edge.firstVertex);
                        if (edge.weight < tempWeigth)
                        {
                            tempWeigth = edge.weight;
                            tempsecondVertex = edge.firstVertex;
                        }
                    }
                }



                foreach (Edge edge in edgesOrigingraph)
                {
                    if (edge.firstVertex == tempfirstVertex && edge.secondVertex == tempsecondVertex && edge.weight == tempWeigth)
                    {
                        minSpanTreeEdges.Add(edge);
                    }
                    else
                    {
                        if (edge.firstVertex == tempsecondVertex && edge.secondVertex == tempfirstVertex && edge.weight == tempWeigth)
                        {
                            minSpanTreeEdges.Add(edge);
                        }
                        Console.WriteLine("Добавили ребро " + edge.firstVertex + " -> " + edge.secondVertex + " с весом " + edge.weight);
                    }
                }
                
                    
                    edgesOrigingraph.RemoveAll(edge => (edge.firstVertex == tempfirstVertex && edge.secondVertex == tempsecondVertex) ||
                                     (edge.firstVertex == tempsecondVertex && edge.secondVertex == tempfirstVertex));
                    
                    addedVertex.Add(tempfirstVertex);
                    addedVertex.Add(tempsecondVertex);
                    allVertexes.Remove(tempfirstVertex);
                    allVertexes.Remove(tempsecondVertex);

            }


            Console.WriteLine("Список всех рёбер");
            foreach (var item in edgesOrigingraph)
            {
                Console.WriteLine("Ребро " + item.firstVertex + " -> " + item.secondVertex + " с весом " + item.weight);
            }


            // Если не первый прогон цикла
            do
            {

                tempWeigth = int.MaxValue;
                tempsecondVertex = 0;
                foreach (int vertex in addedVertex)
                {
                    // tempfirstVertex = vertex;
                    
                    
                    foreach (Edge edge in edgesOrigingraph)
                    {
                        if (edge.firstVertex == vertex && !(addedVertex.Contains(edge.secondVertex)))
                        {
                            // Console.WriteLine("Вершина " + tempfirstVertex + " смежна c " + edge.secondVertex);
                            if (edge.weight < tempWeigth)
                            {
                                tempfirstVertex = vertex;
                                tempWeigth = edge.weight;
                                tempsecondVertex = edge.secondVertex;
                            }
                        }
                        if (edge.secondVertex == vertex && !(addedVertex.Contains(edge.firstVertex)))
                        {
                            // Console.WriteLine("Вершина " + tempfirstVertex + " смежна c " + edge.firstVertex);
                            if (edge.weight < tempWeigth)
                            {
                                tempfirstVertex = vertex;
                                tempWeigth = edge.weight;
                                tempsecondVertex = edge.firstVertex;
                            }
                        }
                    }
                }

                // Добавляем ребро
                if (tempWeigth != int.MaxValue || tempsecondVertex != 0)
                {



                        foreach (Edge edge in edgesOrigingraph)
                        {
                            if (edge.firstVertex == tempfirstVertex && edge.secondVertex == tempsecondVertex && edge.weight == tempWeigth)
                            {
                                minSpanTreeEdges.Add(edge);
                            }
                            else
                            {
                                if (edge.firstVertex == tempsecondVertex && edge.secondVertex == tempfirstVertex && edge.weight == tempWeigth)
                                {
                                    minSpanTreeEdges.Add(edge);
                                }
                                Console.WriteLine("Добавили ребро " + edge.firstVertex + " -> " + edge.secondVertex + " с весом " + edge.weight);
                            }
                        }   
                        //minSpanTreeEdges.Add(new Edge(tempfirstVertex, tempsecondVertex, tempWeigth));

                        // Console.WriteLine("Добавили ребро " + tempfirstVertex + " -> " + tempsecondVertex + " с весом " + tempWeigth);
                    
                    
                    edgesOrigingraph.RemoveAll(edge => (edge.firstVertex == tempfirstVertex && edge.secondVertex == tempsecondVertex) ||
                                              (edge.firstVertex == tempsecondVertex && edge.secondVertex == tempfirstVertex));
                    addedVertex.Add(tempfirstVertex);
                    addedVertex.Add(tempsecondVertex);
                    allVertexes.Remove(tempfirstVertex);
                    allVertexes.Remove(tempsecondVertex);


                    Console.WriteLine("Список всех рёбер");
                    foreach (var item in edgesOrigingraph)
                    {
                        Console.WriteLine("Ребро " + item.firstVertex + " -> " + item.secondVertex + " с весом " + item.weight);
                    }

                }
            }
            while (allVertexes.Count != 0);

            Console.WriteLine("Список всех ребер минимального остовного дерева");
            foreach (var item in minSpanTreeEdges)
            {
                Console.WriteLine("Ребро " + item.firstVertex + " -> " + item.secondVertex + " с весом " + item.weight);
            }
            return minSpanTreeEdges;    

        }

        public TimeSpan getTimeCompleteAlgoritm()
        {
            TimeSpan timeOfExecute = this.startTime - this.finalTime;
            return timeOfExecute;
        }

    }
}
