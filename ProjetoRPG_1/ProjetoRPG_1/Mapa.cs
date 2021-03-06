using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Mapa
    {
        public GameObject[,] MapaJogo { get; set; }

        /// <summary>
        /// Metodo de constru��o do mapa
        /// </summary>
        public void ConstruirMapa()
        {
            //Inicializar o mapa
            GameObject G = new GameObject { Ocupado = true };
            GameObject[,] Map;

            Map = new GameObject[9, 132]
            {{G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G},
             {G,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,G,G,G,null,null,G,G,null,G,G,null,null,null,null,null,null,null,G,G,G,G,G,G,null,null,null,null,null,null,null,null,null,G,G,G,G,G,G,null,G,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,null,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,null,G,G,null,null,G,G,G,G,null,G,null,G,null,null,null,G,G,G},
             {G,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,G,G,G,null,null,G,G,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,G,null,G,G,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,null,null,null,null,null,null,null,G,G,G},
             {G,G,G,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,G,null,null,null,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,G,null,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,G,G,G,null,G,G,G,null,null,null,null,G,G},
             {G,G,G,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,G,G,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,null,null,null,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,G,G,G,G,G,null,G,G,G,null,null,null,null,G,G},
             {G,G,G,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,G,G,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G},
             {G,G,G,G,G,null,null,G,G,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,G,null,null,null,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G},
             {G,G,G,G,G,null,null,G,G,G,G,G,G,null,G,null,G,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,null,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,G,G,null,G,G,G,G,G,G,G,G,null,null,null,G,null,G,null,null,G,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,null,null,G,G,G,null,G,null,G,null,null,null,null,null,G},
             {G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G}};


            //Loading de elementos
            LoadingDeslocamentosMapa(Map);
            LoadingEnemiesMapa(Map);
            LoadingItensMapa(Map);
            this.MapaJogo = Map;
        }

        /// <summary>
        ///  Metodo de defini��o dos pontos de mudan�a do mapa
        /// </summary>
        private GameObject[,] LoadingDeslocamentosMapa(GameObject[,] Map)
        {
            GameObject D0 = new GameObject() { Deslocamento = new int[3] { 2, 19, 2 } };
            Map[7, 6] = D0;
            GameObject D1 = new GameObject() { Deslocamento = new int[3] { 6, 6, 1 } };
            Map[2, 20] = D1;
            GameObject D2 = new GameObject() { Deslocamento = new int[3] { 2, 124, 11 } };
            Map[7, 15] = D2;
            GameObject D3 = new GameObject() { Deslocamento = new int[3] { 6, 38, 4 } };
            Map[1, 26] = D3;
            GameObject D4 = new GameObject() { Deslocamento = new int[3] { 1, 27, 3 } };
            Map[7, 38] = D4;
            GameObject D5 = new GameObject() { Deslocamento = new int[3] { 4, 62, 6 } };
            Map[4, 46] = D5;
            GameObject D6 = new GameObject() { Deslocamento = new int[3] { 2, 69, 6 } };
            Map[2, 49] = D6;
            GameObject D7 = new GameObject() { Deslocamento = new int[3] { 7, 69, 6 } };
            Map[6, 49] = D7;
            GameObject D8 = new GameObject() { Deslocamento = new int[3] { 4, 45, 4 } };
            Map[4, 61] = D8;
            GameObject D9 = new GameObject() { Deslocamento = new int[3] { 2, 50, 5 } };
            Map[2, 70] = D9;
            GameObject D10 = new GameObject() { Deslocamento = new int[3] { 6, 50, 5 } };
            Map[7, 70] = D10;
            GameObject D11 = new GameObject() { Deslocamento = new int[3] { 2, 77, 7 } };
            Map[7, 61] = D11;
            GameObject D12 = new GameObject() { Deslocamento = new int[3] { 7, 62, 6 } };
            Map[1, 77] = D12;
            GameObject D13 = new GameObject() { Deslocamento = new int[3] { 2, 94, 8 } };
            Map[7, 77] = D13;
            GameObject D14 = new GameObject() { Deslocamento = new int[3] { 6, 77, 7 } };
            Map[1, 94] = D14;
            GameObject D15 = new GameObject() { Deslocamento = new int[3] { 2, 113, 10 } };
            Map[7, 90] = D15;
            GameObject D16 = new GameObject() { Deslocamento = new int[3] { 5, 115, 10 } };
            Map[4, 97] = D16;
            GameObject D17 = new GameObject() { Deslocamento = new int[3] { 6, 90, 8 } };
            Map[1, 113] = D17;
            GameObject D18 = new GameObject() { Deslocamento = new int[3] { 7, 129, 11 } };
            Map[2, 109] = D18;
            GameObject D19 = new GameObject() { Deslocamento = new int[3] { 4, 98, 9 } };
            Map[5, 116] = D19;
            GameObject D20 = new GameObject() { Deslocamento = new int[3] { 6, 15, 2 } };
            Map[1, 124] = D20;
            GameObject D21 = new GameObject() { Deslocamento = new int[3] { 2, 110, 10 } };
            Map[7, 130] = D21;

            return Map;
        }

        /// <summary>
        /// Metodo para inserir aleatoriamento os inimigos no mapa
        /// </summary>
        private GameObject[,] LoadingEnemiesMapa(GameObject[,] Map)
        {
            var random = new Random();
            int posicaoY, posicaoX;

            //Gera 12 inimigos no mapa (Gasefic)
            for (int i = 0; i < 12; i++)
            {
                //Procura uma posi��o aleatoria em que a posi��o seja nula
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(107, 131);
                    if (Map[posicaoY, posicaoX] == null) break;
                }

                //Inst�ncia o monstro
                GameObject GridMonstro = new GameObject();
                Gasefic GridGasefic = new Gasefic();
                GridGasefic.Habilidades = new List<Habilidade>();
                GridGasefic.StartHabilidade();
                GridMonstro.Monstro = GridGasefic;
                Map[posicaoY, posicaoX] = GridMonstro;
            }

            //Gera 14 inimigos no mapa (min tosta)
            for (int i = 0; i < 14; i++)
            {
                //Procura uma posi��o aleatoria em que a posi��o seja nula
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(75, 95);
                    if (Map[posicaoY, posicaoX] == null) break;
                }

                //Inst�ncia o monstro
                GameObject GridMonstro = new GameObject();
                Mintost GridMintost = new Mintost();
                GridMintost.Habilidades = new List<Habilidade>();
                GridMintost.StartHabilidade();
                GridMonstro.Monstro = GridMintost;
                Map[posicaoY, posicaoX] = GridMonstro;
            }

            //Gera 10 inimigos no mapa (Minlapa)
            for (int i = 0; i < 10; i++)
            {
                //Procura uma posi��o aleatoria em que a posi��o seja nula
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(36, 71);
                    if (Map[posicaoY, posicaoX] == null) break;
                }

                //Inst�ncia o monstro
                GameObject GridMonstro = new GameObject();
                Minlapa GridMinlapa = new Minlapa();
                GridMinlapa.Habilidades = new List<Habilidade>();
                GridMinlapa.StartHabilidade(); //Ativar quando a classe minlapa estiver pronta
                GridMonstro.Monstro = GridMinlapa;
                Map[posicaoY, posicaoX] = GridMonstro;
            }

            //Gera 4 inimigos no mapa (Aculo)
            for (int i = 0; i < 4; i++)
            {
                //Procura uma posi��o aleatoria em que a posi��o seja nula
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(0, 22);
                    if (Map[posicaoY, posicaoX] == null) break;
                }

                //Inst�ncia o monstro
                GameObject GridMonstro = new GameObject();
                Aculo GridAculo = new Aculo();
                GridAculo.Habilidades = new List<Habilidade>();
                GridAculo.StartHabilidade();
                GridMonstro.Monstro = GridAculo;
                Map[posicaoY, posicaoX] = GridMonstro;
            }

            GameObject GridBossLapain = new GameObject();
            GameObject GridBossToest = new GameObject();
            GameObject GridBossAnaculo = new GameObject();
            GameObject GridBossAtom = new GameObject();

            GridBossAnaculo.Monstro = new Anaculo();
            GridBossAtom.Monstro = new Atom();
            GridBossLapain.Monstro = new Lapain();
            GridBossToest.Monstro = new Toest();

            Map[4, 102] = GridBossAtom;
            Map[2, 77] = GridBossToest;
            Map[3, 29] = GridBossLapain;
            Map[4, 5] = GridBossAnaculo;

            return Map;
        }

        /// <summary>
        /// Metodo para inserir os itens no mapa (Em desenvolvimento)
        /// </summary>
        private GameObject[,] LoadingItensMapa(GameObject[,] Map)
        {
            Equipamento equipamento = new Equipamento();
            equipamento.adcionarEquipamento();
            GameObject GOequip;

            //equipamentos nivel 1

            GameObject GOequip1 = new GameObject();
            GOequip1.Item = equipamento.eq[0]; //agenda
            Map[7, 122] = GOequip1;

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[5]; //lapis
            Map[6, 122] = GOequip;

            //equipamentos nivel 2

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[1]; //caderno 1M
            Map[3, 106] = GOequip;

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[8]; //Borracha branca
            Map[4, 106] = GOequip;

            //equipamentos nivel 3

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[6]; //L�pis mec�nico
            Map[1, 85] = GOequip;

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[9]; //borracha azul
            Map[5, 79] = GOequip;

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[2]; //Caderno 10M
            Map[2, 91] = GOequip;

            //equipamentos nivel 4

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[3]; //ENCICLOPEDIA
            Map[3, 55] = GOequip;

            //equipamentos nivel 5

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[7]; //Caneta
            Map[3, 33] = GOequip;

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[4]; //Notebook
            Map[7, 20] = GOequip;

            GOequip = new GameObject();
            GOequip.Item = equipamento.eq[10]; //Borracha duas cores
            Map[5, 3] = GOequip;


            return Map;
        }
    }
}