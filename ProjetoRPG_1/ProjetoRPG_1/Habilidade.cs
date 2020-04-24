using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Habilidade
    {
        public string Nome { get; set; }
        public String Descricao { get; set; }
        public int NivelRequerido { get; set; }
        public int GastoEnergia { get; set; }
        public int Dano { get; set; }
        public int BuffLife { get; set; }
        public int BuffAnimo { get; set; }
        public int BuffPersistencia { get; set; }
        public bool Usada { get; set; }
        public bool Ativa { get; set; }

        public static implicit operator List<object>(Habilidade v)
        {
            throw new NotImplementedException();
        }
    }
}
