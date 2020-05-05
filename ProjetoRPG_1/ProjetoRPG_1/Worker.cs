using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Worker : PersonagemJogavel
    {
        public override bool Atacar(Personagem inimigo, int dano)
        {
            throw new NotImplementedException();
        }

        public override int calculoDano(Personagem inimigo, int dano)
        {
            throw new NotImplementedException();
        }

        public override bool Defender()
        {
            throw new NotImplementedException();
        }

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
            }
            else if (this.Conhecimento >= 408 && this.Nivel <= 3)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 408;
                this.Life = 500;
                this.Energia = 700;
                this.Animo = 28;
                this.Persistencia = 23;
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
            return true;
        }

        public override bool UsarHabilidade()
        {
            throw new NotImplementedException();
        }
    }
}
