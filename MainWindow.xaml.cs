using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Msagl.Drawing;

namespace PrimCraskalAlgorithm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ownGraph graphhs;

        private MinimalSpanTree minPrimGraph;
        private MinimalSpanTree minKraskalGraph;
        public MainWindow()
        {
            InitializeComponent();
            
            Loaded += MainWindow_Loaded;
            
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            Graph graph = new Graph();
            
            
             graphhs = new ownGraph();
            // graphhs = new ownGraph("graph1.TXT");



            //foreach (Edge i in graphhs.edges)
            //{
            //    graph.AddEdge(i.firstVertex.ToString(), i.weight.ToString() , i.secondVertex.ToString());
            //    graph.FindNode(i.firstVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
            //    graph.FindNode(i.secondVertex.ToString()).Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
            //}
            ////graph.AddEdge("Box", "House");
            ////graph.AddEdge("House", "InvHouse");
            ////graph.AddEdge("InvHouse", "Diamond");
            ////graph.AddEdge("Diamond", "Octagon");
            ////graph.AddEdge("Octagon", "Hexagon");
            ////graph.AddEdge("Hexagon", "2 Circle");
            ////graph.AddEdge("2 Circle", "Box");

            ////graph.FindNode("Box").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Box;
            ////graph.FindNode("House").Attr.Shape = Microsoft.Msagl.Drawing.Shape.House;
            ////graph.FindNode("InvHouse").Attr.Shape = Microsoft.Msagl.Drawing.Shape.InvHouse;
            ////graph.FindNode("Diamond").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            ////graph.FindNode("Octagon").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Octagon;
            ////graph.FindNode("Hexagon").Attr.Shape = Microsoft.Msagl.Drawing.Shape.Hexagon;
            ////graph.FindNode("2 Circle").Attr.Shape = Microsoft.Msagl.Drawing.Shape.DoubleCircle;

            //graph.Attr.LayerDirection = LayerDirection.LR;
            //foreach (var item in graph.Edges)
            //{
            //    item.Attr.Color = Microsoft.Msagl.Drawing.Color.Bisque;
            //    item.Attr.ArrowheadAtTarget = ArrowStyle.None;
            //}

            graphCraskal.Graph = new DrawGraph(graphhs).drawGraph();

            graphPrim.Graph = new DrawGraph(graphhs).drawGraph();
        }

        private void kraskAlgButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем объект для хранения минимального остовного дерева, найденного по алгоритму Краскала (true)
            //      MinimalSpanTree minGraph = new MinimalSpanTree(graphhs, true);
            // Создаем обект для хранения минимального остовного дерева, найденного по алгоритму Прима


            minKraskalGraph = new MinimalSpanTree(graphhs, true);

            graphCraskal.Graph = (new DrawGraph(graphhs, minKraskalGraph)).drawGraph();

            // Удаление первого символа "Для форматирования вывода"
            timeKraskalAlgoritm.Content = minKraskalGraph.getTimeCompleteAlgoritm().ToString().Remove(0,1);
            timeKraskalAlgoritm.FontSize = 14;
            returnToOrighKrask.Background = Brushes.Green;
        }
        private void primAlgButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем объект для хранения минимального остовного дерева, найденного по алгоритму Краскала (true)
            // MinimalSpanTree minGraph = new MinimalSpanTree(graphhs, true);
            // Создаем обект для хранения минимального остовного дерева, найденного по алгоритму Прима


            minPrimGraph = new MinimalSpanTree(graphhs, false);
            graphPrim.Graph = (new DrawGraph(graphhs, minPrimGraph)).drawGraph();

            // Удаление первого символа "Для форматирования вывода"
            timePrimAlgoritm.Content = minPrimGraph.getTimeCompleteAlgoritm().ToString().Remove(0, 1);
            timePrimAlgoritm.FontSize = 14;
            returnToOrighPrim.Background = Brushes.Green;
        }

        private void returnToOrighPrim_Click(object sender, RoutedEventArgs e)
        {
            // Написать функцию для отрисовки графа
            graphPrim.Graph = new DrawGraph(graphhs).drawGraph();
            returnToOrighPrim.Background = Brushes.LightGray;
        }

        private void returnToOrighKrask_Click(object sender, RoutedEventArgs e)
        {
            // Написать функцию для отрисовки графа
            graphCraskal.Graph = new DrawGraph(graphhs).drawGraph();
            returnToOrighKrask.Background = Brushes.LightGray;
        }

        private void ProgramInfo_Click (object sender, RoutedEventArgs e)
        {
            InfoAboutProgram window = new InfoAboutProgram();
            window.Show();
        }

        // Кнопка добавления графа из файла (в верхнем меню)
        private void addGraphFromFile_Click(object sender, RoutedEventArgs e)
        {
            AddGraphFromFileWindow addGraphFromFileWindow = new AddGraphFromFileWindow();
            addGraphFromFileWindow.Show();
        }

        private void generateNewGraph_Click (object sender, RoutedEventArgs e)
        {
            GenerateRandomGraphWindow generateRandomGraphWindow = new GenerateRandomGraphWindow();
            generateRandomGraphWindow.Show();
            graphhs = new ownGraph();
            graphCraskal.Graph = new DrawGraph(graphhs).drawGraph();
            graphPrim.Graph = new DrawGraph(graphhs).drawGraph();
        }

        // Сменить цвет рёбер графа
        private void ChangeEdgeColor_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeBackgroundColor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
