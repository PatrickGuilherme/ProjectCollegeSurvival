using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Cheater : PersonagemJogavel
    {

        public Cheater()
        {
            this.Nome = "Nobody";
            this.Descricao = "Estudante que leva a vida acadêmica muito desleixada. Ele utiliza táticas “alternativas” para sobreviver, tendo grande life.";
            this.Life = 500;
            this.MaxLife = 500;
            this.Energia = 300;
            this.MaxEnergia = 300;
            this.Animo = 17;
            this.Persistencia = 18;
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
                this.Life = 600;
                this.MaxLife = 600;
                this.Energia = 400;
                this.MaxEnergia = 400;
                this.Animo = 22;
                this.Persistencia = 23;
                Migue();
            }
            else if (this.Conhecimento >= 408 && this.Nivel < 3)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 408;
                this.Life = 700;
                this.MaxLife = 700;
                this.Energia = 500;
                this.MaxEnergia = 500;
                this.Animo = 26;
                this.Persistencia = 25;
                Colar();
            }
            else if (this.Conhecimento >= 610 && this.Nivel < 4)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 610;
                this.Life = 800;
                this.MaxLife = 800;
                this.Energia = 600;
                this.MaxEnergia = 600;
                this.Animo = 27;
                this.Persistencia = 28;
            }
            else if (this.Conhecimento >= 852 && this.Nivel < 5)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 852;
                this.Life = 900;
                this.MaxLife = 900;
                this.Energia = 700;
                this.MaxEnergia = 700;
                this.Animo = 38;
                this.Persistencia = 37;
            }
        }

        public override bool StartHabilidade()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Canetada";
            habilidade.Descricao = "Ataque normal do personagem, utiliza uma arma em sua mão(ou sua própria mão) para desferir um golpe no inimigo.";
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

        private void Migue()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Migué";
            habilidade.Descricao = "Aura roxa emana do personagem e ele desabilita durante uma rodada uma habilidade aleatória do inimigo (exceto o ataque normal)";
            habilidade.NivelRequerido = 2;
            habilidade.GastoEnergia = 60;
            habilidade.Dano = 0;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = true;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }// NIVEL 2

        private void Colar()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Colar";
            habilidade.Descricao = "Rouba o ânimo do inimigo para si (se o inimigo não tiver animo o suficiente será descontado o valor restante em seu Life.";
            habilidade.NivelRequerido = 3;
            habilidade.GastoEnergia = 25;
            habilidade.Dano = 0;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 15;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }//NIVEL 3

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
