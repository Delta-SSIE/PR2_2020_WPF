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

namespace _18_NavalBattle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int dimension = 10;

        private Rectangle[,] playerTiles;
        private Rectangle[,] computerTiles;

        public MainWindow()
        {
            InitializeComponent();

            playerTiles = InitializeDisplay(PlayerSeaDisplay);
            computerTiles = InitializeDisplay(ComputerSeaDisplay);
        }

        Rectangle[,] InitializeDisplay(Grid seaDisplay)
        {
            seaDisplay.Margin = new Thickness(10);
            //seaDisplay.ShowGridLines = true;

            for (int i = 0; i < dimension; i++)
            {
                ColumnDefinition gridCol = new ColumnDefinition();
                seaDisplay.ColumnDefinitions.Add(gridCol);
            }

            for (int i = 0; i < dimension; i++)
            {
                RowDefinition gridRow = new RowDefinition();
                seaDisplay.RowDefinitions.Add(gridRow);
            }

            Rectangle[,] tiles = new Rectangle[dimension, dimension];

            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    Rectangle tile = new Rectangle();
                    seaDisplay.Children.Add(tile);
                    Grid.SetRow(tile, y);
                    Grid.SetColumn(tile, x);

                    tile.MouseDown += Tile_MouseDown;
                    RenderTile(tile, TileState.Empty);

                    tiles[x, y] = tile;
                }
            }

            return tiles;
        }

        private void Tile_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle clicked = (Rectangle)sender;
            Coordinates target = FindCoordinates(clicked);
            //co s tim dal
        }

        private Coordinates FindCoordinates(Rectangle clicked)
        {            
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    if (clicked == computerTiles[x, y])
                    {
                        return new Coordinates(x, y);
                    }
                }
            }
            return null;
        }

        private void RenderTile (Rectangle tile, TileState state)
        {
            switch (state)
            {
                case TileState.Empty:
                    tile.Style = FindResource("Empty") as Style;
                    break;
                case TileState.Shot:
                    tile.Style = FindResource("Shot") as Style;
                    break;
                case TileState.Ship:
                    tile.Style = FindResource("Ship") as Style;
                    break;
                case TileState.Wreck:
                    tile.Style = FindResource("Wreck") as Style;
                    break;
            }
        }
    }
}
