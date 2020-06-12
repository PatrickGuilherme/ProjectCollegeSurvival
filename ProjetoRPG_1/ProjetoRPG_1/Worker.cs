using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Personagem jogavel - Worker [Life: 300] [Energia: 500]
    /// </summary>
    public class Worker : PersonagemJogavel
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Worker()
        {
            this.Nome = "João None Workefield";
            this.Descricao = "Um aluno esforçado que se dedica a ser melhor no que faz, o personagem tem como destaque sua imensa energia";
            this.Life = 300;
            this.MaxLife = 300;
            this.Energia = 500;
            this.MaxEnergia = 500;
            this.Animo = 20;
            this.Persistencia = 15;
            this.Conhecimento = 0;
            this.Nivel = 1;
            this.PosicaoX = 124;
            this.PosicaoY = 6;
            this.MenuCraft = new Craft();
            this.inventario = new Inventario();
            Habilidades = new List<Habilidade>();
            this.StartHabilidade();
        }

        /// <summary>
        /// Verifica se o personagem subil de nível 
        /// </summary>
        public override void LevelUp()
        {
            if (this.Conhecimento >= 240 && this.Nivel < 2)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 240;
                this.Life = 400;
                this.MaxLife = 400;
                this.Energia = 600;
                this.MaxEnergia = 600;
                this.Animo = 25;
                this.Persistencia = 20;
                this.ForcaDoOdio();
            }
            else if (this.Conhecimento >= 408 && this.Nivel < 3)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 408;
                this.Life = 500;
                this.MaxLife = 500;
                this.Energia = 700;
                this.MaxEnergia = 700;
                this.Animo = 28;
                this.Persistencia = 23;
            }
            else if (this.Conhecimento >= 610 && this.Nivel < 4)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 610;
                this.Life = 600;
                this.MaxLife = 600;
                this.Energia = 800;
                this.MaxEnergia = 800;
                this.Animo = 30;
                this.Persistencia = 25;
                Persuadir();
            }
            else if (this.Conhecimento >= 852 && this.Nivel < 5)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 852;
                this.Life = 700;
                this.MaxLife = 700;
                this.Energia = 900;
                this.MaxEnergia = 900;
                this.Animo = 40;
                this.Persistencia = 35;
            }
        }

        /// <summary>
        /// Inicializa a habilidade de nivel 1 do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Corte de papel";
            habilidade.Descricao = "Ataque utiliza folhas de papel afiadas contra o inimigo.";
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
        /// Habilidade do personagem N2
        /// </summary>
        private void ForcaDoOdio()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Força do Ódio";
            habilidade.Descricao = "Ataque especial que aumenta o ânimo do personagem após uma situação muito estressante.";
            habilidade.NivelRequerido = 2;
            habilidade.GastoEnergia = 120;
            habilidade.Dano = 0;
            habilidade.BuffLife = 100;
            habilidade.BuffAnimo = 10;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }
       
        /// <summary>
        /// Habilidade do personagem N4
        /// </summary>
        private void Persuadir()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Persuadir";
            habilidade.Descricao = "Ataque especial que utiliza lábia do personagem para enganar o inimigo fazendo pensar que ele já atacou.";
            habilidade.NivelRequerido = 4;
            habilidade.GastoEnergia = this.MaxEnergia / 2;
            habilidade.Dano = 0;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = true;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }
    }
}