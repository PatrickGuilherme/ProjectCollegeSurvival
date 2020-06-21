using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    /// <summary>
    /// Personagem jogavel - Cheater [Life: 500] [Energia: 300]
    /// </summary>
    public class Cheater : PersonagemJogavel
    {
        /// <summary>
        /// Construtor da classe para instância 
        /// </summary>
        public Cheater()
        {
            this.Nome = "No body Cheafer";
            this.Descricao = "Estudante que leva a vida acadêmica muito desleixada. Ele utiliza táticas “alternativas” para sobreviver, tendo grande life.";
            this.Life = 500;
            this.MaxLife = 500;
            this.Energia = 300;
            this.MaxEnergia = 300;
            this.Animo = 42;
            this.Persistencia = 43;
            this.Conhecimento = 0;
            this.Nivel = 1;
            this.PosicaoX = 124;
            this.PosicaoY = 6;
            this.MenuCraft = new Craft();
            this.inventario = new Inventario();
            Habilidades = new List<Habilidade>();
            EquipamentosEquipados = new List<Equipamento>();
            this.StartHabilidade();
        }

        /// <summary>
        /// Verifica se o personagem subil de nível 
        /// </summary>
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
                this.Animo = 47;
                this.Persistencia = 48;
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
                this.Animo = 51;
                this.Persistencia = 50;
            }
            else if (this.Conhecimento >= 610 && this.Nivel < 4)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 610;
                this.Life = 800;
                this.MaxLife = 800;
                this.Energia = 600;
                this.MaxEnergia = 600;
                this.Animo = 56;
                this.Persistencia = 55;
                Colar();
            }
            else if (this.Conhecimento >= 852 && this.Nivel < 5)
            {
                this.Nivel++;
                this.Conhecimento = this.Conhecimento - 852;
                this.Life = 900;
                this.MaxLife = 900;
                this.Energia = 700;
                this.MaxEnergia = 700;
                this.Animo = 61;
                this.Persistencia = 60;
            }
        }

        /// <summary>
        /// Inicializa a habilidade de nivel 1 do personagem
        /// </summary>
        public override bool StartHabilidade()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Estocada";
            habilidade.Descricao = "Ataque normal do personagem, utiliza uma arma em sua mão(ou sua própria mão) para desferir um golpe na barriga do inimigo.";
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

        /// <summary>
        /// Habilidade do personagem N2
        /// </summary>
        private void Migue()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Migue";
            habilidade.Descricao = "Ataque especial que utiliza lábia para enganar o inimigo fazendo pensar que ele já atacou.";
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
        }

        /// <summary>
        /// Habilidade do personagem N4
        /// </summary>
        private void Colar()
        {
            Habilidade habilidade = new Habilidade();
            habilidade.Nome = "Colar";
            habilidade.Descricao = "Ataque especial que aumenta sua persistência, deixando o personagem pronto para colar em provas afetando os sentidos do inimigo.";
            habilidade.NivelRequerido = 4;
            habilidade.GastoEnergia = 120;
            habilidade.Dano = 15;
            habilidade.BuffLife = 0;
            habilidade.BuffAnimo = 0;
            habilidade.BuffPersistencia = 5;
            habilidade.DesativaHabilidade = false;
            habilidade.Usada = false;
            habilidade.Ativa = true;
            this.Habilidades.Add(habilidade);
        }

    }
}
