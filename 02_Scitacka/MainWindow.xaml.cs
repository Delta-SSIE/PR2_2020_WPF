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

namespace _02_Scitacka
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

        private void SectiBtn_Click(object sender, RoutedEventArgs e)
        {
            //vezmi číslo z 1
            double cislo1 = double.Parse(Cislo1TB.Text);

            //vezmi číslo z 2
            double cislo2 = double.Parse(Cislo2TB.Text);

            //sečti
            double vysledek = cislo1 + cislo2;

            //zapiš do výsledku
            VysledekTB.Text = vysledek.ToString();
        }

        private void CisloTB_KeyUp(object sender, KeyEventArgs e)
        {
            bool isOK = true;

            double cislo1;
            if (!double.TryParse(Cislo1TB.Text, out cislo1))
            {
                Cislo1TB.Background = Brushes.Red;
                isOK = false;
            }
            else
            {
                Cislo1TB.Background = Brushes.White;
            }

            double cislo2;
            if (!double.TryParse(Cislo2TB.Text, out cislo2))
            {
                Cislo2TB.Background = Brushes.Red;
                isOK = false;
            }
            else
            {
                Cislo2TB.Background = Brushes.White;
            }

            SectiBtn.IsEnabled = isOK;

        }
    }
}
