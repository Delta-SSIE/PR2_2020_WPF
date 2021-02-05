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

namespace _08_Tajny_text
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

        private void zobrazSkryjBtn_Click(object sender, RoutedEventArgs e)
        {
            if (otevreneTB.IsVisible)
            {
                skrytePwdB.Password = otevreneTB.Text;
                otevreneTB.Visibility = Visibility.Hidden;
                skrytePwdB.Visibility = Visibility.Visible;
                zobrazSkryjBtn.Content = "Zobraz";
            }
            else
            {
                otevreneTB.Text = skrytePwdB.Password;
                otevreneTB.Visibility = Visibility.Visible;
                skrytePwdB.Visibility = Visibility.Hidden;
                zobrazSkryjBtn.Content = "Skryj";
            }

        }
    }
}
