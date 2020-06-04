using System;
using System.Collections.Generic;

namespace ProjetoRPG
{
    public class Atom : Monstro
    {
     
        public Atom()
        {
            this.Nome = "ATOM";
            this.Descricao = "ATOM, o antigo professor de química, que após a explosão de seu laboratório tornou - se um ser de pura maldade.";
            this.Life = 700;
            this.MaxLife = 700;
            this.Energia = 300;
            this.MaxEnergia = 300;
            this.Animo = 25;
            this.Persistencia = 20;
            this.ConhecimentoDrop = 60;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
            this.IniciarItemDrop();
        }
        private void IniciarItemDrop()
        {
            ItemPrimario ip = new ItemPrimario();
            ip.BuffAnimo = 0;
            ip.BuffEnergia = 0;
            ip.BuffLife = 0;
            ip.Dano = 0;
            ip.NivelRequerido = 1;
            ip.Descricao = "Mecanismo eletrônico para criar itens eletrônicos.";
            ip.Nome = "Mecanismo Eletrônico";
            this.ItemDrop = ip;
        }
        public override bool StartHabilidade()
        {
            throw new NotImplementedException();
            throw new NotImplementedException();
        }

        public override bool UsarHabilidade(Habilidade habilidade)
        {
            throw new NotImplementedException();
        }
    }
}
