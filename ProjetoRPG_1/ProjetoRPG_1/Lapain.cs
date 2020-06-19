using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Monstro - Lapin [Life: 950] [Energia: 650]
    /// </summary>
    public class Lapain : Monstro
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Lapain() {
            this.Nome = "Lapain";
            this.Descricao = "A potência em programação, especialista em confusão logica. Ele é rival mortal de um monstro chamado J.S referenciar ele em batalha, deixará LAPA-IN furioso.";
            this.Life = 950;
            this.MaxLife = 950;
            this.Energia = 650;
            this.MaxEnergia = 650;
            this.Animo = 35;
            this.Persistencia = 30;
            this.ConhecimentoDrop = 150;
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
        public bool Bigbig() {
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
        public bool ReversaoLogica() {
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

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool Poguear()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Poguear";
            habilidade.Descricao = "Ataque que causa dano no inimigo e aprimora o personagem.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 200;
            habilidade.Dano = 20;
            habilidade.BuffLife = 10;
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
