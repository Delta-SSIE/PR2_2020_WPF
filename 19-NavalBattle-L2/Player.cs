using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19_NavalBattle_L2
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
        public bool IsFinished
        {
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

            //CreateMap();            
            PlaceShips();
        }

        //vytvorit si mapu
        private void CreateMap()
        {
            map = new TileState[dimension, dimension];
            for (int x = 0; x < dimension; x++)
            {
                for (int y = 0; y < dimension; y++)
                {
                    map[x, y] = TileState.Empty;
                }
            }
        }

        //umistit si lode
        private bool PlaceShips(int tries = 10)
        {
            CreateMap();
            //pro pocet lodi
            int shipsToPlace = shipCount;
            do
            {
                //vymysli náhodné x a y v rozmezí <0 ; dimension - 1>
                //int x = rnd.Next(dimension);
                //int y = rnd.Next(dimension);
                //kdyz je tam volno, dej tam lod, jinak opakuj
                
                int attempt = 0;
                
                while (attempt < tries)
                {
                    Coordinates place = new Coordinates(rnd.Next(dimension), rnd.Next(dimension));

                    if (CanPlace(place))
                    {
                        map[place.X, place.Y] = TileState.Ship;
                        shipsToPlace--;
                        break;
                    }

                    attempt++;
                }
                if (attempt >= tries)
                    return false;

            }
            while (shipsToPlace > 0); //dokud je co umisťovat
            return true;
        }

        private bool CanPlace(Coordinates tile)
        {
            for (int shiftX = -1; shiftX < 2; shiftX++)
            {
                for (int shiftY = -1; shiftY < 2; shiftY++)
                {
                    int neighbourX = tile.X + shiftX;
                    int neighbourY = tile.Y + shiftY;

                    if (neighbourX < 0 || neighbourY < 0 || neighbourX >= dimension || neighbourY >= dimension)
                        continue;

                    if (map[neighbourX, neighbourY] == TileState.Ship)
                        return false;
                }
            }

            return true;
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
            bool canShoot;

            do
            {
                canShoot = true;

                target.X = rnd.Next(dimension);
                target.Y = rnd.Next(dimension);
                
                if (opponentMap[target.X, target.Y] != TileState.Empty)
                {
                    canShoot = false;
                    continue; //sem už se střílelo
                }
                    

                for (int shiftX = -1; shiftX < 2 && canShoot; shiftX++)
                {
                    for (int shiftY = -1; shiftY < 2 && canShoot; shiftY++)
                    {
                        int neighbourX = target.X + shiftX;
                        int neighbourY = target.Y + shiftY;

                        if (neighbourX < 0 || neighbourY < 0 || neighbourX >= dimension || neighbourY >= dimension)
                            continue;

                        else if (map[neighbourX, neighbourY] == TileState.Wreck)
                            canShoot = false;
                    }
                }
            }
            while (!canShoot);

            return target;
        }

    }
}

