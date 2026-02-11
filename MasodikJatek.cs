using System;
using System.Collections.Generic;
using System.Text;

namespace Bűnbarlang
{
    internal class MasodikJatek
    {
        private int jatekosPenz;
        private int probalkozasok;
        private Random rnd;
        private List<string> slot;

        public MasodikJatek()
        {
            jatekosPenz = 40000;
            probalkozasok = 0;
            rnd = new Random();
            slot = new List<string> { "9", "10", "J", "Q", "K", "A", "🍒", "🍋", "🍊", "🍉", "🍇", "777" };
        }

        public int JatekosPenz { get => jatekosPenz; set => jatekosPenz = value; }
        public int Probalkozasok { get => probalkozasok; set => probalkozasok = value; }
        public Random Rnd { get => rnd; set => rnd = value; }
        public List<string> Slot { get => slot; set => slot = value; }

        public void Start()
        {
            bool jatszik = true;
            int random = 0;
            Console.WriteLine("Nyomj meg egy billenytűt a kezdéshez!");
            Console.ReadKey();
            while (jatszik)
            {
                if (jatekosPenz <= 399)
                {
                    Console.WriteLine("Kifogytál a pénzből!");
                    jatszik = false;
                }
                else
                {
                    List<string> eredmeny = new List<string>();
                    Console.WriteLine($"Aktuális pénzösszeg: {jatekosPenz}");
                    for (int i = 0; i < 5; i++)
                    {
                        random = rnd.Next(100);
                        switch (random)
                        {
                            case < 40:
                                for (int j = 0; j < 48; j++)
                                {
                                    Thread.Sleep(100);
                                    Console.Write("\r" + slot[j].PadRight(3));
                                }
                                Console.Write(slot[11]);
                                eredmeny.Add(slot[11]);
                                break;
                            case < 76:
                                for (int j = 0; j < 48; j++)
                                {
                                    Thread.Sleep(100);
                                    Console.Write("\r" + slot[j].PadRight(3));
                                }
                                random = rnd.Next(6);
                                Console.Write(slot[random]);
                                eredmeny.Add(slot[random]);
                                break;
                            default:
                                for (int j = 0; j < 48; j++)
                                {
                                    Thread.Sleep(100);
                                    Console.Write("\r" + slot[j].PadRight(3));
                                }
                                random = rnd.Next(6, 11);
                                Console.Write(slot[random]);
                                eredmeny.Add(slot[random]);
                                break;
                        }
                    }
                    jatekosPenz -= 400;
                    if (eredmeny.All(s => s == "777"))
                    {
                        Console.WriteLine("JACKPOT!");
                        jatekosPenz += 10000;
                    }
                    else if (eredmeny.Take(4).All(s => s == eredmeny[0]))
                    {
                        Console.WriteLine("4 azonos! +500");
                        jatekosPenz += 500;
                    }
                    else if (eredmeny.Take(3).All(s => s == eredmeny[0]))
                    {
                        Console.WriteLine("3 azonos! +200");
                        jatekosPenz += 200;
                    }
                    else if (eredmeny.Take(2).All(s => s == eredmeny[0]))
                    {
                        Console.WriteLine("2 azonos! +100");
                        jatekosPenz += 100;
                    }
                    else
                    {
                        Console.WriteLine("Nincs nyeremény.");
                    }
                    Console.WriteLine($"Aktuális pénzösszeg: {jatekosPenz}");
                    Console.WriteLine("Folytatás/Kilépés (y/n)");
                    if (Console.ReadKey(true).Key == ConsoleKey.N)
                    {
                        jatszik = false;
                    }
                }
            }
        }

    }
}
