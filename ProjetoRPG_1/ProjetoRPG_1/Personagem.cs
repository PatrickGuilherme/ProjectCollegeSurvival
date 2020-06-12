using System;
using System.Collections.Generic;

namespace ProjetoRPG
{
    /// <summary>
    /// Classe com atributos padrões de todos os jogadores e monstros.
    /// </summary>
    public abstract class Personagem
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Life { get; set; }
        public int MaxLife { get; set; }
        public int Energia { get; set; }
        public int MaxEnergia { get; set; }
        public int Animo { get; set; }
        public int MaxAnimo { get; set; }
        public int Persistencia { get; set; }
        public int MaxPersistencia { get; set; }
        public List<Habilidade> Habilidades { get; set; }
        
        /// <summary>
        /// Metodo quando inicia um combate entre dois personagens.
        /// </summary>
        public int Atacar(Personagem inimigo, Item item, Habilidade habilidade)
        {   
            //Verifica se há um inimigo para atacar
            if(inimigo != null)
            {
                //Calcular dano do item
                int danoInfligido = 0;
                if (item != null)
                {
                    if (item.Dano > 0)
                    {
                        danoInfligido = CalculoDano(inimigo, item.Dano);
                    }
                }
                //Calcular dano da habilidade
                else if (habilidade != null)
                {
                    if (habilidade.Dano > 0)
                    {
                        
                        danoInfligido = CalculoDano(inimigo, habilidade.Dano);
                    }
                }
                //Se houve dano este deve ser retornado
                if (danoInfligido > 0)
                {
                    inimigo.Life -= danoInfligido;
                    return danoInfligido;
                }
            }
            return 0;
        }

        /// <summary>
        /// Metodo de calcular o dano infligido no inimigo 
        /// </summary>
        public int CalculoDano(Personagem inimigo, int dano) 
        {   
            //Inicializa uma atividade
            int danoTotal = dano + this.Animo;
            int defesaInimigo = inimigo.Persistencia;
            int danoInfligido = 0;

            //O dano é maior que a defesa
            if (danoTotal >= defesaInimigo)
            {
                danoInfligido = danoTotal - defesaInimigo;
            }

            return danoInfligido;
        }

        public abstract bool StartHabilidade();

        /// <summary>
        /// Aplica os buffers de habilidades no status do personagem
        /// </summary>
        public bool UsarHabilidade(Habilidade habilidade)
        {
            if (habilidade.GastoEnergia <= this.Energia)
            {
                this.Animo += habilidade.BuffAnimo;
                this.Life += habilidade.BuffLife;
                if (this.MaxLife < this.Life) this.Life = this.MaxLife;
                this.Persistencia += habilidade.BuffPersistencia;
                this.Energia -= habilidade.GastoEnergia;
                habilidade.Usada = true;
                return true;
            }
            return false;
        }
    }
}
