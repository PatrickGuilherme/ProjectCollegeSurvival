using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Inventario
    {
        public List<Item> Itens{ get; set; }

        //checar se o item existe no inventario
        public bool HasItem(Item item) => Itens.Equals(item) ? true : false;

        //separando os tipos de itens
        public List<ItemPrimario> GetItemPrimarios()
        {
            List<ItemPrimario> itensPrimarios = new List<ItemPrimario>();
            foreach(Item item in Itens){
                if (item is ItemPrimario) itensPrimarios.Add((ItemPrimario)item);
            }
            return itensPrimarios;
        }

        public List<ItemSecundario> GetItemSecundarios()
        {
            List<ItemSecundario> ItensSecundarios = new List<ItemSecundario>();
            foreach (Item item in Itens)
            {
                if (item is ItemSecundario) ItensSecundarios.Add((ItemSecundario)item);
            }
            return ItensSecundarios;
        }

        public List<Equipamento> GetEquipamentos()
        {
            List<Equipamento> Equipamentos = new List<Equipamento>();
            foreach (Item item in Itens)
            {
                if (item is Equipamento) Equipamentos.Add((Equipamento)item);
            }
            return Equipamentos;
        }
    }
}
