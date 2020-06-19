using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Monstro - Lapin [Life: 550] [Energia: 300]
    /// </summary>
    public class Aculo : Monstro
    {
        /// <summary>
        /// Construtor da classe para inst�ncia 
        /// </summary>
        public Aculo()
        {
            this.Nome = "Aculo";
            this.Descricao = "Aculo � uma criatura que serve a anaculo mantendo a ordem no abismo da repeti��o de mat�ria, garantindo que ningu�m ir� sair do abismo com vida. Eles n�o hesitaram em atacar ningu�m que se oponha ao anaculo.";
            this.Life = 550;
            this.MaxLife = 550;
            this.Energia = 300;
            this.MaxEnergia = 300;
            this.Animo = 40;
            this.Persistencia = 10;
            this.ConhecimentoDrop = 200;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
        }

        /// <summary>
        /// Inicializa a habilidade de todos os n�veis do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            Descaucular();
            Edo();
            EstalarDeMentes();
            return true;
        }

        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool Descaucular() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Descaucular";
            habilidade.Descricao = "Reverte a compreens�o do inimigo fazendo entrar em choque sobre seus conhecimentos gerais.";
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
            habilidade.GastoEnergia = 50;
            habilidade.Dano = 15;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 1;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
       
        /// <summary>
        /// Habilidade do personagem 
        /// </summary>
        public bool EstalarDeMentes()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Estalar de Mentes";
            habilidade.Descricao = "O estalar de mentes � um ataque que ir� atormentar eternamente o inimigo no combate.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 55;
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

