using System;
using System.Collections.Generic;

namespace ProjetoRPG
{
    public abstract class Personagem
    {
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Life{ get; set; }
        public int Energia { get; set; }
        public int Animo { get; set; }
        public int Persistencia { get; set; }
        public List<Habilidade> Habilidades { get; set; }

        public abstract bool Atacar(Personagem inimigo, int dano);//dano é sempre negativo

        public abstract bool Defender();

        public abstract bool StartHabilidade();

        public abstract int calculoDano(Personagem inimigo,int dano);//dano é sempre negativo

        public abstract bool UsarHabilidade(string nomeHabilidade);
        
    }
}
