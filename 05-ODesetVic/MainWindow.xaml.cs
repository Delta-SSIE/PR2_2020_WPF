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

namespace ODesetVic
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OutputTB == null) //na začátku programu jestě OutputTB neexistuje, proto vykonávání ukončím
                return;

            if (int.TryParse(InputTB.Text, out int number))
            {
                OutputTB.Text = (number + 10).ToString();
            }
            else if (InputTB.Text == "")
            {
                OutputTB.Text = "10";
            }
            else
            {
                OutputTB.Text = "Error";
            }
        }
    }
}
