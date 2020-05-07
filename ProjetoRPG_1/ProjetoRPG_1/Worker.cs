using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProjetoRPG
{
    public class Worker : PersonagemJogavel
    {
        public override void LevelUp()
        {

            if (this.Conhecimento >= 240 && this.Nivel <= 2)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 240;
                this.Life = 400;
                this.Energia = 600;
                this.Animo = 25;
                this.Persistencia = 20;
                this.ForcaDoOdio();
            }
            else if (this.Conhecimento >= 408 && this.Nivel <= 3)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 408;
                this.Life = 500;
                this.Energia = 700;
                this.Animo = 28;
                this.Persistencia = 23;
                Persuadir();
            }
            else if (this.Conhecimento >= 610 && this.Nivel <= 4)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 610;
                this.Life = 600;
                this.Energia = 800;
                this.Animo = 30;
                this.Persistencia = 25;
            }
            else if (this.Conhecimento >= 852 && this.Nivel <= 5)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 852;
                this.Life = 700;
                this.Energia = 900;
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
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 15;
            habilidade.BuffPersistencia = 0;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }
        private void Persuadir()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Persuadir";
            habilidade.Descricao = "Desabilita uma habilidade do inimigo";
            habilidade.NivelRequerido = 3;
            habilidade.GastoEnergia = 100;
            habilidade.Dano = 0;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }

        public Habilidade DesativarHabilidadeInimigo(List<Habilidade> habilidadesInimigo)
        {
            Random randNum = new Random();
            int qtdHabilidades = habilidadesInimigo.Count;
            int PDesabilit = 0;
            while(PDesabilit <= 0 || PDesabilit > qtdHabilidades)
            {
                randNum = new Random();
                PDesabilit = randNum.Next(1, qtdHabilidades);
            }
                
            habilidadesInimigo[PDesabilit].Ativa = false;
            return habilidadesInimigo[PDesabilit];
        }

        public override bool UsarHabilidade(Habilidade habilidade)
        {
            throw new NotImplementedException();
        }
    }
}
