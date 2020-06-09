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
        public bool fumaca() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "fumaca";
            habilidade.Descricao = " utiliza folhas de papel afiadas e atira elas no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 10;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }

        public bool ArremessoQuimico() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Arremesso químico";
            habilidade.Descricao = " Ataque utilizando vidrarias e lançando elas contra o inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 50;
            habilidade.Dano = 20;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }

        public bool PoDaMorte() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Pó da Morte";
            habilidade.Descricao = " Ataque de grande dano ao inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 70;
            habilidade.Dano = 25;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        public override bool StartHabilidade()
        {
            fumaca();
            ArremessoQuimico();
            PoDaMorte();
            return true;
        }

        public override bool UsarHabilidade(Habilidade habilidade)
        {
            this.Animo += habilidade.BuffAnimo;
            this.Life += habilidade.BuffLife;
            this.Persistencia += habilidade.BuffPersistencia;
            habilidade.Usada = true;
            return true;
        }
    }
}
