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
        public Craft MenuCraft { set; get; }
        /// <summary>
        /// Lista de equipamentos que estão em uso pelo personagem.
        /// </summary>
        public List<Equipamento> EquipamentosEquipados { set; get; }
        
        /// <summary>
        /// Metodo para associar a um personagem jogavel a seus equipamento.
        /// </summary>
        public bool EquiparEquipamento(Equipamento equipamento) {
            
            //Verifique se o List esta instânciado
            if (this.EquipamentosEquipados != null)
            {
                //Verifica se o jogador possui nivel necessário para equipar e se á espaço na lista de equipamento equipados 
                if (this.EquipamentosEquipados.Count < 3 && this.Nivel >= equipamento.NivelRequerido)
                {
                    //Verifica se o tipo equipamento passado esta disponivel para ser equipado  
                    bool permisionInsert = true;
                    foreach (Equipamento equip in EquipamentosEquipados)
                    {
                        if (equip.Tipo == equipamento.Tipo)
                        {
                            permisionInsert = false;
                            break;
                        }
                    }

                    //Implementar os buffs do equipamento no personagem;
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

        /// <summary>
        /// Metodo para desasociar um personagem jogavel ao equipamento retirando os buffes do equipamento.
        /// </summary>
        public bool DesequiparEquipamento(Equipamento equipamento)
        {
            //Verifique se o List esta instânciado
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

        /// <summary>
        /// Metodo para atribuir um item ao inventario do personagem jogavel.
        /// </summary>
        public bool ColetarItem(Item item)
        {
            if (this.inventario != null)
            {
                //Inserir item no inventario (Tamanho maximo: 18)                
                int tamanhoInventario = 18; // 15 ITENS E 3 EQUIPAMENTOS EQUIPADOS QUE TEM QUE ESTA NO INVENTARIO
                if (this.inventario.Itens.Count < tamanhoInventario)
                {
                    this.inventario.Itens.Add(item);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Metodo para usar um item
        /// </summary>
        public bool UsarItem(Item item)
        {
            //Atribui os buffes no personagem
            if(this.inventario != null)
            {
                this.Animo += item.BuffAnimo;
                this.Energia += item.BuffEnergia;
                this.Life += item.BuffLife;
                if (this.MaxLife < this.Life) this.Life = this.MaxLife;
                this.Persistencia += item.BuffPersistencia;
                this.DescartarItem(item);
                return true;
            }
            return false;
        }
   
        /// <summary>
        /// Metodo para descartar item do jogador
        /// </summary>
        public bool DescartarItem(Item item)
        {
            if(this.inventario != null)
            {
                //Procurar se o item no inventario existe para este ser removido
                int index = this.inventario.Itens.IndexOf(item);
                if (index > -1)
                {
                    this.inventario.Itens.Remove(item);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verique se o personagem pode mover em uma determinada posição da matriz
        /// </summary>
        public bool PodeMover(GameObject[,] mapaJogo, double newPx, double newPy)
        {
            if (mapaJogo != null)
            {
                if (mapaJogo[(int)Math.Floor(newPy), (int)Math.Floor(newPx)] == null)
                {
                    return true;
                }
            }
            return false;
        }

        public abstract void LevelUp();
    }
}
