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

namespace _16_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double lastNumber;
        private Operation lastOperation;

        public MainWindow()
        {
            InitializeComponent();           
        }

        private void NumberBtnClick(object sender, RoutedEventArgs e)
        {
            string btnValue = ((Button)sender).Content.ToString();

            if (DisplayTB.Text == "0")
            {
                DisplayTB.Text = btnValue;
            }
            else
            {
                DisplayTB.Text += btnValue;
            }
        }

        private void DotBtn_Click(object sender, RoutedEventArgs e)
        {
            string decimalDot = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (!DisplayTB.Text.Contains(decimalDot))
            {
                DisplayTB.Text += decimalDot;
            }
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = double.Parse(DisplayTB.Text);
            DisplayTB.Text = "0";

            if (sender == PlusBtn)
            {
                lastOperation = Operation.Addition;
            }
            else if (sender == MinusBtn)
            {
                lastOperation = Operation.Subtraction;
            }
            else if (sender == MultiplyBtn)
            {
                lastOperation = Operation.Multiplication;
            }
            else if (sender == DivisionBtn)
            {
                lastOperation = Operation.Division;
            }
        }

        private void ResultBtn_Click(object sender, RoutedEventArgs e)
        {
            double newNumber = double.Parse(DisplayTB.Text);
            double result = 0;

            switch (lastOperation)
            {
                case Operation.Addition:
                    result = SimpleMath.Add(lastNumber, newNumber);
                    break;
                case Operation.Subtraction:
                    result = SimpleMath.Subtract(lastNumber, newNumber);
                    break;
                case Operation.Multiplication:
                    result = SimpleMath.Multiply(lastNumber, newNumber);
                    break;
                case Operation.Division:
                    result = SimpleMath.Divide(lastNumber, newNumber);
                    break;
            }

            DisplayTB.Text = result.ToString();

        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            DisplayTB.Text = "0";
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            DisplayTB.Text = (double.Parse(DisplayTB.Text) * -1).ToString();
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            DisplayTB.Text = (double.Parse(DisplayTB.Text) / 100).ToString();
        }
    }

    enum Operation
    {
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
}
