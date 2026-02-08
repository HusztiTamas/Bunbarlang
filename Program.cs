using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    static void Game()
    {
        bool fut = true;
        while (fut)
        {
            Console.Clear();
            Console.WriteLine("Bűnbarlang\n");
            Console.WriteLine("1. Első játék");
            Console.WriteLine("2. Második játék");
            Console.WriteLine("0. Kilépés");
            Console.WriteLine("Választás: ");
            string valasztas = Console.ReadLine();
            if (valasztas == "1")
            {
                Console.WriteLine("1es jatek");
            }
            else if (valasztas == "2")
            {
                Console.WriteLine("2es jatek");
            }
            else if (valasztas == "0")
            {
                fut = false;
            }
            else
            {
                Console.WriteLine("Nem létezik ilyen választás!");
                Console.ReadKey();
            }
        }
    }
    static void Main()
    {
        Game();
    }
}