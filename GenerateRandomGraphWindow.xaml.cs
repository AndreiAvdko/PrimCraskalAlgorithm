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
using System.Windows.Shapes;

namespace PrimCraskalAlgorithm
{
    /// <summary>
    /// Логика взаимодействия для GenerateRandomGraphWindow.xaml
    /// </summary>
    public partial class GenerateRandomGraphWindow : Window
    {
        public GenerateRandomGraphWindow()
        {
            InitializeComponent();
        }

        private void generateGraphButton_Click(object sender, RoutedEventArgs e)
        {
            int minVert;
            int maxVert;
            int minEdge;
            int maxEdge;
            int limitWeight;



            if (minVertexCount.Text == String.Empty || maxVertexCount.Text == String.Empty || 
                minEdgeCount.Text == String.Empty || maxEdgeCount.Text == String.Empty || 
                maxLimitOfEdgeWeight.Text == String.Empty)
            {
                MessageBox.Show("Все поля должны быть заполнены! ", "Предупреждение");
            }
            else
            {
                if (int.TryParse(minVertexCount.Text, out minVert) && 
                    int.TryParse(maxVertexCount.Text ,out maxVert) && 
                    int.TryParse(minEdgeCount.Text, out minEdge) && 
                    int.TryParse(maxEdgeCount.Text, out maxEdge) && 
                    int.TryParse(maxLimitOfEdgeWeight.Text, out limitWeight))
                {
                    if (maxVert < minVert || maxEdge < minEdge || minEdge < maxVert)
                    {
                        MessageBox.Show("Максимальные значения не могут быть меньше минимальных. " +
                            "Значение в поле МИНИМАЛЬНОЕ КОЛИЧЕСТВО РЕБЕР должно быть больше, чем в поле" +
                            "МАКСИМАЛЬНОЕ КОЛИЧЕСТВО ВЕРШИН. ", "Предупреждение");
                    }
                    else
                    {
                        
                        

                    }
                }
                else
                {
                    MessageBox.Show("Проверьте правильность введённых данных ", "Предупреждение");
                }
            }
        }
    }
}
