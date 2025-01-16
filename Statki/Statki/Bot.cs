
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Bot
    {
        private Random random = new Random();
        public Plansza plansza = new Plansza(10);

        public Bot(int numberOfShips)
        {

            PlaceShips(numberOfShips);
        }

        private void PlaceShips(int numberOfShips)
        {
            int placedShips = 0;
            Random random = new Random();

            HashSet<(int, int)> existingCoordinates = new HashSet<(int, int)>();

            while (placedShips < numberOfShips)
            {
                int x = random.Next(plansza.Size);
                int y = random.Next(plansza.Size);

                if (!existingCoordinates.Contains((x, y)))
                {
                    plansza.PlaceShip(x, y);
                    existingCoordinates.Add((x, y));
                    placedShips++;
                }
            }
        }

        public (int, int) ChooseTarget(HashSet<(int, int)> previousShots, Plansza plansza)
        {
            int x, y;

            do
            {
                x = random.Next(plansza.Size);
                y = random.Next(plansza.Size);
            } while (previousShots.Contains((x, y)));

            plansza.Shoot(x, y);
            bool shotResult = plansza.Shoot(x, y);

            if (shotResult)
            {
                previousShots.Add((x, y));
            }

            return (x, y);
        }
    }
}