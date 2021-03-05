using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_NavalBattle
{
    enum TileState : byte { Empty, Shot, Ship, Wreck }
    class Player
    {
        private static Random rnd = new Random();

        //mapa - je soukromá, k ní svět nemá přístup
        private TileState[,] map;

        //pocet zasahu
        public int Wrecks { get; private set; }

        //je konec
        public bool IsFinished {
            get
            {
                return Wrecks >= shipCount;
            }
        }

        //klon mapy pro vykreslení - neumožňuje vnějšímu světu zápis
        public TileState[,] PrivateMap
        {
            get
            {
                return (TileState[,])map.Clone();
            }
        }

        //poskytnout pohled na "verejnou mapu bez poloh lodi"
        public TileState[,] PublicMap
        {
            get
            {
                TileState[,] pubMap = (TileState[,])map.Clone();
                for (int x = 0; x < dimension; x++)
                {
                    for (int y = 0; y < dimension; y++)
                    {
                        if (pubMap[x, y] == TileState.Ship)
                            pubMap[x, y] = TileState.Empty;
                    }
                }
                return pubMap;
            }
        }

        private readonly int dimension;
        private readonly int shipCount;

        public Player(int dimension, int shipCount)
        {
            this.dimension = dimension;
            this.shipCount = shipCount;

            Wrecks = 0;

            CreateMap();
            PlaceShips();
        }

        //vytvorit si mapu
        private void CreateMap()
        {
            map = new TileState[dimension,dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    map[x, y] = TileState.Empty;
                }
            }
        }

        //umistit si lode
        private void PlaceShips()
        {
            //pro pocet lodi
            int shipsToPlace = shipCount;
            do
            {
                //vymysli náhodné x a y v rozmezí <0 ; dimension - 1>
                int x = rnd.Next(dimension);
                int y = rnd.Next(dimension);
                //kdyz je tam volno, dej tam lod, jinak opakuj
                if (map[x,y] == TileState.Empty)
                {
                    map[x, y] = TileState.Ship;
                    shipsToPlace--;
                }
            }
            while (shipsToPlace > 0); //dokud je co umisťovat
        }

        //zpracovat vystrel na souradnice - true při novém zásahu, abych mohl hrát znovu
        public bool HandleShot(Coordinates target)
        {
            TileState state = map[target.X, target.Y];
            switch (state)
            {
                case TileState.Empty:
                    map[target.X, target.Y] = TileState.Shot;
                    return false;

                case TileState.Ship:
                    map[target.X, target.Y] = TileState.Wreck;
                    Wrecks++;
                    return true;

                default:
                    return false;
            }
        }

        //vymyslet, kam strilet
        public Coordinates RandomTarget(TileState[,] opponentMap)
        {
            Coordinates target = new Coordinates();

            do
            {
                target.X = rnd.Next(dimension);
                target.Y = rnd.Next(dimension);
            } 
            while (opponentMap[target.X, target.Y] != TileState.Empty);

            return target;
        }

    }
}
