using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24_KaDel
{
    enum Smer { Doprava, Nahoru, Doleva, Dolu };

    class KaDel
    {
        private int _rozmer;
        public int X { get; private set; }
        public int Y { get; private set; }
        public Smer Smer { get; private set; }
        public bool[,] Vyplneno { get; private set; }

        public KaDel(int rozmer)
        {
            _rozmer = rozmer;
            Reset();
        }

        public string Krok()
        {
            int noveX = X;
            int noveY = Y;
            switch (Smer)
            {
                case Smer.Doprava:
                    noveX++;
                    break;
                case Smer.Doleva:
                    noveX--;
                    break;
                case Smer.Nahoru:
                    noveY--;
                    break;
                case Smer.Dolu:
                    noveY++;
                    break;
            }
            if (X >= 0 && Y >=0 && X < _rozmer && Y < _rozmer)
            {
                // jde to
                X = noveX;
                Y = noveY;
                return "Krok : OK";
            }
            else
            {
                // nejde to, náraz
                return "Krok : náraz";
            }
        }

        public string Otoc()
        {
            Smer++;
            if (Smer > Smer.Dolu)
            { 
                Smer = Smer.Doprava;
            }

            return "Otoč : OK";
        }

        public string Vypln()
        {
            if (Vyplneno[X, Y])
            {
                return "Vyplň : Nelze";
            }
            else
            {
                Vyplneno[X, Y] = true;
                return "Vyplň : OK";
            }
        }        
        public string Vymaz()
        {
            if (!Vyplneno[X, Y])
            {
                return "Vymaž : Nelze";
            }
            else
            {
                Vyplneno[X, Y] = false;
                return "Vymaž : OK";
            }
        }
        public string Reset()
        {
            Vyplneno = new bool[_rozmer, _rozmer];
            X = 0; //robot vlevo
            Y = _rozmer - 1; //robot dole
            Smer = Smer.Doprava;
            return "";
        }

    }
}
