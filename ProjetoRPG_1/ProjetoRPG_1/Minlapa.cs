using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Monstro - Minlapa [Life: 550] [Energia: 450]
    /// </summary>
    public class Minlapa : Monstro
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Minlapa()
        {
            this.Nome = "Minlapa";
            this.Descricao = "Lapain ao derrotar um inimigo o transforma em seus súditos, os guerreiros derrotados tornam-se Minlapas que contaminam a mente de seus adversários com pogs computacionais.";
            this.Life = 550;
            this.MaxLife = 550;
            this.Energia = 450;
            this.MaxEnergia = 450;
            this.Animo = 20;
            this.Persistencia = 10;
            this.ConhecimentoDrop = 52;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
        }

        /// <summary>
        /// Inicializa a habilidade de todos os níveis do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            Bigbig();
            ReversaoLogica();
            return true;
        }

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool Bigbig()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Big-big";
            habilidade.Descricao = "Misseis de big big que explodem e causam danos no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
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

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool ReversaoLogica()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Reversão lógica";
            habilidade.Descricao = "Converte energia em life.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 60;
            habilidade.Dano = 0;
            habilidade.BuffLife = 20;
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
