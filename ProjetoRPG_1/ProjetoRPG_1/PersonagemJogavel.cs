using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjetoRPG
{
    public abstract class PersonagemJogavel: Personagem
    {
        public int Conhecimento { get; set; }
        public int Nivel { get; set; }
        public List<Habilidade> habilidades { get; set; }
        public Inventario inventario { get; set; }
        public List<Equipamento> EquipamentosEquipados { get; }
        
        public bool EquiparEquipamento(Equipamento equipamento) {
            if (this.EquipamentosEquipados != null)
            {
                if (this.EquipamentosEquipados.Count < 3 && EquipamentosEquipados != null && equipamento.NivelRequerido >= this.Nivel)
                {
                    bool permisionInsert = true;

                    foreach (Equipamento equip in EquipamentosEquipados)
                    {
                        if (equip.Tipo == equipamento.Tipo)
                        {
                            permisionInsert = false;
                            break;
                        }
                    }

                    if (permisionInsert)
                    {
                        EquipamentosEquipados.Add(equipamento);
                        return true;
                    }
                }
            }
            return false;
        }
        public bool ColetarItem(Item item)
        {
            if(this.inventario != null)
            {
                int tamanhoInventario = 18; // 15 ITENS E 3 EQUIPAMENTOS EQUIPADOS QUE TEM QUE ESTA NO INVENTARIO
                if (this.inventario.Itens.Count < tamanhoInventario)
                {
                    this.inventario.Itens.Add(item);
                    return true;
                }
            }
            return false;
        }

        public bool PodeMover(GameObject[,] mapaJogo, double newPx, double newPy)
        {
            if (mapaJogo != null)
            {
                if(mapaJogo[(int)Math.Floor(newPy), (int)Math.Floor(newPx)] == null)
                {
                    Debug.WriteLine("{0}  {1}", newPx, newPy);
                    return true;
                }
            }
            return false;
        }

        public abstract void LevelUp();

        public void UsarItem(Item item, Personagem personagemInimigo)
        {
            if(this.inventario != null)
            {
                this.Animo += item.BuffAnimo;
                this.Energia += item.BuffEnergia;
                this.Life += item.BuffLife;
                this.Persistencia += item.BuffPersistencia;

                if (personagemInimigo != null)
                {
                    this.Atacar(personagemInimigo, item.Dano * -1);
                }
                this.DescartarItem(item);
            }
        }

        public bool DescartarItem(Item item)
        {
            if(this.inventario != null)
            {
                int index = this.inventario.Itens.IndexOf(item);
                if (index > -1)
                {
                    this.inventario.Itens.Remove(item);
                    return true;
                }
            }
            return false;
        }

        public  void DesequiparEquipamento(Equipamento equipamento)
        {
            if(this.EquipamentosEquipados != null)
            {
                this.EquipamentosEquipados.Remove(equipamento);
            }
        }
    }
}
