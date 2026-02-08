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

        public ElsoJatek(int jatekosPont, int gepPont)
        {
            this.jatekosPont = jatekosPont;
            this.gepPont = gepPont;
            jatekosPont = 0;
            gepPont = 0;
        }

        public int JatekosPont { get => jatekosPont; set => jatekosPont = value; }
        public int GepPont { get => gepPont; set => gepPont = value; }

        public void Start()
        {
            Random rnd = new Random();

        }
    }
}
