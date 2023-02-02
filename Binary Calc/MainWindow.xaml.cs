using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Binary_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string input_number;
        int digit;
        bool binary_mode;
        public MainWindow()
        {
            
            InitializeComponent();
            binary_mode = true;
            if (binary_mode == true)
            {
                Directions.Text = "Type a number in Binary";
            }
            else
            {
                Directions.Text = "Type a number in Decimal";
            }
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Enter)
            {
                input_number = Input.Text;

                if (binary_mode == false)
                {
                    int num_limit = 2097152;
                    string dtotal = "";
                    input_number = Input.Text;
                    int.TryParse(input_number, out int num);
                    int remainder;
                    while (true)
                    {
                        if (num_limit == 0)
                        {
                            break;
                        }
                        else if (num / num_limit >= 1)
                        {
                            num = num - num_limit;
                            dtotal += "1";
                            num_limit = num_limit / 2;
                        }
                        else if (num / num_limit < 1 && dtotal.Contains("1"))
                        {
                            dtotal += "0";
                            num_limit = num_limit / 2;
                        }
                        else
                        {
                            num_limit = num_limit / 2;
                        }
                        
                    }
                    if (dtotal.Length < 8)
                    {
                        remainder = dtotal.Length - 8;
                        dtotal = dtotal.PadLeft(8, '0');
                    }
                    Output.Text = dtotal;

                }
                else if (binary_mode == true)
                {
                    digit = 0;
                    double btotal = 0;
                    input_number = Input.Text;
                    foreach (char bits in input_number.Reverse())
                    {

                        if (bits == '1')
                        {
                            btotal += Math.Pow(2, digit);
                        }
                        digit = digit + 1;
                    }
                    Output.Text = btotal.ToString();
                }
                
            }


        }
       

        private void Mode_Button_Click(object sender, RoutedEventArgs e)
        {
            if (binary_mode == false)
            {
                binary_mode = true;
                Mode_Button.Content = "Binary --> Decimal";
                Directions.Text = "Type a number in Binary";
            }
            else if (binary_mode == true)
            {
                binary_mode = false;
                Mode_Button.Content = "Binary <-- Decimal";
                Directions.Text = "Type a number in Decimal";
            }
        }
    }
}
