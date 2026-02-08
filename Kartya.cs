using System;
using System.Collections.Generic;
using System.Text;

namespace Bűnbarlang
{
    internal class Kartya
    {
        public KartyaErtek Ertek { get; private set; }
        public Kartya(KartyaErtek ertek)
        {
            Ertek = ertek;
        }
        public int Pont()
        {
            switch (Ertek)
            {
                case KartyaErtek.Jumbó:
                case KartyaErtek.Dáma:
                case KartyaErtek.Király:
                    return 10;
                default:
                    return (int)Ertek;
            }
        }
        public override string ToString()
        {
            return Ertek.ToString();
        }
    }
}
