using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Gasefic : Monstro
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Gasefic()
        {
            this.Nome = "Gasefic";
            this.Descricao = "Representação física de vários elementos químicos gasosos. Irrite esse inimigo e conseguirá a fúria de seu mestre ATOM.";
            this.Life = 400 ;
            this.MaxLife = 400;
            this.Energia = 150;
            this.MaxEnergia = 150;
            this.Animo = 30;
            this.Persistencia = 20;
            this.ConhecimentoDrop = 10;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
        }

        /// <summary>
        /// Inicializa a habilidade de todos os níveis do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            fumaca();
            ArremessoQuimico();
            PoDaMorte();
            return true;

        }

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
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

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
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

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
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
    }
}
