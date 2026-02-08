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
            bool ujra = true;
            while (ujra)
            {
                jatekosPont = 0;
                gepPont = 0;
                Console.Clear();
                Console.WriteLine("Black Jack\n");
                List<KartyaErtek> jatekoslapok = new List<KartyaErtek>();
                List<KartyaErtek> geplapok = new List<KartyaErtek>();
                jatekoslapok.Add(LapHuzas(true));
                jatekoslapok.Add(LapHuzas(true));
                geplapok.Add(LapHuzas(false));
                geplapok.Add(LapHuzas(false));
                KiirJatekosLapok(jatekoslapok);
                KiirGepLapok(geplapok, true);
                if (jatekosPont == 21 || GepPont == 21)
                {
                    KiirJatekosLapok(jatekoslapok);
                    KiirGepLapok(geplapok, false);
                    Eredmeny();
                }
                else
                {
                    bool jatekosFolytat = true;
                    while (jatekosFolytat && JatekosPont < 21)
                    {
                        Console.WriteLine("Kérsz még lapot? (i/n): ");
                        bool helyesErtek = false;
                        while (!helyesErtek)
                        {
                            string valasz = Console.ReadLine().ToLower();
                            if (valasz == "i")
                            {
                                KartyaErtek lap = LapHuzas(true);
                                helyesErtek = true;
                                jatekoslapok.Add(lap);
                                KiirJatekosLapok(jatekoslapok);
                                if (jatekosPont >= 21)
                                {
                                    jatekosFolytat = false;

                                }
                            }
                            else if (valasz == "n")
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
                    Console.WriteLine("\nAz osztó felfedi a lapjait:");
                    KiirGepLapok(geplapok, false);
                    while (gepPont < 17)
                    {
                        KartyaErtek lap = LapHuzas(false);
                        geplapok.Add(lap);
                        KiirGepLapok(geplapok, false);
                    }
                    Eredmeny();
                }
                Console.WriteLine("\nSzeretnél újra játszani? (i/n)");
                string ujravalasz = Console.ReadLine().ToLower();
                if (ujravalasz != "i")
                {
                    ujra = false;
                }
            }
        }

        private void KiirJatekosLapok(List<KartyaErtek> lapok)
        {
            Console.WriteLine("\n=============================");
            Console.Write($"Játékos lapjai: ");
            Console.WriteLine("=============================");
            foreach (var lap in lapok)
            {
                Console.Write($"[{lap}] ");
            }
            Console.WriteLine($"(pontok: {jatekosPont})");
            Console.WriteLine("=============================");
        }

        private void KiirGepLapok(List<KartyaErtek> lapok, bool elsoLapRejtve = false)
        {
            Console.WriteLine("\n=============================");
            Console.Write($"Gép lapjai: ");
            Console.WriteLine("=============================");
            for (int i = 0; i < lapok.Count; i++)
            {
                if (i == 0 && elsoLapRejtve)
                {
                    Console.Write($"[?] ");
                }
                else
                {
                    Console.Write($"[{lapok[i]}]");
                }
            }
            if (elsoLapRejtve)
            {
                Console.WriteLine("\nPontok: ? + ...");
            }
            Console.WriteLine($"(pontok: {gepPont})");
            Console.WriteLine("\n=============================");
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
