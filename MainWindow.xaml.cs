using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool firsttime = true;
        public int first;
        public int second;
        public string method;
        public void DisableButtons()
        {
            Plus.IsEnabled = false;
            Minus.IsEnabled = false;
            Times.IsEnabled = false;
            Div.IsEnabled = false;
            Square.IsEnabled = false;
            Equals.IsEnabled = true;
        }
        public void EnableButtons()
        {
            Plus.IsEnabled = true;
            Minus.IsEnabled = true;
            Times.IsEnabled = true;
            Div.IsEnabled = true;
            Square.IsEnabled = true;
            Equals.IsEnabled = false;
        }
        public void IntConvert()
        {
            try
            {
                if(Convert.ToInt64(Textbox1.Text) > 2147483647)
                {
                    MessageBox.Show("Number exceeds limits of a 32bit integer!");
                    return;
                }
                first = Convert.ToInt32(Textbox1.Text);
                Textbox1.Clear();
                DisableButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show("That's not a valid number!");
                Textbox1.Clear();
                return;
            }

        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Times_Click(object sender, RoutedEventArgs e)
        {
            IntConvert();
            method = "*";
        }

        private void Plus_Click(object sender, RoutedEventArgs e)
        {
            IntConvert();
            method = "+";
        }

        private void Minus_Click(object sender, RoutedEventArgs e)
        {
            IntConvert();
            method = "-";
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                second = Convert.ToInt32(Textbox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("That's not a valid number!");
                Textbox1.Clear();
                return;
            }
            if (method == "+")
            {
                int result = first + second;
                string stringResult = Convert.ToString(result);
                Textbox1.Text = stringResult;
                EnableButtons();
                firsttime = true;
                Lb1.Items.Add(stringResult);
            }
            if (method == "-")
            {
                int result = first - second;
                string stringResult = Convert.ToString(result);
                Textbox1.Text = stringResult;
                EnableButtons();
                firsttime = true;
                Lb1.Items.Add(stringResult);
            }
            if (method == "*")
            {
                int result = first * second;
                string stringResult = Convert.ToString(result);
                Textbox1.Text = stringResult;
                EnableButtons();
                firsttime = true;
                Lb1.Items.Add(stringResult);
            }
            if (method == "/")
            {
                if(second == 0)
                {
                    MessageBox.Show("Cannot divide by Zero!");
                    Textbox1.Clear();
                    return;
                }
                int result = first / second;
                string stringResult = Convert.ToString(result);
                Textbox1.Text = stringResult;
                EnableButtons();
                firsttime = true;
                Lb1.Items.Add(stringResult);
            }
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            IntConvert();
            method = "/";
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            int square;
            try
            {
                square = Convert.ToInt32(Textbox1.Text);
                Textbox1.Clear();
                int squareResult;
                squareResult = square * square;
                string squareString;
                squareString = Convert.ToString(squareResult);
                Textbox1.Text = squareString;
                Lb1.Items.Add(squareString);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thats not a valid number!");
                Textbox1.Clear();
            }
        }
    }
}
