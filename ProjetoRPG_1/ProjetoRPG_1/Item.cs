using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public abstract class Item
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NivelRequerido { get; set; }
        public int Dano { get; set; }
        public int BuffEnergia { get; set; }
        public int BuffLife { get; set; }
        public int BuffAnimo { get; set; }
        public int BuffPersistencia { get; set; }
        
    }
}
