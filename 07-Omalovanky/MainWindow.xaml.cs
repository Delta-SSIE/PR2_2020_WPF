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

namespace Omalovanky
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

        private void RedBtn_Click(object sender, RoutedEventArgs e)
        {
            SampleTextTB.Background = Brushes.Red;
            SampleTextTB.Foreground = Brushes.White;
        }

        private void BlueBtn_Click(object sender, RoutedEventArgs e)
        {
            SampleTextTB.Background = Brushes.Blue;
            SampleTextTB.Foreground = Brushes.White;
        }

        private void GreenBtn_Click(object sender, RoutedEventArgs e)
        {
            SampleTextTB.Background = Brushes.Green;
            SampleTextTB.Foreground = Brushes.White;
        }

        private void YellowBtn_Click(object sender, RoutedEventArgs e)
        {
            SampleTextTB.Background = Brushes.Yellow;
            SampleTextTB.Foreground = Brushes.Black;
        }
    }
}
