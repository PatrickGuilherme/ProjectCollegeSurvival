using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class ItemPrimario: Item
    {
        public ItemPrimario()
        {
            //Esta função foi deixada apenas para teste
        }
        public ItemPrimario(int numItem)
        {

            switch (numItem)
            {
                case 1:
                    this.Nome = "Garrafa Vazia";
                    this.Descricao = "Garrafa vazia é um item que o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 2:
                    this.Nome = "Água";
                    this.Descricao = "Água é um item encontrado perto de bebedouros, a substância pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 3:
                    this.Nome = "Substância Química";
                    this.Descricao = "Substância Química é um item encontrado perto de laboratórios, a substância pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 4:
                    this.Nome = "Pão";
                    this.Descricao = "Pão é um item que pode ser encontrado perto da cantina, o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 5:
                    this.Nome = "Pombo";
                    this.Descricao = "Pombo é um item encontrado em locais abertos ou fechados, o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffLife = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 6:
                    this.Nome = "Pó";
                    this.Descricao = "Pó é um item encontrado em locais fechados a muito tempo, o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffLife = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 7:
                    this.Nome = "Papel";
                    this.Descricao = "Papel é um item encontrado em salas de aula, o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffLife = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 8:
                    this.Nome = "Giz";
                    this.Descricao = "Giz é um item encontrado em salas de aula, o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffLife = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 9:
                    this.Nome = "Mecanismo Eletrônico";
                    this.Descricao = "Mecanismo Eletrônico é um item encontrado em salas de robotica, o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffLife = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
                case 10:
                    this.Nome = "Vidraria";
                    this.Descricao = "Vidraria é um item encontrado em salas de química, o material pode ser utilizado para fabricar outros itens.";
                    this.NivelRequerido = 0;
                    this.BuffLife = 0;
                    this.BuffEnergia = 0;
                    this.BuffAnimo = 0;
                    this.BuffPersistencia = 0;
                    this.Dano = 0;
                break;
            }
        }
    }
}
