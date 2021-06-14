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
        private Image robotImg;
        private Rectangle[,] policka;
        public MainWindow()
        {
            InitializeComponent();
            kaDel = new KaDel(rozmer);

            SestavMapu();
            Vykresli();
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

            policka = new Rectangle[rozmer,rozmer];

            for (int x = 0; x < rozmer; x++)
            {
                for (int y = 0; y < rozmer; y++)
                {
                    Rectangle rectangle = new Rectangle();
                    Mapa.Children.Add(rectangle);
                    Grid.SetRow(rectangle, y);
                    Grid.SetColumn(rectangle, x);
                    policka[x, y] = rectangle;
                }
            }

            robotImg = new Image();
            Mapa.Children.Add(robotImg);
        }
        
        /// <summary>
        /// Vykreslí do gridu aktuální stav
        /// </summary>
        public void Vykresli()
        {
            // nastavit vyplněno/nevyplněno
            for (int x = 0; x < rozmer; x++)
            {
                for (int y = 0; y < rozmer; y++)
                {
                    bool jeVyplneno = kaDel.Vyplneno[x, y];
                    policka[x, y].Style = jeVyplneno ? FindResource("PolickoPlne") as Style
                                                    : FindResource("PolickoPrazdne") as Style;
                }
            }
            // otočit a přesunout robota
            Grid.SetColumn(robotImg, kaDel.X);
            Grid.SetRow(robotImg, kaDel.Y);

            string soubor = "";
            switch (kaDel.Smer)
            {
                case Smer.Doprava:
                    soubor = "vpravo.png";
                    break;
                case Smer.Nahoru:
                    soubor = "nahoru.png";
                    break;
                case Smer.Doleva:
                    soubor = "vlevo.png";
                    break;
                case Smer.Dolu:
                    soubor = "dolu.png";
                    break;
            }
            robotImg.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + @"\img\" + soubor));
        }

        public void VykonejPrikaz(string prikaz)
        {
            // pozměnit model
            string report;

            switch (prikaz)
            {
                case "krok":
                    report = kaDel.Krok();
                    break;

                case "otoc":
                    report = kaDel.Otoc();
                    break;

                case "vypln":
                    report = kaDel.Vypln();
                    break;

                case "vymaz":
                    report = kaDel.Vymaz();
                    break;

                case "reset":
                    report = kaDel.Reset();
                    break;

                default:
                    report = $"Neznámý příkaz {prikaz}";
                    break;
            }

            // zalogovat návratovou hodnotu
            Vypis.Text = report + System.Environment.NewLine + Vypis.Text;

            // překreslit
            Vykresli();
        }

        private void Krok_Click(object sender, RoutedEventArgs e)
        {
            VykonejPrikaz("krok");
        }

        private void Otoc_Click(object sender, RoutedEventArgs e)
        {
            VykonejPrikaz("otoc");
        }

        private void Vypln_Click(object sender, RoutedEventArgs e)
        {
            VykonejPrikaz("vypln");
        }

        private void Vymaz_Click(object sender, RoutedEventArgs e)
        {
            VykonejPrikaz("vymaz");
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            VykonejPrikaz("reset");
            Vypis.Text = "";
        }

        private void Spust_Click(object sender, RoutedEventArgs e)
        {
            //načti příkazy

            //rozbij na pole

            //inicializuj frontu

            //spusť timer

            //deaktivuj UI
        }
    }


}
