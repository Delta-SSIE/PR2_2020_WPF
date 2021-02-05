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

namespace ScitackaII
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

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            bool input1OK = CheckInput(Num1);
            bool input2OK = CheckInput(Num2);
            bool input3OK = CheckInput(Num3);
            if (input1OK && input2OK && input3OK)
            {
                ResultNum.Text = (double.Parse(Num1.Text) + double.Parse(Num2.Text) + double.Parse(Num3.Text)).ToString();
            }
            else
            {
                ResultNum.Text = "Chybná vstupní data";
            }
                
        }

        private bool CheckInput(TextBox input)
        {
            
            double value; // obsahuje hodnotu            
            bool valIsOK; //říká, jetsli je vstupní pole v pořádku
            try
            {
                value = double.Parse(input.Text); //zkusím parsovat
                valIsOK = value > -9999 && value < 9999; //pokud se zdaří, pak je hodnota OK, pokud je v daném rozmení
            }
            catch
            {
                valIsOK = false; //pokud se parse nezdaří, hodnota OK není
            }

            if (valIsOK)
            {
                //pokud je OK, zruším nastavení "varovných" okrajů
                input.ClearValue(TextBox.BorderBrushProperty);
                input.ClearValue(TextBox.BorderThicknessProperty);
            }
            else
            {
                //pokud není OK, nastvím varovné okraje
                input.BorderBrush = Brushes.Red;
                input.BorderThickness = new Thickness(2);
            }

            //na konci vrátím, jestli je pole v pořádku
            return valIsOK;
        }
    }
}
