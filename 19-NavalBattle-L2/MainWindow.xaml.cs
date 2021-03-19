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

namespace _19_NavalBattle_L2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int dimension = 10;
        const int shipCount = 10;

        private Rectangle[,] playerTiles;
        private Rectangle[,] computerTiles;

        private Player player;
        private Player computer;

        private Logger logger;

        public MainWindow()
        {
            InitializeComponent();

            player = new Player(dimension, shipCount);
            computer = new Player(dimension, shipCount);

            playerTiles = InitializeDisplay(PlayerSeaDisplay);
            computerTiles = InitializeDisplay(ComputerSeaDisplay, true);

            RenderMap(playerTiles, player.PrivateMap);
            RenderMap(computerTiles, computer.PublicMap);

            RenderScore();

            logger = new Logger(BattleLog);
            logger.LogMessage("The battle begins");

        }

        Rectangle[,] InitializeDisplay(Grid seaDisplay, bool isClickable = false)
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

                    if (isClickable)
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

            //zapis pocitaci vystrel na nej
            bool hit = computer.HandleShot(target);
            logger.LogShot("Player", target, hit);
            RenderTile(clicked, computer.PublicMap[target.X, target.Y]);
            RenderScore();

            //zjistim, jestli je konec
            if (computer.IsFinished)
            {
                MessageBox.Show("You win!");
                logger.LogMessage("Player wins");
                Close();
                return;
            }
            //kdyz ne
            if (hit) //takže se bude čekat na další zásah
                return;

            hit = true;

            while (hit)
            {

                //pocitac vymysli kam strilet
                target = computer.RandomTarget(player.PublicMap);

                //zapis hraci vystrel na nej
                hit = player.HandleShot(target);
                logger.LogShot("Computer", target, hit);
                RenderTile(playerTiles[target.X, target.Y], player.PrivateMap[target.X, target.Y]);
                RenderScore();

                //zjisti, jestli je konec
                if (player.IsFinished)
                {
                    MessageBox.Show("You lose!");
                    logger.LogMessage("Computer wins");
                    Close();
                    return;
                }
            }
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

        private void RenderTile(Rectangle tile, TileState state)
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

        private void RenderMap(Rectangle[,] tiles, TileState[,] map)
        {
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    RenderTile(tiles[x, y], map[x, y]);
                }
            }
        }

        private void RenderScore()
        {
            PlayerScore.Content = $"{player.Wrecks} / {shipCount}";
            ComputerScore.Content = $"{computer.Wrecks} / {shipCount}";
        }

    }
}
