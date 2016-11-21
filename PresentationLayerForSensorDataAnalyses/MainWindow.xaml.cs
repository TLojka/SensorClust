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

namespace PresentationLayerForSensorDataAnalyses
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<KeyValuePair<int, double>> valueList;

        public MainWindow()
        {
            InitializeComponent();
            valueList = new List<KeyValuePair<int, double>>();

            //vypocet
            NeuralNetwork.Program program = new NeuralNetwork.Program();
            valueList = program.DetectFault(-1, 5, 3);

            showColumnChart();
        }

        

        private void showColumnChart()
        {

            //Setting data for line chart
            lineChart.DataContext = valueList;
            lineChart.Title = "List of Events";
            lineChart1.DataContext = NeuralNetwork.Program.LISTLikeHutFlow;
            lineChart1.Title = "Likehout";
            lineChart2.DataContext = NeuralNetwork.Program.LISTFlow;
            lineChart2.Title = "Sensor data flow";
         }

        private void Recount_Click(object sender, RoutedEventArgs e)
        {
            NeuralNetwork.Program program = new NeuralNetwork.Program();
            valueList = program.DetectFault(System.Convert.ToDouble(H1.Text), System.Convert.ToDouble(H2.Text), 150);

            showColumnChart();
        }
    }


    public class ShoppingCart : DependencyObject
    {
        public int ItemCount
        {
            get { return (int)GetValue(ItemCountProperty); }
            set { SetValue(ItemCountProperty, value); }
        }

        public static readonly DependencyProperty ItemCountProperty =
             DependencyProperty.Register("ItemCount", typeof(int),
             typeof(ShoppingCart), new PropertyMetadata(0));
    }
}
