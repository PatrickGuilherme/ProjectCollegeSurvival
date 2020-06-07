using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjetoRPG
{
    public class Worker : PersonagemJogavel
    {
        public Worker()
        {
            this.Nome = "João None Workefield";
            this.Descricao = "Um aluno esforçado que se dedica a ser melhor no que faz";
            this.Life = 300;
            this.MaxLife = 300;
            this.Energia = 500;
            this.MaxEnergia = 500;
            this.Animo = 20;
            this.Persistencia = 15;
            this.Conhecimento = 0;
            this.Nivel = 1;
            this.PosicaoX = 19;
            this.PosicaoY = 2;
            this.MenuCraft = new Craft();
            this.inventario = new Inventario();
            Habilidades = new List<Habilidade>();
            this.StartHabilidade();
         
        }
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
                Persuadir();
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

        public override bool StartHabilidade()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Corte de papel";
            habilidade.Descricao = "Ataque normal do personagem, utiliza folhas de papel afiadas e atira elas no inimigo.";
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

        private void ForcaDoOdio()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Força do Ódio";
            habilidade.Descricao = "Aumenta o status de ânimo durante 1 turno em combate.";
            habilidade.NivelRequerido = 2;
            habilidade.GastoEnergia = 50;
            habilidade.Dano = 0;
            habilidade.BuffLife = 100;
            habilidade.BuffAnimo = 15;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }
        
        private void Persuadir()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Persuadir";
            habilidade.Descricao = "Pule um turno e zoe a cara do inimigo com um blue bull.";
            habilidade.NivelRequerido = 3;
            habilidade.GastoEnergia = this.MaxEnergia/2;
            habilidade.Dano = 0;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = true;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }

        public override bool UsarHabilidade(Habilidade habilidade)// se for atacar com uma habilidade chame essa funcao depois chama a funcao de ataque
        {
            if (habilidade.GastoEnergia <= this.Energia) 
            {
                this.Animo += habilidade.BuffAnimo;
                this.Life += habilidade.BuffLife;
                if (this.MaxLife < this.Life) this.Life = this.MaxLife;  
                this.Persistencia += habilidade.BuffPersistencia;
                this.Energia -= habilidade.GastoEnergia;
                habilidade.Usada = true;
                return true;
            }
            return false;
        }
    }
}
