using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoRPG
{
    public class Craft
    {
        public List<ItemSecundario> ItensCraftados { get; set; }

        public Craft()
        {
            this.ItensCraftados = new List<ItemSecundario>();
        }

        /// <summary>
        /// Metodo para gerar itens por combinações
        /// </summary>
        public bool Craftar(Inventario inventario, ItemSecundario itemSecundario)
        {

            List<ItemPrimario> itens = inventario.GetItemPrimarios();

            if (itemSecundario.vericarItemPreRequesito(itens))
            {
                foreach (ItemPrimario item in itemSecundario.ItensPreRequesito)
                { //remoção dos itens primarios utilizados
                    RemoverItem(inventario, item);
                }
                inventario.Itens.Add((Item)itemSecundario); // adicão do item secundario produzido
                return true;
            }
            else
            {
                return false;
            }
        }

        private void RemoverItem(Inventario inventario, ItemPrimario item) 
        {
            int cont = 0;
            foreach(var i in inventario.Itens.ToList()) 
            {
                if (i.Nome == item.Nome) inventario.Itens.RemoveAt(cont);
                cont++;
            }
        }
    }
}
