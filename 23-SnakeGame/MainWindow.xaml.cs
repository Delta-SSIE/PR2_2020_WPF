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

namespace _23_SnakeGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        const int Width = 30;
        const int Height = 20;
        private int speed = 250;
        private GameController controller;

        public MainWindow()
        {
            InitializeComponent();

            // set up plan
            SetUpPlan();

            // start timer
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(speed);
            timer.Tick += Timer_Tick;
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            controller.Step();
            RenderPlan(controller.Snake, controller.Map);
            if (controller.State == GameState.Lost)
            {
                timer.Stop();
                MessageBox.Show("You lost at length " + controller.Snake.Length);
                StartBtn.IsEnabled = true;
            }
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            controller = new GameController(Width, Height);
            controller.StartGame();

            timer.Start();
            StartBtn.IsEnabled = false;

            RenderPlan(controller.Snake, controller.Map);
        }

        private void SetUpPlan()
        {
            GamePlan.Margin = new Thickness(10);
            GamePlan.ShowGridLines = false;
            GamePlan.Background = Brushes.Lime;

            for (int x = 0; x < Width; x++)
            {
                ColumnDefinition column = new ColumnDefinition();
                GamePlan.ColumnDefinitions.Add(column);
            }

            for (int y = 0; y < Height; y++)
            {
                RowDefinition row = new RowDefinition();
                GamePlan.RowDefinitions.Add(row);
            }
        }

        private void RenderPlan(Coordinates[] snake, Terrain[,] map)
        {
            // empty the plan
            GamePlan.Children.Clear();

            // draw all non-empty tiles
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    switch(map[x,y])
                    {
                        case Terrain.Food:
                            Rectangle food = new Rectangle();
                            Grid.SetRow(food, y);
                            Grid.SetColumn(food, x);
                            GamePlan.Children.Add(food);
                            food.Fill = Brushes.Yellow;
                            break; 

                        case Terrain.Wall:
                            Rectangle wall = new Rectangle();
                            Grid.SetRow(wall, y);
                            Grid.SetColumn(wall, x);
                            GamePlan.Children.Add(wall);
                            wall.Fill = Brushes.Red;
                            break;
                    }
                }
            }

            foreach (Coordinates segment in snake)
            {
                Ellipse element = new Ellipse();
                Grid.SetRow(element, segment.Y);
                Grid.SetColumn(element, segment.X);
                GamePlan.Children.Add(element);
                if (segment == snake[0])
                    element.Fill = Brushes.Cyan;
                else
                    element.Fill = Brushes.Gray;
            }

            LengthTB.Text = snake.Length.ToString();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (controller == null)
                return;

            switch (e.Key)
            {
                case Key.Up:
                    controller.Heading = Direction.North;
                    break;
                case Key.Down:
                    controller.Heading = Direction.South;
                    break;
                case Key.Left:
                    controller.Heading = Direction.West;
                    break;
                case Key.Right:
                    controller.Heading = Direction.East;
                    break;
            }
        }
    }
}
