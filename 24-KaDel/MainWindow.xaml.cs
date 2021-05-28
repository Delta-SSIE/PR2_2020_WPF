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

namespace _24_KaDel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int rozmer = 10;
        private KaDel kaDel;
        public MainWindow()
        {
            InitializeComponent();
            kaDel = new KaDel(rozmer);

            SestavMapu();
        }

        private void SestavMapu()
        {
            for (int x = 0; x < rozmer; x++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                Mapa.ColumnDefinitions.Add(gridCol);
            }
            for (int y = 0; y < rozmer; y++)
            {
                RowDefinition gridRow = new RowDefinition();
                Mapa.RowDefinitions.Add(gridRow);
            }

            for (int x = 0; x < rozmer; x++)
            {
                for (int y = 0; y < rozmer; y++)
                {
                    Rectangle rectangle = new Rectangle();
                    Mapa.Children.Add(rectangle);
                    Grid.SetRow(rectangle, y);
                    Grid.SetColumn(rectangle, x);
                }
            }
        }
    }
}
