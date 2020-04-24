using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public interface ICraft
    {

        //public List<ItemSecundario> ItensCraftados { get; set; }

        //public bool Craftar(Inventario inventario, ItemSecundario itemSecundario)
        //{
        //    List<ItemPrimario> itens = inventario.GetItemPrimarios();

        //    if (itemSecundario.vericarItemPreRequesito(itens))
        //    { 
        //        foreach (ItemPrimario item in itemSecundario.ItensPreRequesito)
        //        { //remoção dos itens primarios utilizados
        //            inventario.Itens.Remove(item);
        //        }
        //        inventario.Itens.Add((Item)itemSecundario); // adicão do item secundario produzido
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //        //num funcionou
        //    }
        //}
    }
}
