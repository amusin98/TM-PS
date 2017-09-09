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

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int N = 1000;
        int F_d = 2016;
        double n_zn = 0.8;
        int a = 3;
        int c = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Operation oper = new Operation(Code.Text, Name.Text, Convert.ToDouble(Time.Text));
            data.Items.Add(oper);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<double> time = new List<double>();
            List<double> countOfStank = new List<double>();
            foreach (Operation item in data.Items)
            {
                time.Add(item.Time);
                countOfStank.Add((N * item.Time) / (60 * F_d * n_zn));
            }
            MessageBox.Show("Mp");
            countOfStank.ForEach(x => MessageBox.Show(x.ToString()));
            List<double> countOfPlaces = new List<double>();
            foreach (var item in countOfStank)
            {
                countOfPlaces.Add(Math.Ceiling(item));
            }
            MessageBox.Show("P");
            countOfPlaces.ForEach(x => MessageBox.Show(x.ToString()));
            List<double> n_zf = new List<double>();
            for (int i = 0; i < countOfStank.Count; i++)
            {
                n_zf.Add(countOfStank[i] / countOfPlaces[i]);
            }
            MessageBox.Show("N_zf");
            n_zf.ForEach(x => MessageBox.Show(x.ToString()));
            List<double> O = new List<double>();
            foreach (var item in n_zf)
            {
                O.Add(n_zn/item);
            }
            MessageBox.Show("O");
            O.ForEach(x => MessageBox.Show(x.ToString()));
            List<double> O_pr = new List<double>();
            foreach (var item in O)
            {
                O_pr.Add(Math.Ceiling(item));
            }
            MessageBox.Show("O_pr");
            O_pr.ForEach(x => MessageBox.Show(x.ToString()));
            double Kzo = O_pr.Sum() / countOfPlaces.Sum();
            MessageBox.Show("Kzo: " + Kzo);
            double n;
            if (Kzo == 1)
            {
                n = N * a / 255;
            } else
            {
                n = (476 * 0.8 * c) / (time.Sum() / countOfPlaces.Sum());
            }
            MessageBox.Show("n: " + n);
            if(Kzo == 1)
            {
                MessageBox.Show("Массовый тип производства");
            } else if (Kzo > 1 && Kzo <= 10)
            {
                MessageBox.Show("Крупно-серийный тип производства");
            } else if (Kzo > 10 && Kzo <= 20)
            {
                MessageBox.Show("Средне-серийный тип производства");
            } else if (Kzo > 20 && Kzo <= 40)
            {
                MessageBox.Show("Мелко-серийный тип производства");
            } else
            {
                MessageBox.Show("Единичный тип производства");
            }
            
        }
    }
}
