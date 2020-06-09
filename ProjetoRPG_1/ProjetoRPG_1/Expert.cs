using System;
using System.Collections.Generic;
using System.Xml;

namespace ProjetoRPG
{

    public class Expert : PersonagemJogavel
    {

        public Expert()
        {
            this.Nome = "Tais Fubica";
            this.Descricao = "Uma estudante prodígio que demonstra uma grande perícia em sobrevivência. Ela possui muita persistência.";
            this.Life = 400;
            this.MaxLife = 400;
            this.Energia = 400;
            this.MaxEnergia = 400;
            this.Animo = 15;
            this.Persistencia = 20;
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
            if (this.Conhecimento >= 240 && this.Nivel <= 2)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 240;
                this.Life = 500;
                this.MaxLife = 500;
                this.Energia = 500;
                this.MaxEnergia = 500;
                this.Animo = 20;
                this.Persistencia = 25;
                this.ResolucaoSuprema();
            }
            else if (this.Conhecimento >= 408 && this.Nivel <= 3)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 408;
                this.Life = 600;
                this.MaxLife = 600;
                this.Energia = 600;
                this.MaxEnergia = 600;
                this.Animo = 23;
                this.Persistencia = 28;
            }
            else if (this.Conhecimento >= 610 && this.Nivel <= 4)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 610;
                this.Life = 700;
                this.MaxLife = 700;
                this.Energia = 700;
                this.MaxEnergia = 700;
                this.Animo = 25;
                this.Persistencia = 30;
                this.Concentracao();
            }
            else if (this.Conhecimento >= 852 && this.Nivel <= 5)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 852;
                this.Life = 800;
                this.MaxLife = 800;
                this.Energia = 800;
                this.MaxEnergia = 800;
                this.Animo = 35;
                this.Persistencia = 40;
            }
        }

        public override bool StartHabilidade()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Resolução";
            habilidade.Descricao = "Ataque normal do personagem. Utiliza uma arma em sua mão (ou sua propria mão) para escrever uma resolução para um problema lançado pelo inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 13;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.Usada = false;
            habilidade.Ativa = false;
            Habilidades.Add(habilidade);
            return true;
        }

        private void ResolucaoSuprema()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Resolução SUPREMA";
            habilidade.Descricao = "Ataque especial do personagem. Utiliza sua capacidade mental máxima para alcançar o a resolução final.";
            habilidade.NivelRequerido = 2;
            habilidade.GastoEnergia = 45;
            habilidade.Dano = 18;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.Usada = false;
            habilidade.Ativa = false;
            this.Habilidades.Add(habilidade);
        } //NIVEL 2

        private void Concentracao()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Concentração";
            habilidade.Descricao = "Foque na situação. O personagem recebe um aumento de sua persistência.";
            habilidade.NivelRequerido = 4;
            habilidade.GastoEnergia = 30;
            habilidade.Dano = 0;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 15;
            habilidade.Usada = false;
            habilidade.Ativa = false;
            this.Habilidades.Add(habilidade);
        } //NIVEL 4

        public override bool UsarHabilidade(Habilidade habilidade)
        {
            if (habilidade.GastoEnergia <= this.Energia)
            {
                this.Animo += habilidade.BuffAnimo;
                this.Life += habilidade.BuffLife;
                if (this.MaxLife < this.Life) this.Life = this.MaxLife;
                this.Persistencia += habilidade.BuffPersistencia;
                habilidade.Usada = true;
                return true;
            }
            return false;
        }
    }
}
