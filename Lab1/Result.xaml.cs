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

namespace Lab1
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {
        MainWindow win;
        public Result(MainWindow win, List<Operation> operations, double kzo, double n)
        {
            InitializeComponent();
            this.win = win;
            foreach (var item in operations)
            {
                data.Items.Add(item);
            }
            string type = "";
            if (kzo == 1)
            {
                type = "Массовый тип производства";
            }
            else if (kzo > 1 && kzo <= 10)
            {
                type = "Крупно-серийный тип производства";
            }
            else if (kzo > 10 && kzo <= 20)
            {
                type = "Средне-серийный тип производства";
            }
            else if (kzo > 20 && kzo <= 40)
            {
                type = "Мелко-серийный тип производства";
            }
            else
            {
                type = "Единичный тип производства";
            }
            result.Text += "\nКз.о. = " + kzo;
            result.Text += "\n" + type;
            result.Text += "\nОбьем выпуска: " + n;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            win.data.Items.Clear();
            this.Close();
        }
    }
}
