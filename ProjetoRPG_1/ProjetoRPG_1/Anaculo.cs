using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Monstro - Anaculo [Life: 1000] [Energia: 830]
    /// </summary>
    public class Anaculo : Monstro
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Anaculo() {
            this.Nome = "Anaculo";
            this.Descricao = "Anaculo é a entidade maligna suprema existente desde tempos imemoriais atormentando a vida de estudantes, é dito que é um inimigo que nunca foi derrotado e já mandou diversos estudantes para um looping sem fim fazendo-os repetir seus maiores medos.";
            this.Life = 1000;
            this.MaxLife = 1000;
            this.Energia = 830;
            this.MaxEnergia = 830;
            this.Animo = 40;
            this.Persistencia = 35;
            this.ConhecimentoDrop = 512;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
        }

        /// <summary>
        /// Inicializa a habilidade de todos os níveis do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            Descaucular();
            EstalarDeMentes();
            Edo();
            return true;
        }

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool Descaucular() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Descaucular";
            habilidade.Descricao = "Reverte a compreensão do inimigo fazendo entrar em choque sobre seus conhecimentos gerais.";
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
        public bool Edo() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "EDO";
            habilidade.Descricao = "Ataque de dano duplo, que enfraquece o inimigo e fortalece o personagem.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 100;
            habilidade.Dano = 20;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 5;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool EstalarDeMentes() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Estalar de Mentes";
            habilidade.Descricao = "O estalar de mentes é um ataque que irá atormentar eternamente o inimigo no combate.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 200;
            habilidade.Dano = 35;
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
