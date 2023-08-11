using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimCraskalAlgorithm
{
    static internal class GraphGenerator
    {


        // Генерация графа из файла
        public static List<Edge> generateFromFile(string filePath)
        {
            List<Edge> buildedEdges = new List<Edge>();
                foreach (string line in System.IO.File.ReadLines(filePath))
                {
                    // Определяем массив разделителей из файла, чтобы удалить пробелы
                    char[] charsToTrim = { ' ' };

                    string result = line.Trim(charsToTrim);
                    string[] words = result.Split(new char[] { ',', '-' });

                    int firstVertex = 0;
                    int secondVertex = 0;
                    int weight = 0;

                    for (int i = 0; i < words.Length; i++)
                    {
                        switch (i)
                        {
                            case 0: firstVertex = Int32.Parse(words[0]); break;
                            case 1: secondVertex = Int32.Parse(words[1]); break;
                            case 2: weight = Int32.Parse(words[2]); break;
                        }
                    }
                    Edge edge = new Edge(firstVertex, secondVertex, weight);
                    buildedEdges.Add(edge);
                }
            return buildedEdges;
        }

        // метод генерации случайного графа
        // возвращает список рёбер, сгенерированного графа
        public static List<Edge> generateRandomGraph()
        {
            List<Edge> buildedEdges = new List<Edge>();
            var rand = new Random();
            var vertexCount = rand.Next((int)GraphSettings.minVertexCount, (int)GraphSettings.maxVertexCounter);
            var edgesCount = rand.Next((int)GraphSettings.minEdgeCounter, (int)GraphSettings.maxEdgeCounter);

            // Создаем двумерный массив, для матрицы инцидентности и порождения графа
            // Строки вершины, столбцы ребра
            int[,] incidence_matrix = new int[vertexCount, edgesCount];
            
            for (int j = 0; j < edgesCount; j++)
            {
                // Инициализация двух случайных вершин, которым инцидентно ребро
                int first_tag_vertex = rand.Next(1, vertexCount);
                int second_tag_vertex;
                // Проверка на наличие петель
                do
                {
                    second_tag_vertex = rand.Next(1, vertexCount);
                } while (first_tag_vertex == second_tag_vertex);
                // Заполняем случайным значением веса ребро
                incidence_matrix[first_tag_vertex, j] = rand.Next(1, (int)GraphSettings.weightHighValue);
                // Такой же вес будет для второй инцидентной вершины
                incidence_matrix[second_tag_vertex, j] = incidence_matrix[first_tag_vertex, j];
                
                // Инициализируем новое ребро
                Edge edge = new Edge(first_tag_vertex, second_tag_vertex, incidence_matrix[second_tag_vertex, j]);
                // Добавляем ребро в список
                buildedEdges.Add(edge);

                //Console.WriteLine("Сгенерирован граф со следующей матрицей инцидентности");
                //for (int i = 0; i < incidence_matrix.GetLength(0); i++)
                //{
                //    Console.Write(i + 1 + "   ");
                //    for (int k = 0; k < incidence_matrix.GetLength(1); k++)
                //    {
                //        Console.Write(" {0:d4} ", incidence_matrix[i,k]);
                //    }
                //    Console.WriteLine();
                //}


            }



            // Проверяем на наличие изолированных вершин, для которых не сгенерировались ребра
            for (int i = 0; i < vertexCount; i++)
            {
                if (i != 0)
                {
                    int count = 0;
                    for (int k = 0; k < edgesCount; k++)
                    {
                        if (incidence_matrix[i, k] != 0)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {

                        Console.WriteLine("Пустая строка/вершина " + i);
                        int second_vertex;
                        do
                        {
                            second_vertex = new Random().Next(1, vertexCount);
                        } while (second_vertex == i);
                        Edge edge = new Edge(i, second_vertex, rand.Next(1, (int)GraphSettings.weightHighValue));
                        buildedEdges.Add(edge);
                        Console.WriteLine("Граф дополнен ребром  " + edge.firstVertex + " -> " + edge.secondVertex);
                    }
                }
                
            }
            //for (int i = 0; i < vertexCount; i++)
            //{
            //    for (int j = 0; j < edgesCount; j++)
            //    {
            //        Console.Write("{0, 5}", incidence_matrix[i,j] + " ");
            //    }
            //    Console.WriteLine();
            //}

            int counter = 0;
            //foreach (var item in buildedEdges)
            //{
            //    Console.Write(counter + "   ");
            //    Console.WriteLine(item.firstVertex + "  " + item.secondVertex);
            //    counter++;
            //}

            return buildedEdges;
        }
    }
}
