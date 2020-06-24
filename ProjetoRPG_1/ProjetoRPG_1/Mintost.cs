using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Monstro - Mintost [Life: 450] [Energia: 200]
    /// </summary>
    public class Mintost : Monstro
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Mintost()
        {
            this.Nome = "Mintosta";
            this.Descricao = "Seguidores implacáveis do mestre TOEST. O que eles não têm em força eles possuem em inteligência. Tome cuidado com seu mestre.";
            this.Life = 450;
            this.MaxLife = 450;
            this.Energia = 200;
            this.MaxEnergia = 200;
            this.Animo = 35;
            this.Persistencia = 25;
            this.ConhecimentoDrop = 54;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
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
        /// Habilidade do personagem 
        /// </summary>
        public bool PiadaMortal() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Piada Mortal";
            habilidade.Descricao = "Piada que ao ser ouvida causa desconforto no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 7;
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
            habilidade.Descricao = " Ataque com luz mortal que corta tudo em seu caminho.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 30;
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
        public bool AtaqueEstatistico() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Ataque Estatístico";
            habilidade.Descricao = " Ataque de confusão mental causando danos mentais.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 25;
            habilidade.Dano = 17;
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
