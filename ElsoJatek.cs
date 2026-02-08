using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace Bűnbarlang
{
    internal class ElsoJatek
    {
        private int jatekosPont;
        private int gepPont;
        private Random rnd;

        public ElsoJatek()
        {
            jatekosPont = 0;
            gepPont = 0;
            rnd = new Random();
        }

        public int JatekosPont { get => jatekosPont; set => jatekosPont = value; }
        public int GepPont { get => gepPont; set => gepPont = value; }

        public void Start()
        {
            Console.Clear();
            Console.WriteLine("Black Jack\n");
            bool jatekosFolytat = true;
            while (jatekosFolytat && JatekosPont < 21)
            {
                KartyaErtek lap = LapHuzas(true);
                Console.WriteLine($"Húzott lap: {lap}, pontok: {jatekosPont}");
                if (jatekosPont >= 21)
                {
                    jatekosFolytat = false;

                }
                else
                {
                    Console.WriteLine("Kérsz még lapot? (i/n): ");
                    bool helyesErtek = false;
                    while (!helyesErtek)
                    {
                        string valasz = Console.ReadLine();
                        if (valasz.ToLower() == "i")
                        {
                            jatekosFolytat = true;
                            helyesErtek = true;
                        }
                        else if (valasz.ToLower() == "n")
                        {
                            jatekosFolytat = false;
                            helyesErtek = true;
                        }
                        else
                        {
                            Console.WriteLine("Helyes értéket adj meg (i/n): ");
                        }
                    }

                }
            }
            while (gepPont < 17)
            {
                KartyaErtek lap = LapHuzas(false);
                Console.WriteLine($"Gép Húzott lapja:: {lap} (pontok: {gepPont})");
            }
            Eredmeny();
            Console.WriteLine("Szeretnél újra játszani? (i/n)");
            string ujra = Console.ReadLine().ToLower();
            if (ujra == "i")
            {
                jatekosPont = 0;
                gepPont = 0;
                Start();
            }
        }
        private int pontErtek(KartyaErtek lap)
        {
            switch (lap)
            {
                case KartyaErtek.Jumbó:
                case KartyaErtek.Dáma:
                case KartyaErtek.Király:
                    return 10;
                default:
                    return (int)lap;
            }
        }
        private KartyaErtek LapHuzas(bool jatekos)
        {
            KartyaErtek[] lapok = new KartyaErtek[]
            {
                KartyaErtek.Kettő,KartyaErtek.Három,KartyaErtek.Négy,KartyaErtek.Öt,KartyaErtek.Hat,KartyaErtek.Hét,KartyaErtek.Nyolc,KartyaErtek.Kilenc,KartyaErtek.Tíz,KartyaErtek.Ász,KartyaErtek.Jumbó,KartyaErtek.Dáma,KartyaErtek.Király
            };
            KartyaErtek lap = lapok[rnd.Next(lapok.Length)];
            int pont = pontErtek(lap);
            if (lap == KartyaErtek.Ász && jatekos)
            {
                bool ervenyesValasz = false;
                Console.WriteLine("Ászt húztál. 1 vagy 11 pont legyen?");
                while (!ervenyesValasz)
                {
                    string valasz = Console.ReadLine();
                    if (valasz == "1")
                    {
                        pont = 1;
                        ervenyesValasz = true;
                    }
                    else if (valasz == "11")
                    {
                        pont = 11;
                        ervenyesValasz = true;
                    }
                    else
                    {
                        Console.WriteLine("Érvényes választ adj meg! 1 vagy 11!");
                    }
                }
            }
            if (jatekos)
            {
                jatekosPont += pont;
            }
            else
            {
                gepPont += pont;
            }
            return lap;
        }

        private void Eredmeny()
        {
            Console.WriteLine("--- Végeredmény ---");
            Console.WriteLine($"Játékos pontja: {jatekosPont}");
            Console.WriteLine($"Gép pontja: {gepPont}");
            if (jatekosPont > 21)
            {
                Console.WriteLine("Több, mint 21 a lapjaid értéke. Vesztettél!");
            }
            else if (gepPont > 21)
            {
                Console.WriteLine("A gép lapjainak értéke több, mint 21. Nyertél!");
            }
            else if (jatekosPont > gepPont)
            {
                Console.WriteLine("Nyertél!");
            }
            else if (jatekosPont < gepPont)
            {
                Console.WriteLine("Vesztettél!");
            }
            else
            {
                Console.WriteLine("Döntetlen!");
            }
        }
    }
}
