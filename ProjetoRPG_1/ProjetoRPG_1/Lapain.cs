using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Lapain : Monstro
    {
        public Lapain() {
            this.Nome = "Lapa-In";
            this.Descricao = "LAPA-IN, a potência em programação, especialista em confusão logica.Ele é rival mortal de um monstro chamado J.S referenciar ele em batalha, deixará LAPA-IN furioso..";
            this.Life = 950;
            this.MaxLife = 950;
            this.Energia = 650;
            this.MaxEnergia = 650;
            this.Animo = 35;
            this.Persistencia = 30;
            this.ConhecimentoDrop = 380;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
        }

        public bool Bigbig() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Big-big";
            habilidade.Descricao = "Atira big-bigs explosivos.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 15;
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
            habilidade.GastoEnergia = 70;
            habilidade.Dano = 21;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        //Falta esse Método
        //public bool Pogear()
        public override bool StartHabilidade() {
            Bigbig();
            ReversaoLogica();
            return true;
        }

        public override bool UsarHabilidade(Habilidade habilidade) {
            this.Animo += habilidade.BuffAnimo;
            this.Life += habilidade.BuffLife;
            this.Persistencia += habilidade.BuffPersistencia;
            habilidade.Usada = true;
            return true;
        }
    }
}
