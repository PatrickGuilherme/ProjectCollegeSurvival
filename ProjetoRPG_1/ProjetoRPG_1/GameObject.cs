using System;

namespace ProjetoRPG
{
    public class GameObject
    {
        public Personagem Personagem { get; set; }
        public Monstro Monstro { get; set; }
        public Item Item { get; set; }
        public bool Ocupado { get; set; }
        public int Linha { get; set; }
        public int Coluna { get; set; }
        public int[] Deslocamento { get; set; }
    }
}
