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

namespace PodminenyRadio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SlevaOnCB.IsChecked = false;
            //SlevaOnCB_Unchecked(null, null);
            SlevaOnCB.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.CheckBox.UncheckedEvent));
            
        }

        private void SlevaOnCB_Checked(object sender, RoutedEventArgs e)
        {
                TypSlevy.IsEnabled = true;
        }
        private void SlevaOnCB_Unchecked(object sender, RoutedEventArgs e)
        {
                TypSlevy.IsEnabled = false;
        }

    }
}
