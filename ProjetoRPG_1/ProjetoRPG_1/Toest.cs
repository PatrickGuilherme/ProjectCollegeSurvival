using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Toest : Monstro
    {
        public Toest() {
            this.Nome = "T.O.E.S.T";
            this.Descricao = "T.O.E.S.T, a representação de elegância formal e zoeira, filho de uma entidade primordial chamada T.O.S.T.A .";
            this.Life = 850;
            this.MaxLife = 850;
            this.Energia = 350;
            this.MaxEnergia = 350;
            this.Animo = 30;
            this.Persistencia = 25;
            this.ConhecimentoDrop = 160;
            this.Habilidades = new List<Habilidade>();
            this.StartHabilidade();
            this.IniciarItemDrop();
        }
        private void IniciarItemDrop() {
            ItemSecundario ip = new ItemSecundario(7);
            this.ItemDrop = ip;
        }
        public bool PiadaMortal() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Piada MOrtal";
            habilidade.Descricao = "Piada que ao ser ouvida causa desconforto no inimigo.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 0;
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
        public bool LaserVerde() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Laser Verde";
            habilidade.Descricao = " Ataque com luz mortal que corta tudo em seu caminho.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 40;
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
        public bool AtaqueEstatistico() {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Ataque Estatístico";
            habilidade.Descricao = " Ataque de confusão mental causando danos mentais.";
            habilidade.NivelRequerido = 1;
            habilidade.GastoEnergia = 43;
            habilidade.Dano = 23;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 0;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
            return true;
        }
        public override bool StartHabilidade() {
            PiadaMortal();
            LaserVerde();
            AtaqueEstatistico();
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
