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
            Code.Clear();
            Name.Clear();
            Time.Clear();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            N = Convert.ToInt32(N_input.Text);
            n_zn = Convert.ToDouble(n_input.Text);
            F_d = Convert.ToInt32(Fd_input.Text);
            List<double> time = new List<double>();
            List<double> countOfStank = new List<double>();
            foreach (Operation item in data.Items)
            {
                time.Add(item.Time);
                countOfStank.Add(Math.Round((N * item.Time) / (60 * F_d * n_zn), 3));
            }
            
            List<double> countOfPlaces = new List<double>();
            foreach (var item in countOfStank)
            {
                countOfPlaces.Add(Math.Ceiling(item));
            }
           
            List<double> n_zf = new List<double>();
            for (int i = 0; i < countOfStank.Count; i++)
            {
                n_zf.Add(Math.Round(countOfStank[i] / countOfPlaces[i], 3));
            }
            
            List<double> O = new List<double>();
            foreach (var item in n_zf)
            {
                O.Add(Math.Round(n_zn/item, 3));
            }
          
            List<double> O_pr = new List<double>();
            foreach (var item in O)
            {
                O_pr.Add(Math.Ceiling(item));
            }
      
            double Kzo = Math.Round(O_pr.Sum() / countOfPlaces.Sum(), 3);
            
            double n;
            if (Kzo == 1)
            {
                n = Math.Round((double)N * a / 255);
            } else
            {
                n = Math.Round((476 * n_zn * c) / (time.Sum() / countOfPlaces.Sum()));
            }
            
            List<Operation> operations = new List<Operation>();
            for(int i = 0; i < data.Items.Count; i++)
            {
                Operation item = (Operation)data.Items[i];
                operations.Add(new Operation(item.Code, item.Name, item.Time) { M_p = countOfStank[i], P = countOfPlaces[i], N_zf = n_zf[i], O = O[i], O_pr = O_pr[i] });
            }
            Result res = new Result(this, operations, Kzo, n);
            res.Activate();
            res.Show();
        }
    }
}
