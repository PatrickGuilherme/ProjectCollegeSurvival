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
        public ItemSecundario()
        {

        }

        //*Função em construção
        public ItemSecundario(string Nome)
        {
            this.Nome = Nome;
            addItem(Nome);
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
        public void addItem(string nome)
        {
            //Instancia de variaveis
            int qtd = 0;
            ItemPrimario[] i = new ItemPrimario[4];
            for(int j = 0; j < 4; j++) 
            {
                i[j] = new ItemPrimario();
            }

            //Compara o item pelo nome para inserir seus pre requisitos
            if (nome.Equals("BLUE BULL"))
            {
                i[0].Nome = "Garrafa vazia";
                i[1].Nome = "Agua";
                i[2].Nome = "Substancia quimica";
                qtd = 3;
            }
            else if (nome.Equals("SUNBLEY"))
            {
                i[0].Nome = "Pao";
                i[1].Nome = "Pao";
                i[2].Nome = "Pombo";
                qtd = 3;
            }
            else if (nome.Equals("CAFÉ"))
            {
                i[0].Nome = "Agua";
                i[1].Nome = "Po";
                qtd = 2;
            }
            else if (nome.Equals("NOTAS DE AULA"))
            {
                i[0].Nome = "Papel";
                i[1].Nome = "Giz";
                qtd = 2;
            }
            else if (nome.Equals("CALCULADORA"))
            {
                i[0].Nome = "Mecanismo Eletrônico";
                i[1].Nome = "Substancia quimica";
                i[2].Nome = "Substancia quimica";
                i[3].Nome = "Substancia quimica";
                qtd = 4;
            }
            else if (nome.Equals("MINI SOL"))
            {
                i[0].Nome = "Vidraria";
                i[1].Nome = "Substancia quimica";
                i[2].Nome = "Substancia quimica";
                i[3].Nome = "Substancia quimica";
                qtd = 4;
            }
            
            //Adiciona os itens de pre-requisito
            for (int x = 0; x < qtd; x++)
            {
                this.ItensPreRequesito.Add(i[x]);
            }
        }
        
        override
        public string ToString()
        {
            return this.Nome;
        }

    }
}
