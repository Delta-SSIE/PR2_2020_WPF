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

namespace _04_CheckBox
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

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Klik");
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                "Klik",
                "Událost",
                MessageBoxButton.OK,
                (bool) CheckBox1.IsChecked ? MessageBoxImage.Information : MessageBoxImage.Warning
                );;
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox1.IsChecked = true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox1.IsChecked = false;
        }
    }
}
