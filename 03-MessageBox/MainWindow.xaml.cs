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

namespace _03_MessageBox
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult boxResult = MessageBox.Show("Baf!", "Vyber si", MessageBoxButton.OKCancel);
            if (boxResult == MessageBoxResult.OK)
            {
                ResultLbl.Content = "Tak jo";
            }
            else
            {
                ResultLbl.Content = "Tak nic";
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            string message = "Opravdu?";
            string caption = "Potvrzení";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxImage image = MessageBoxImage.Asterisk;
            //MessageBox.Show(
            //    "Opravdu?",
            //    "Potvrzení",
            //    MessageBoxButton.YesNo,
            //    MessageBoxImage.Asterisk
            //    );
            if (MessageBox.Show(message, caption, buttons, image) == MessageBoxResult.Yes)
            {
                ResultLbl.Content = "Tak jo";
            }
            else
            {
                ResultLbl.Content = "Tak nic";
            }


        }
    }
}
