using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Minlapa : Monstro
    {
        public bool Bigbig() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Big-big";
            habilidade.Descricao = "Atira big-bigs explosivos.";
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

        public bool ReversaoLogica() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Reversão lógica";
            habilidade.Descricao = "Ataque direcionado a mente do inimigo, destruindo seu conceito lógico.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 50;
            habilidade.Dano = 14;
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
            Bigbig();
            ReversaoLogica();
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
