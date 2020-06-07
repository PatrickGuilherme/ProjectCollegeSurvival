using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Aculo : Monstro
    {
       public bool Descaucular() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Descaucular";
            habilidade.Descricao = " Demostra a inferioridade do adversario, quebrando sua mente    .";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 13;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        public bool Edo() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "EDO";
            habilidade.Descricao = "Ataque de dano duplo no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 50;
            habilidade.Dano = 18;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        public bool Desintegrar() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Desintegrar";
            habilidade.Descricao = " Ataque de larga escala.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 70;
            habilidade.Dano = 20;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        public override bool StartHabilidade()
        {
            Descaucular();
            Edo();
            Desintegrar();
            return true;
        }

        public override bool UsarHabilidade(Habilidade habilidade)
        {
            this.Animo += habilidade.BuffAnimo;
            this.Life += habilidade.BuffLife;
            this.Persistencia += habilidade.BuffPersistencia;
            habilidade.Usada = true;
            return true;
        }
    }
}

