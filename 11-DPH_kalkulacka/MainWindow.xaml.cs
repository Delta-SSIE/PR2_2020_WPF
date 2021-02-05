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

namespace DPH_kalkulacka
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
            if (
                double.TryParse(SDphTb.Text, out double cenaSDph) &&
                double.TryParse(SazbaDphTb.Text, out double sazbaDPH)
            )
            {
                sazbaDPH = sazbaDPH / 100;
                double bezDPH = cenaSDph / (1 + sazbaDPH);
                BezDphTB.Text = bezDPH.ToString();
                DphTB.Text = (bezDPH * sazbaDPH).ToString();
            }
            else
            {
                MessageBox.Show("Vstupní data nelze interpretovat", "Neplatná data");
            }
        }
    }
}
