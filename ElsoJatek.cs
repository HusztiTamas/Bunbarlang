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
                    string valasz = Console.ReadLine();
                    if (valasz.ToLower() != "i")
                    {
                        jatekosFolytat = false;
                    }
                }
            }
            while (gepPont < 17)
            {
                KartyaErtek lap = LapHuzas(false);
                Console.WriteLine($"Gép Húzott lapja:: {lap} (pontok: {gepPont})");
            }
            Console.WriteLine("--- Végeredmény ---");
            Console.WriteLine($"Játékos pontja: {jatekosPont}");
            Console.WriteLine($"Gép pontja: {gepPont}");
            Eredmeny();
            Console.ReadKey();
        }

        private KartyaErtek LapHuzas(bool jatekos)
        {
            int lapszam = rnd.Next(2, 15);
            KartyaErtek lap = (KartyaErtek)lapszam;
            int pont = (int)lap;
            if (lap == KartyaErtek.Ász && jatekos)
            {
                Console.WriteLine("Ászt húztál. 1 vagy 11 pont legyen?");
                string valasz = Console.ReadLine();
                if (valasz == "1")
                {
                    pont = 1;
                }
                else
                {
                    pont = 11;
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
