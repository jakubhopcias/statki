using Statki;
using System.Runtime.Serialization.Formatters;

int liczbaStatków = 5;
int rozmiarPlanszy = 10;

Bot bot = new Bot(liczbaStatków);

int i = 1;
int x=0, y=0;
Plansza planszaGracza = new Plansza(rozmiarPlanszy);
while (i <= liczbaStatków)
{
    Console.WriteLine("Podaj koordynat x statku " + i);
    x=int.Parse(Console.ReadLine());

    Console.WriteLine("Podaj koordynat y statku " + i);
    y = int.Parse(Console.ReadLine());

    planszaGracza.PlaceShip(x, y);
    planszaGracza.Display();
    Console.WriteLine("");
    i++;
}

HashSet<(int,int)> previousShoots = new HashSet<(int,int)> ();

while (bot.plansza.AreAllShipsSunk() == false)
{
    Console.WriteLine("Plansza gracza: ");
    planszaGracza.Display();

    Console.WriteLine("Plansza komputera: ");
    bot.plansza.Display();

    Console.WriteLine("Wybierz x strzału");
    x= int.Parse(Console.ReadLine());

    Console.WriteLine("Wybierz y strzału");
    y=int.Parse(Console.ReadLine());

    bot.plansza.Shoot(x,y);

    bot.ChooseTarget(previousShoots,planszaGracza);
}
Console.WriteLine("Gra skończona!");