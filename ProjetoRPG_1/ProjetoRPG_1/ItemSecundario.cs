using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class ItemSecundario : Item
    {
        public List<ItemPrimario> ItensPreRequesito { get; set; }
        public List<ItemPrimario> ListaAuxiliar { get; set; }
        public ItemSecundario()
        {

        }
        public bool vericarItemPreRequesito(List<ItemPrimario> listaItem)
        {
            foreach (var item in listaItem)
            {
                foreach(var item2 in ItensPreRequesito)
                {
                    if (item.Nome != item2.Nome)
                    {
                        foreach (var item3 in ListaAuxiliar)
                        {
                            listaItem.Add(item3);
                        }
                        //return false;
                    }
                    else
                    {
                        ListaAuxiliar.Add(item);
                        listaItem.Remove(item);
                    }
                }
            }
            return true;
        }
        public void addItem(string nome)
        {
            int qtd = 0;
            ItemPrimario[] i = new ItemPrimario[4];

            for(int j = 0; j < 4; j++) 
            {
                i[j] = new ItemPrimario();
            }

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
            //qtd = i.Length;
            for (int x = 0; x < qtd; x++)
            {
                this.ItensPreRequesito.Add(i[x]);
            }
        }
        public ItemSecundario(string Nome)
        {
            this.Nome = Nome;
            addItem(Nome);
        }
        
        override
        public string ToString()
        {
            return this.Nome;
        }

    }
}
