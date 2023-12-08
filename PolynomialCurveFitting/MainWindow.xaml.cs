using ScottPlot;
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

namespace PolynomialCurveFitting
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            // sample data
            double[] xs = DataGen.Consecutive(51);
            double[] sin = DataGen.Sin(51);

            // plot the data
            WpfPlot2.Plot.AddScatter(xs, sin);

            WpfPlot2.Plot.XLabel("x");
            WpfPlot2.Plot.YLabel("y");

            WpfPlot2.Refresh();
        }


        private void TestDemo()
        {

        }

        private void btn_InoutData(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ClearShowTable(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ClearLoadedData(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
