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
using PolynomialCurveFitting;

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

            WpfPlot2.Plot.XLabel("x");
            WpfPlot2.Plot.YLabel("y");

            WpfPlot2.Refresh();
        }


        private void TestDemo()
        {
            double[] X = { 0
,0.0634665
,0.126933
,0.1904
,0.253866
,0.317333
,0.380799
,0.444266
,0.507732
,0.571199
,0.634665
,0.698132
,0.761598
,0.825065
,0.888531
,0.951998
,1.01546
,1.07893
,1.1424
,1.20586
,1.26933
,1.3328
,1.39626
,1.45973
,1.5232
,1.58666
,1.65013
,1.7136
,1.77706
,1.84053
,1.904
,1.96746
,2.03093
,2.0944
,2.15786
,2.22133
,2.28479
,2.34826
,2.41173
,2.47519
,2.53866
,2.60213
,2.66559
,2.72906
,2.79253
,2.85599
,2.91946
,2.98293
,3.04639
,3.10986
,3.17333
,3.23679
,3.30026
,3.36373
,3.42719
,3.49066
,3.55413
,3.61759
,3.68106
,3.74452
,3.80799
,3.87146
,3.93492
,3.99839
,4.06186
,4.12532
,4.18879
,4.25226
,4.31572
,4.37919
,4.44266
,4.50612
,4.56959
,4.63306
,4.69652
,4.75999
,4.82346
,4.88692
,4.95039
,5.01385
,5.07732
,5.14079
,5.20425
,5.26772
,5.33119
,5.39465
,5.45812
,5.52159
,5.58505
,5.64852
,5.71199
,5.77545
,5.83892
,5.90239
,5.96585
,6.02932
,6.09279
,6.15625
,6.21972
,6.28319 };
            double[] Y1 = { 1.93471
,5.06067
,3.67249
,1.76917
,6.34982
,3.91372
,5.96029
,5.98911
,2.99992
,3.99261
,4.46726
,4.42409
,2.36349
,5.28603
,2.19238
,2.08341
,3.9601
,2.32357
,4.67505
,4.01589
,1.34753
,2.67149
,1.48938
,1.80283
,1.11353
,0.923215
,0.233591
,2.54638
,3.36328
,1.68594
,2.51597
,1.85492
,-0.795763
,2.56529
,2.93933
,-0.67249
,1.73083
,2.65018
,0.586278
,0.0397071
,-0.489111
,-1.49992
,-0.992608
,-0.467256
,-0.424088
,0.136506
,-1.28603
,-1.19238
,-0.0834113
,2.5399
,2.17643
,0.82495
,-0.0158891
,2.65247
,2.82851
,4.01062
,1.19717
,0.386465
,4.57678
,4.26641
,3.45362
,3.13672
,0.814061
,1.98403
,5.14508
,4.29576
,1.43471
,2.56067
,3.67249
,5.76917
,4.84982
,4.41372
,1.96029
,6.48911
,1.99992
,1.99261
,4.96726
,2.42409
,3.36349
,5.78603
,6.19238
,3.08341
,3.4601
,3.32357
,4.17505
,1.01589
,3.84753
,3.67149
,0.989375
,4.30283
,2.11353
,4.42322
,2.73359
,1.04638
,2.86328
,3.18594
,3.01597
,-0.14508
,3.20424
,-0.934712 };
            int order= int.Parse(txt_Order.Text.ToString());
            double[] args = LeastSquares.MultiLine(X, Y1, X.Length, order);

            WpfPlot2.Plot.Clear();
            WpfPlot2.Plot.AddScatter(X, Y1);

            double[] Xs = new double[1000];
            double[] Ys = new double[1000];
            Xs[0] = X[0];
            Ys[0] = getYvalue(Xs[0], args);
            double step = (max(X) - min(X)) / 1000;

            for (int i = 1; i < 1000; i++)
            {
                Xs[i] = Xs[i - 1] + step;
                Ys[i] = getYvalue(Xs[i], args);
            }
            WpfPlot2.Plot.AddScatter(Xs, Ys);
            WpfPlot2.Refresh();

            string param =null;
            for (int i = 0; i < args.Length; i++)
            {
                param += args[i] + " ";
            }
            txt_params.Text = param;
        }

        private double max(double[] arr)
        {
            double maxValue = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                maxValue = maxValue > arr[i] ? maxValue : arr[i];
            }
            return maxValue;
        }

        private double min(double[] arr)
        {
            double minValue = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                minValue = minValue < arr[i] ? minValue : arr[i];
            }
            return minValue;
        }

        private double getYvalue(double x, double[] args)
        {
            double y = args[0];
            double xPower = 1;
            for (int i = 1; i < args.Length; i++)
            {
                xPower *= x;
                y += args[i] * xPower;
            }
            return y;
        }

        private void btn_InoutData(object sender, RoutedEventArgs e)
        {

        }

        private void btn_ClearShowTable(object sender, RoutedEventArgs e)
        {
            WpfPlot2.Plot.Clear();
            WpfPlot2.Refresh();
            txt_Order.Text = 1 + "";
            txt_params.Text = "";
            Slider_Order.Value = 1;
        }

        private void btn_ClearLoadedData(object sender, RoutedEventArgs e)
        {
            WpfPlot2.Plot.Clear();
            WpfPlot2.Refresh();
            txt_Order.Text = 1 + "";
            txt_params.Text = "";
            Slider_Order.Value = 1;
        }

        private void btn_FittingCurve(object sender, RoutedEventArgs e)
        {
            TestDemo();
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
    }
}
