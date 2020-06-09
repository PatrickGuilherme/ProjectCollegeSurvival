using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Mintost : Monstro
    {
        public bool PiadaMortal() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Piada MOrtal";
            habilidade.Descricao = "Piada que ao ser ouvida causa desconforto no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
            habilidade.Dano = 7;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        public bool LaserVerde() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Laser Verde";
            habilidade.Descricao = " Ataque com luz mortal que corta tudo em seu caminho.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 30;
            habilidade.Dano = 12;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        public bool AtaqueEstatistico() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Ataque Estatístico";
            habilidade.Descricao = " Ataque de confusão mental causando danos mentais.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 25;
            habilidade.Dano = 17;
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
            PiadaMortal();
            LaserVerde();
            AtaqueEstatistico();
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
