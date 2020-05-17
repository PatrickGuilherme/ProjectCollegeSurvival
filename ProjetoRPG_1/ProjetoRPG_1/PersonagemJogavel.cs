using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjetoRPG
{
    public abstract class PersonagemJogavel: Personagem
    {
        public double PosicaoX { get; set; }
        public double PosicaoY { get; set; }
        public int Conhecimento { get; set; }
        public int Nivel { get; set; }
        public Inventario inventario { get; set; }
        public List<Equipamento> EquipamentosEquipados { set; get; }
        
        public bool EquiparEquipamento(Equipamento equipamento) {
            if (this.EquipamentosEquipados != null)
            {
                if (this.EquipamentosEquipados.Count < 3 && EquipamentosEquipados != null && this.Nivel >= equipamento.NivelRequerido)
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
                        this.Persistencia += equipamento.BuffPersistencia;
                        this.Animo += equipamento.BuffAnimo;
                        this.Energia += equipamento.BuffEnergia;
                        this.Life += equipamento.BuffLife;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool DesequiparEquipamento(Equipamento equipamento)
        {
            if (this.EquipamentosEquipados != null)
            {
                this.Persistencia -= equipamento.BuffPersistencia;
                this.Animo -= equipamento.BuffAnimo;
                this.Energia -= equipamento.BuffEnergia;
                this.Life -= equipamento.BuffLife;
                this.EquipamentosEquipados.Remove(equipamento);
                return true;
            }
            return false;
        }

        public bool ColetarItem(Item item)
        {
            if (this.inventario != null)
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

        public bool UsarItem(Item item)
        {
            if(this.inventario != null)
            {
                this.Animo += item.BuffAnimo;
                this.Energia += item.BuffEnergia;
                this.Life += item.BuffLife;
                this.Persistencia += item.BuffPersistencia;
                this.DescartarItem(item);
                return true;
            }
            return false;
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

        public void DesativarEfeitoItem(Item item)
        {
            this.Animo -= item.BuffAnimo;
            this.Energia -= item.BuffEnergia;
            this.Life -= item.BuffLife;
            this.Persistencia -= item.BuffPersistencia;
        }

        public void DesativarEfeitoHabilidade(Habilidade habilidade)//quando terminar de usar a habilidade chame essa funcao
        {
            this.Animo -= habilidade.BuffAnimo;
            this.Life -= habilidade.BuffLife;
            this.Persistencia -= habilidade.BuffPersistencia;
            habilidade.Usada = false;
        }

        public bool PodeMover(GameObject[,] mapaJogo, double newPx, double newPy)
        {
            if (mapaJogo != null)
            {
                if (mapaJogo[(int)Math.Floor(newPy), (int)Math.Floor(newPx)] == null)
                {
                    Debug.WriteLine("{0}  {1}", newPx, newPy);
                    return true;
                }
            }
            return false;
        }

        public abstract void LevelUp();
    }
}
