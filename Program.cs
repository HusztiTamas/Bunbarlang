using Bűnbarlang;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    static void Game()
    {
        bool fut = true;
        ElsoJatek elso = new ElsoJatek();

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
                elso.Start();
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