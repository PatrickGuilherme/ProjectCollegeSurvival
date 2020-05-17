using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Gasefic : Monstro
    {

        public bool fumaca()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "fumaca";
            habilidade.Descricao = " utiliza folhas de papel afiadas e atira elas no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 5;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }

        public bool ArremessoQuimico()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Arremesso químico";
            habilidade.Descricao = " Ataque utilizando vidrarias e lançando elas contra o inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 25;
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

        public bool PoDaMorte()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Pó da Morte";
            habilidade.Descricao = " Ataque de grande dano ao inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 35;
            habilidade.Dano = 15;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
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

        public override bool StartHabilidade()
        {
            fumaca();
            ArremessoQuimico();
            PoDaMorte();
            return true;
            
        }
    }
}
