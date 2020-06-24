using System;
using System.Collections.Generic;

namespace ProjetoRPG
{
    /// <summary>
    /// Monstro - Atom [Life: 700] [Energia: 300]
    /// </summary>
    public class Atom : Monstro
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Atom()
        {
            this.Nome = "ATOM";
            this.Descricao = "Monstro que inferniza os estudantes com seus experimentos que envolviam contaminação e redução de tempo de vida, fazendo aulas muito cansativas e mortais.";
            this.Life = 700;
            this.MaxLife = 700;
            this.Energia = 300;
            this.MaxEnergia = 300;
            this.Animo = 50;
            this.Persistencia = 20;
            this.ConhecimentoDrop = 90;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
            this.IniciarItemDrop();
        }

        /// <summary>
        /// Inicializa a habilidade de todos os níveis do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            fumaca();
            AlteracaoQuimica();
            PoDaMorte();
            return true;
        }

        /// <summary>
        /// Define um item que será dropado pelo monstro ao ser derrotado
        /// </summary>
        private void IniciarItemDrop()
        {
            this.ItemDrop = new ItemPrimario(9);
        }

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool fumaca() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Fumaça";
            habilidade.Descricao = "Ataque normal do personagem, utilizando uma nuvem toxica que infecta todos ao seu redor, sufocando o inimigo.";
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

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool AlteracaoQuimica() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Alteração Química";
            habilidade.Descricao = "Altera as propriedades do corpo do personagem regenerando sua vida.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 80;
            habilidade.Dano = 0;
            habilidade.BuffLife = 15;
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
        public bool PoDaMorte() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Pó da Morte";
            habilidade.Descricao = "Pó de restos de almas de estudantes mortos infecta o inimigo e o arrasta para o abismo sem fim da repetição de matéria.";
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
    }
}
