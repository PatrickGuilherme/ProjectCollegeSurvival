using System;
using System.Collections.Generic;

namespace ProjetoRPG
{
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
        
        //atacar recebe o inimigo, o nome do item ou o nome da habilidade
        public int atacar(Personagem inimigo, Item item, Habilidade habilidade)
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
                        danoInfligido = calculoDano(inimigo, item.Dano);
                    }
                }

                //Calcular dano da habilidade
                else if (habilidade != null)
                {
                    if (habilidade.Dano > 0)
                    {
                        danoInfligido = calculoDano(inimigo, habilidade.Dano);
                    }
                    //verifica se a habiliidade é do tipo de imcapacitar habilidade
                    if (habilidade.DesativaHabilidade)
                    {
                        return DesativarHabilidadeInimigo(inimigo.Habilidades);//retorna a posicao da habilidade desativada (nunca retorn 0)
                    }
                }

                //Aplicar dano no inimigo
                if (danoInfligido > 0)
                {
                    inimigo.Life -= danoInfligido;
                    return 0;//significa que foi bem sucedido e que foi uma habilidade ou item causador de dano
                }
            }
            return -1;
        }

        public int DesativarHabilidadeInimigo(List<Habilidade> habilidadesInimigo)
        {
            Random randNum;
            int qtdHabilidades = habilidadesInimigo.Count;
            int PDesabilit = 0;

            //enquanto a posicao for  < 0 || e a posicao for >= qtdHabilidades;
            
            while (PDesabilit <= 0  || PDesabilit >= qtdHabilidades)
            {
                randNum = new Random();
                PDesabilit = randNum.Next(1, qtdHabilidades -1);
            }

            //Não inclui a habilidade basica (que esta na posicao 1)
            if (PDesabilit >= 1)
            {
                habilidadesInimigo[PDesabilit].Ativa = false;
                return PDesabilit;//retorna a posicao da habilidade do inimigo desativada
            }
            return -1;
        }

        public int calculoDano(Personagem inimigo, int dano) 
        {   
            //O dano é da habilidade ou do item
            int danoTotal = dano + this.Animo;
            int defesaInimigo = inimigo.Persistencia;
            int danoInfligido = 0;

            //O dano é maior que a defesa
            if (danoTotal >= defesaInimigo)
            {
                danoInfligido = danoTotal - defesaInimigo;
            }

            // A defesa é maior que o dano
            else
            {
                danoInfligido = defesaInimigo - danoTotal;
            }

            return danoInfligido;
        }

        public abstract bool StartHabilidade();
        
        public abstract bool UsarHabilidade(Habilidade habilidade);
        
    }
}
