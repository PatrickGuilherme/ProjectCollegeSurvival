using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Monstro - Anaculo [Life: 850] [Energia: 350]
    /// </summary>
    public class Toest : Monstro
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Toest() {
            this.Nome = "Toest";
            this.Descricao = "Um monstro que em momentos pode ser seu inimigo e em outros pode ser neutro, ele é muito brincalhão e irá testar a paciência de seu adversário, suas origens ligam-se a uma divindade antiga chamada Tosta.";
            this.Life = 850;
            this.MaxLife = 850;
            this.Energia = 350;
            this.MaxEnergia = 350;
            this.Animo = 30;
            this.Persistencia = 25;
            this.ConhecimentoDrop = 160;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
            this.IniciarItemDrop();
        }

        /// <summary>
        /// Inicializa a habilidade de todos os níveis do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            PiadaMortal();
            LaserVerde();
            AtaqueEstatistico();
            return true;
        }

        /// <summary>
        /// Define um item que será dropado pelo monstro ao ser derrotado
        /// </summary>
        private void IniciarItemDrop() {
            this.ItemDrop = new ItemSecundario(7);
        }

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool PiadaMortal() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Piada Mortal";
            habilidade.Descricao = "Piada que ao ser ouvida causa desconforto crises mentais no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 12;
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
        public bool LaserVerde() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Laser Verde";
            habilidade.Descricao = "Ataque com luz mortal que corta tudo em seu caminho.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 40;
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

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool AtaqueEstatistico() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Ataque Estatístico";
            habilidade.Descricao = "Ataque de confusão mental causando danos mentais através de números.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 50;
            habilidade.Dano = 30;
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
