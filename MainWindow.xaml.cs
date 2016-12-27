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
using System.IO;
using Microsoft.Win32;

namespace Rectangle_method
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public double a, b,result;
        public bool a_flag = false;
        public bool b_flag = false;
        public bool n_flag = false;
        public bool done_flag = false;
        public int n;
        public double x ;
        private void red_button_Click(object sender, RoutedEventArgs e)
        {
            if (n_flag == false)
            {
                tb_res.Text = tb_res.Text + "Генерация не проведена" + Environment.NewLine;
                return;
            }
            tb_res.Text = tb_res.Text + "А: " + a + Environment.NewLine;
            tb_res.Text = tb_res.Text + "B: " + b + Environment.NewLine;
            tb_res.Text = tb_res.Text + "N: " + n + Environment.NewLine;
            double function =Math.Sqrt(1+Math.Pow(x,4));
            double distance =Math.Abs(a - b);
            double step = distance / n;
            double y;result = 0;
            x = a;
            for (int i = 0; i < n-1; i++)
            {
                y = function*((x+step)-x);
                result = result + y;
                x = x + step;
            }
            tb_res.Text = tb_res.Text + "Результат: " + Convert.ToString(result) + Environment.NewLine;
            but_file_save.IsEnabled = true;
        }

        private void but_abn_reg_Click(object sender, RoutedEventArgs e)
        {
            if (tb_a.Text == "")
            {
                tb_res.Text = tb_res.Text + "Введите А" + Environment.NewLine;
                return;
            }
            if (tb_b.Text == "")
            {
                tb_res.Text = tb_res.Text + "Введите B" + Environment.NewLine;
                return;
            }
            if (tb_n.Text == "")
            {
                tb_res.Text = tb_res.Text + "Введите N" + Environment.NewLine;
                return;
            }
            if (double.TryParse(tb_a.Text, out a) == false)
            {
                tb_res.Text = tb_res.Text + "А не является допустимым числом" + Environment.NewLine;
                return;
            }
            else
            {
                a = Convert.ToDouble(tb_a.Text);
                a_flag = true;
            }
            if (double.TryParse(tb_b.Text, out b) == false)
            {
                tb_res.Text = tb_res.Text + "B не является допустимым числом" + Environment.NewLine;
                return;
            }
            else
            {
                b = Convert.ToDouble(tb_b.Text);
                b_flag = true;
            }
            if (int.TryParse(tb_n.Text, out n) == false)
            {
                tb_res.Text = tb_res.Text + "N не является допустимым числом" + Environment.NewLine;
                return;
            }
            else
            {
                n = Convert.ToInt16(tb_n.Text);
            n_flag = true;
            }
            if (n < 2)
            {
                tb_res.Text = tb_res.Text + "N < 2" + Environment.NewLine;
                return;
            }
            if (a > b)
            {
                tb_res.Text = tb_res.Text + "a > b" + Environment.NewLine;
                return;
            }
            tb_res.Text = tb_res.Text + "Значения зарегестрированны" + Environment.NewLine;
        }

        private void but_abn_gen_Click(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            a = 0;
            b = 0;
            n = 0;
            while (a == b)
            {
                a = rand.Next(0, 10);
                b = rand.Next(0, 10);
                if (a > b)
                {
                    a = rand.Next(0, 10);
                    b = rand.Next(0, 10);
                }
            }
            n = rand.Next(3, 10);
            tb_res.Text = tb_res.Text + "Генерация окончена... " + Environment.NewLine;
            tb_res.Text = tb_res.Text + "А: " + a + Environment.NewLine;
            tb_res.Text = tb_res.Text + "B: " + b + Environment.NewLine;
            tb_res.Text = tb_res.Text + "N: " + n + Environment.NewLine;
            n_flag = true;
        }

        private void but_file_read_Click(object sender, RoutedEventArgs e)
        {
            string[] arr_read;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            arr_read = File.ReadAllLines(ofd.FileName);
            string[] fd_res_string =arr_read[0].Split('|');
            a = Convert.ToDouble(fd_res_string[0]);
            b = Convert.ToDouble(fd_res_string[1]);
            n = Convert.ToInt16(fd_res_string[2]);
            tb_res.Text = tb_res.Text + "Чтение окончено... " + Environment.NewLine;
            tb_res.Text = tb_res.Text + "А: " + a + Environment.NewLine;
            tb_res.Text = tb_res.Text + "B: " + b + Environment.NewLine;
            tb_res.Text = tb_res.Text + "N: " + n + Environment.NewLine;
            n_flag = true;
        }

        private void but_file_save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.ShowDialog();
            string[] str_res = new string[1];
            str_res[0] = "Результат: "+Convert.ToString(result)+Environment.NewLine;
            File.WriteAllLines(sfd.FileName,str_res);
            tb_res.Text = tb_res.Text + "Запись завершена... " + Environment.NewLine;
        }
    }
}
