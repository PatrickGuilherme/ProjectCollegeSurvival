using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public abstract class Monstro: Personagem
    {
        public int ConhecimentoDrop { get; set; }
        public Item ItemDrop { get; set; }
    }
}
