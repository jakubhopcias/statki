using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki
{
    internal class Plansza
    {
        public char[,] Grid { get; private set; } 
        public int Size { get; }
        public Plansza(int size)
    {
        Size = size;
        Grid = new char[size, size];

        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                Grid[i, j] = '~'; 
    }

    public void Display()
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
                Console.Write(Grid[i, j] + " ");
            Console.WriteLine();
        }
    }

    public bool CanPlaceShip(int x, int y)
    {
        return x >= 0 && x < Size && y >= 0 && y < Size && Grid[x, y] == '~';
    }

    public bool PlaceShip(int x, int y)
    {
        if (!CanPlaceShip(x, y))
            return false;

        Grid[x, y] = 'S';
        return true;
    }

    public bool Shoot(int x, int y)
    {
        if (x < 0 || x >= Size || y < 0 || y >= Size || Grid[x, y] == 'X' || Grid[x, y] == 'O')
            return false; // Strzał poza planszą lub w już odkryte pole

        if (Grid[x, y] == 'S')
        {
            Grid[x, y] = 'X'; // Trafienie
            return true;
        }

        Grid[x, y] = 'O'; // Pudło
        return false;
    }
    public bool AreAllShipsSunk()
    {
        for (int i = 0; i < Size; i++)
            for (int j = 0; j < Size; j++)
                if (Grid[i, j] == 'S') return false;

        return true;
    }
}
    }

