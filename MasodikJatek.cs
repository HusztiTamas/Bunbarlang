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
            slot = new List<string>("9","10","J","Q","K","A","🍒","🍋","🍊","🍉","🍇","777");
        }

        public int JatekosPenz { get => jatekosPenz; set => jatekosPenz = value; }
        public int Probalkozasok { get => probalkozasok; set => probalkozasok = value; }
        public Random Rnd { get => rnd; set => rnd = value; }
        public List<string> Slot { get => slot; set => slot = value; }
    }
}
