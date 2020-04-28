using System;

namespace ProjetoRPG
{
    public class GameObject
    {
        public Personagem P { get; set; }
        public Item I { get; set; }
        public bool O { get; set; }
        public int Linha { get; set; }
        public int Coluna { get; set; }
    }
}
