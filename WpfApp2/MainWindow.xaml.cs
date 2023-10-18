using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void grid_mouse_down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btn_change_size(object sender, RoutedEventArgs e)
        {
            if (WindowState != WindowState.Maximized)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            list.Content += ("1");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            list.Content += ("2");

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            list.Content += "3";

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            list.Content += "4";

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            list.Content += "5";

        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            list.Content += "6";

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            list.Content += "7";

        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            list.Content += "8";

        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            list.Content += "9";

        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            list.Content += "0";

        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            list.Content += ".";

        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            list.Content += "+";

        }

        private void Button_Click_13(object sender, RoutedEventArgs e)
        {
            list.Content += "-";

        }

        private void Button_Click_14(object sender, RoutedEventArgs e)
        {
            list.Content += "*";

        }

        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            list.Content += "/";

        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            if (list.Content.ToString().Length != 0)
                list.Content = list.Content.ToString().Substring(0, list.Content.ToString().Length - 1);

        }
        private void CalculateResult()
        {
            List<int> X = new();
            List<int> divide = new();
            List<string> nums = new();
            string temp = default;
            foreach (var item in list.Content.ToString())
            {
                bool check = true;
                try
                {
                    Convert.ToDouble(item.ToString());
                    check = true;
                }
                catch (Exception)
                {
                    if (item.ToString() != ".")
                        check = false;
                }
                if (check)
                {
                    temp += item.ToString();
                }
                else
                {
                    nums.Add(temp);
                    nums.Add(item.ToString());
                    temp = default;
                }
            }
            nums.Add(temp);
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == "*")
                {
                    var num = Convert.ToDouble(nums[i - 1]) * Convert.ToDouble(nums[i + 1]);
                    nums.Insert(i - 1, num.ToString());
                    nums.RemoveRange(i, 3);
                    i--;
                }
                if (nums[i] == "/")
                {
                    var num = Convert.ToDouble(nums[i - 1]) / Convert.ToDouble(nums[i + 1]);
                    nums.Insert(i - 1, num.ToString());
                    nums.RemoveRange(i, 3);
                }
            }
            double result = default;
            for (int i = 0; i < nums.Count; i++)
            {

                switch (nums[i])
                {
                    case "+":
                        if (i == 1)
                            result = Convert.ToDouble(nums[i - 1]) + Convert.ToDouble(nums[i + 1]);
                        else
                            result += Convert.ToDouble(nums[i + 1]);
                        break;
                    case "-":
                        if (i == 1)
                            result = Convert.ToDouble(nums[i - 1]) - Convert.ToDouble(nums[i + 1]);
                        else
                            result -= Convert.ToDouble(nums[i + 1]);
                        break;
                }

            }
            lbl_result.Content = Math.Round(result, 1).ToString();
            if (nums.Count == 1)
                lbl_result.Content = Math.Round(Convert.ToDouble(nums[0]), 1).ToString();
        }
        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            if (list.Content != null)
                if (!Regex.IsMatch(list.Content.ToString()[list.Content.ToString().Length - 1].ToString(), @"[*\/+\-\.%]"))
                    CalculateResult();
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            if (lbl_result.Content != null)
                lbl_result.Content = (int.Parse(lbl_result.Content.ToString()) / 2).ToString();

            else if (list.Content != null)
                list.Content = (int.Parse(list.Content.ToString()) / 2).ToString();


        }
    }
}
