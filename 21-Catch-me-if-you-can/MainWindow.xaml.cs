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

namespace _21_Catch_me_if_you_can
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // počet opakování
        const int turns = 20;
        private int turn = 0;
        private int score = 0;

        const int hiddenMin = 500;
        const int hiddenMax = 3000;

        const int displayedMin = 1200;
        const int displayedMax = 1700;

        const int margin = 10;

        private Random random = new Random();

        // pokaždé na náhodný čas zobrazit obdélník
        // když se podaří na něj kliknout, připočítat bod

        private DispatcherTimer showTimer = new DispatcherTimer();
        private DispatcherTimer hideTimer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            HideMe();
            showTimer.Tick += ShowTimer_Tick;
            hideTimer.Tick += HideTimer_Tick;
            All.Text = turns.ToString();
        }

        private void HideTimer_Tick(object sender, EventArgs e)
        {
            HideMe();
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            ShowMe();
        }

        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            score++;
            Caught.Text = score.ToString();
            HideMe();
            e.Handled = true; //pridano
        }

        private void ShowMe()
        {
            turn++;
            showTimer.Stop();
            Target.Margin = new Thickness(
                margin + random.Next((int) (Board.ActualWidth - Target.Width) - 2 * margin),
                margin + random.Next((int) (Board.ActualHeight - Target.Height) - 2 * margin), 
                0,
                0
            );
            Target.Visibility = Visibility.Visible;
            hideTimer.Interval = TimeSpan.FromMilliseconds(random.Next(displayedMin, displayedMax));
            hideTimer.Start();
        }

        private void HideMe()
        {
            hideTimer.Stop();
            Target.Visibility = Visibility.Hidden;
            showTimer.Interval = TimeSpan.FromMilliseconds(random.Next(hiddenMin, hiddenMax));
            showTimer.Start();
        }

        private void Board_MouseUp(object sender, MouseButtonEventArgs e)
        {
            score--;
            Caught.Text = score.ToString(); //pridano
        }
    }
}
