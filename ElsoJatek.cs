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

            KartyaErtek jatekoslap = LapHuzas(true);
            KartyaErtek geplap = LapHuzas(false);

            Console.WriteLine($"Játékos lapja: {jatekoslap} (pont: {jatekosPont})");
            Console.WriteLine($"Gép lapja: {geplap} (pont: {gepPont})");
            //eredmeny kiirasa
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
    }
}
