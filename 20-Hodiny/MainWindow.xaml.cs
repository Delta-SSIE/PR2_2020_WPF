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
using System.Windows.Threading;

namespace _20_Hodiny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = System.TimeSpan.FromSeconds(100);
            timer.Tick += UpdateClock;
            timer.Start();
            UpdateClock(null, null);
        }

        private void UpdateClock(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            Hours.Content = time.Hour.ToString().PadLeft(2, '0');
            Mins.Content = time.Minute.ToString("00");
            Secs.Content = time.Second.ToString("00");
        }
    }
}
