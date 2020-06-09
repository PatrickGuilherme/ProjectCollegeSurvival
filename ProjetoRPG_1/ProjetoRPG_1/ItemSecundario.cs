using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPG
{
    public class ItemSecundario : Item
    {
        public List<ItemPrimario> ItensPreRequesito { get; set; }
        public List<ItemPrimario> ListaAuxiliar { get; set; }
        
        /// <summary>
        /// Construtor de instância de item secundario 
        /// </summary>
        public ItemSecundario(int numItem)
        {
            switch (numItem)
            {
                case 1:
                    this.Nome = "Blue Bull";
                    this.Descricao = "O Blue Bull é um energético poderoso feito nas colinas azuis por um grupo de estudantes misteriosos, este artefato gera energia para seu usuário enfrentar batalhas contra os monstros do conhecimento, é um item consumível que aumenta durante incrivelmente poderoso.";
                    this.NivelRequerido = 2;
                    this.BuffEnergia = 10;
                    this.BuffAnimo = 0;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                    this.ListaAuxiliar = new List<ItemPrimario>();
                    this.ItensPreRequesito = new List<ItemPrimario>();
                    iniciarItemPreRequisito();
                break;
                case 2:
                    this.Nome = "Sunbley";
                    this.Descricao = "Sunbley é um poderoso sanduba criados por místicos estudantes graduados em engenharia, este item garante que o usuário sacie toda sua fome regenerando sua vida, a lendas que falam de está ser um item lendário temido por monstros do conhecimento.";
                    this.NivelRequerido = 2;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffLife = 10;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                    this.ListaAuxiliar = new List<ItemPrimario>();
                    this.ItensPreRequesito = new List<ItemPrimario>();
                    iniciarItemPreRequisito();
                break;
                case 3:
                    this.Nome = "Café";
                    this.Descricao = "O café é um item consumível de origem desconhecida, ele permite aumentar o animo e persistência do usuário em momentos de dificuldades, um item acessível a todas e com um grande efeito.";
                    this.NivelRequerido = 2;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 2;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 4;
                    this.Dano = 0;
                    this.ListaAuxiliar = new List<ItemPrimario>();
                    this.ItensPreRequesito = new List<ItemPrimario>();
                    iniciarItemPreRequisito();
                break;
                case 4:
                    this.Nome = "Notas de Aula";
                    this.Descricao = "As notas de aula é um papel místico vindo de cadernos dos maiores heróis do mundo, aqueles que concluíram a graduação e derrotaram o rei anáculo, este item permite ao usuário  incrementar todos os seus atributos.";
                    this.NivelRequerido = 3;
                    this.BuffEnergia = 1;
                    this.BuffAnimo = 1;
                    this.BuffLife = 1;
                    this.BuffPersistencia = 1;
                    this.Dano = 0;
                    this.ListaAuxiliar = new List<ItemPrimario>();
                    this.ItensPreRequesito = new List<ItemPrimario>();
                    iniciarItemPreRequisito();
                break;
                case 5:
                    this.Nome = "Calculadora";
                    this.Descricao = "A calculadora é uma das relíquias místicas utilizadas pelos grandes ancestrais na era ADI (antes da internet) item que devasta qualquer inimigo mas se usado em excesso causa vicio e dependência.";
                    this.NivelRequerido = 3;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 100;
                    this.ListaAuxiliar = new List<ItemPrimario>();
                    this.ItensPreRequesito = new List<ItemPrimario>();
                    iniciarItemPreRequisito();
                break;
                case 6:
                    this.Nome = "Mini Sol";
                    this.Descricao = "Em meio a experimentos quimicos e estudos para derrotar o monstro do conhecimento ATOM o Mini Sol foi a arma decisiva para os ancestraris da era ADI (antes da internet) derrotaram seus inimigos, uma arma potente de poder destrutivo imensuravel.";
                    this.NivelRequerido = 3;
                    this.BuffLife = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 300;
                    this.ListaAuxiliar = new List<ItemPrimario>();
                    this.ItensPreRequesito = new List<ItemPrimario>();
                    iniciarItemPreRequisito();
                break;
                case 7:
                    this.Nome = "Laser";
                    this.Descricao = "Dispositivo encontrado após derrotar o magnifico inimigo T.O.E.S.T, sendo usado para causar dano em inimigos.";
                    this.NivelRequerido = 3;
                    this.BuffLife = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 25;
                    //this.ListaAuxiliar = new List<ItemPrimario>();
                    //this.ItensPreRequesito = new List<ItemPrimario>();
                    //iniciarItemPreRequisito();
                    break;
            }
        }

        /// <summary>
        /// Metodo para verificar se uma lista de itens do jogador forma um item secundario
        /// </summary>
        public bool vericarItemPreRequesito(List<ItemPrimario> listaItem)
        {
            //Navega pelos itens de pre requisitos para o craft
            foreach (var item in ItensPreRequesito)
            {
                //Verifica se ele tem não tem o item
                if (!ContemItem(listaItem, item))
                {
                    //Devolve os itens vindos craft
                    foreach (var item2 in ListaAuxiliar)
                    {
                        listaItem.Add(item2);
                    }
                    return false;
                }
                //Se ele tem o item vem pra ca
                else
                {
                    ListaAuxiliar.Add(item);
                    listaItem.Remove(item);
                }
            }
            return true;
        }

        /// <summary>
        /// Metodo que verifica se o usuario possui um item de craft
        /// </summary>
        private bool ContemItem(List<ItemPrimario> listaItem, Item item) 
        {
            foreach(var i in listaItem)
            {
                if (i.Nome == item.Nome) return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo para inserir os itens primarios necessarios para realizar o craft do item secundario selecionado
        /// </summary>
        private void iniciarItemPreRequisito()
        {
            string nome = this.Nome;

            //Instancia de variaveis
            int qtd = 0;
            ItemPrimario[] itemPreReq = new ItemPrimario[4];

            //Compara o itemSecundario pelo nome para inserir seus pré-requisitos
            switch (nome)
            {
                case "Blue Bull":
                    itemPreReq[0] = new ItemPrimario(1);
                    itemPreReq[1] = new ItemPrimario(2);
                    itemPreReq[2] = new ItemPrimario(3);
                    qtd = 3;
                break;
                case "Sunbley":
                    itemPreReq[0] = new ItemPrimario(4);
                    itemPreReq[1] = new ItemPrimario(4);
                    itemPreReq[2] = new ItemPrimario(5);
                    qtd = 3;
                break;
                case "Café":
                    itemPreReq[0] = new ItemPrimario(2);
                    itemPreReq[1] = new ItemPrimario(6);
                    qtd = 2;
                break;
                case "Notas de Aula":
                    itemPreReq[0] = new ItemPrimario(7);
                    itemPreReq[1] = new ItemPrimario(8);
                    qtd = 2;
                break;
                case "Calculadora":
                    itemPreReq[0] = new ItemPrimario(9);
                    itemPreReq[1] = new ItemPrimario(3);
                    itemPreReq[2] = new ItemPrimario(3);
                    itemPreReq[3] = new ItemPrimario(3);
                    qtd = 4;
                break;
                case "Mini Sol":
                    itemPreReq[0] = new ItemPrimario(10);
                    itemPreReq[1] = new ItemPrimario(3);
                    itemPreReq[2] = new ItemPrimario(3);
                    itemPreReq[3] = new ItemPrimario(3);
                    qtd = 4;
                break;
            }
            
            //Adiciona os itens de pre-requisito
            for (int i = 0; i < qtd; i++)
            {
                this.ItensPreRequesito.Add(itemPreReq[i]);
            }
        }
        
        override
        public string ToString()
        {
            return this.Nome;
        }

    }
}
