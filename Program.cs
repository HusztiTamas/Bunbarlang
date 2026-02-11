using Bűnbarlang;
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
            Console.WriteLine("=============================");
            Console.WriteLine("Üdv a Bűnbarlangban!");
            Console.WriteLine("=============================\n");
            Console.WriteLine("1. Első játék (Blackjack)");
            Console.WriteLine("2. Második játék (Pénznyelő)");
            Console.WriteLine("3. Kilépés");
            Console.WriteLine("\nVálasztás: ");

            string valasztas = Console.ReadLine();
            switch (valasztas)
            {
                case "1":
                    ElsoJatek jatek = new ElsoJatek();
                    jatek.Start();
                    break;
                case "2":
                    MasodikJatek jatek2 = new MasodikJatek();
                    jatek2.Start();
                    break;
                case "3":
                    fut = false;
                    Console.WriteLine("Reméljük élvezte!");
                    break;
                default:
                    Console.WriteLine("Nem létezik ilyen választás!");
                    Console.WriteLine("Nyomj egy gombot a visszalépéshez!");
                    Console.ReadKey();
                    break;
            }
        }
    }
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Game();
    }
}