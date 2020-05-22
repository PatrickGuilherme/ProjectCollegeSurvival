using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoRPG
{
    public class Mapa
    {
        public GameObject[,] MapaJogo { get; set; }

        public GameObject[,] ConstruirMapa(GameObject[,] Map)
        {
            GameObject G = new GameObject { O = true };

            Map = new GameObject[9, 132]
            {{G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G},
             {G,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,G,G,G,null,null,G,null,null,G,G,null,null,null,null,null,null,null,G,G,G,G,G,G,null,null,null,null,null,null,null,null,null,G,G,G,G,G,G,null,G,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,null,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,null,G,null,null,null,G,G,G,G,null,G,null,G,null,null,null,G,G,G},
             {G,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,G,G,G,G,G,G,G,G,null,G,G,G,G,G,G,G,null,null,G,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,null,null,G,G,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,null,null,null,null,null,null,null,G,G,G},
             {G,G,G,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,G,null,null,null,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,null,null,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,G,G,G,null,G,G,G,null,null,null,null,G,G},
             {G,G,G,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,G,G,G,G,G,G,G,G,null,G,G,null,null,null,null,null,G,null,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,null,null,null,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,null,G,G,G,null,null,null,null,G,G},
             {G,G,G,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,null,null,null,G,null,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G},
             {G,G,G,G,G,null,null,G,G,G,G,G,G,null,null,null,null,null,null,null,null,G,G,G,G,null,G,G,G,G,G,G,G,G,null,G,G,null,null,null,null,null,null,null,null,null,null,G,G,null,null,G,G,null,null,null,G,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,G,G,G,G,null,null,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G},
             {G,G,G,G,G,null,null,G,G,G,G,G,G,null,G,null,G,null,null,null,null,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,null,G,G,G,G,G,G,G,G,G,G,null,null,null,null,null,null,null,G,G,G,G,G,null,null,null,null,null,null,null,null,null,null,G,G,G,G,G,G,null,G,G,G,G,G,G,G,G,null,null,null,G,null,G,null,null,G,G,G,G,G,G,G,null,null,G,G,G,G,G,G,G,null,null,null,null,null,null,null,null,null,G,G,G,null,G,null,G,null,null,null,null,null,G},
             {G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G,G}};

            LoadingDeslocamentosMapa(Map);
            LoadingEnemiesMapa(Map);
            LoadingItensMapa(Map);
            return Map;
        }

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
            GameObject D5 = new GameObject() { Deslocamento = new int[3] { 4, 62, 6} };
            Map[4, 46] = D5;
            GameObject D6 = new GameObject() { Deslocamento = new int[3] { 2, 69, 6} };
            Map[2, 49] = D6;
            GameObject D7 = new GameObject() { Deslocamento = new int[3] { 7, 69, 6 } };
            Map[6, 49] = D7;
            GameObject D8 = new GameObject() { Deslocamento = new int[3] { 4, 45, 4} };
            Map[4, 61] = D8;
            GameObject D9 = new GameObject() { Deslocamento = new int[3] { 2, 50, 5} };
            Map[2, 70] = D9;
            GameObject D10 = new GameObject() { Deslocamento = new int[3] { 6, 50, 5} };
            Map[7, 70] = D10;
            GameObject D11 = new GameObject() { Deslocamento = new int[3] { 2, 77, 7} };
            Map[7, 61] = D11;
            GameObject D12 = new GameObject() { Deslocamento = new int[3] { 7, 62, 6} };
            Map[1, 77] = D12;
            GameObject D13 = new GameObject() { Deslocamento = new int[3] { 2, 94, 8} };
            Map[7, 77] = D13;
            GameObject D14 = new GameObject() { Deslocamento = new int[3] { 6, 77, 7} };
            Map[1, 94] = D14;
            GameObject D15 = new GameObject() { Deslocamento = new int[3] { 2, 113, 10} };
            Map[7, 90] = D15;
            GameObject D16 = new GameObject() { Deslocamento = new int[3] { 5, 115, 10} };
            Map[4, 97] = D16;
            GameObject D17 = new GameObject() { Deslocamento = new int[3] { 6, 90, 8} };
            Map[1, 113] = D17;
            GameObject D18 = new GameObject() { Deslocamento = new int[3] { 7, 129, 11} };
            Map[2, 109] = D18;
            GameObject D19 = new GameObject() { Deslocamento = new int[3] { 4, 98, 9} };
            Map[5, 116] = D19;
            GameObject D20 = new GameObject() { Deslocamento = new int[3] { 6, 15, 2} };
            Map[1, 124] = D20;
            GameObject D21 = new GameObject() { Deslocamento = new int[3] { 2, 110, 10} };
            Map[7, 130] = D21;

            return Map;
        }

        private GameObject[,] LoadingEnemiesMapa(GameObject[,] Map)
        {
            var random = new Random();
            int posicaoY, posicaoX;
            for (int i = 0; i < 12; i++)
            {
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(107, 131);
                    if (Map[posicaoY, posicaoX] == null) break;
                }
                GameObject GridMonstro = new GameObject();
                Gasefic GridGasefic = new Gasefic
                {
                    Animo = 15,
                    ConhecimentoDrop = 5,
                    Life = 400,
                    Energia = 150,
                    Persistencia = 10
                };
                GridGasefic.Habilidades = new List<Habilidade>();
                GridGasefic.StartHabilidade();
                GridMonstro.M = GridGasefic;
                Map[posicaoY, posicaoX] = GridMonstro;
            } //Gasefic
            for (int i = 0; i < 14; i++)
            {
                GameObject GridMonstro = new GameObject();
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(83, 107);
                    if (Map[posicaoY, posicaoX] == null) break;
                }
                Mintost GridMintost = new Mintost
                {
                    Animo = 25,
                    ConhecimentoDrop = 8,
                    Life = 450,
                    Energia = 200,
                    Persistencia = 25
                };
                GridMintost.Habilidades = new List<Habilidade>();
                //GridMintost.StartHabilidade();
                GridMonstro.M = GridMintost;
                Map[posicaoY, posicaoX] = GridMonstro;
            } //Mintost
            for (int i = 0; i < 10; i++)
            {
                GameObject GridMonstro = new GameObject();
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(59, 83);
                    if (Map[posicaoY, posicaoX] == null) break;
                }
                Minlapa GridMinlapa = new Minlapa
                {
                    Animo = 35,
                    ConhecimentoDrop = 35,
                    Life = 500,
                    Energia = 250,
                    Persistencia = 20
                };
                GridMinlapa.Habilidades = new List<Habilidade>();
                //GridMinlapa.StartHabilidade();
                GridMonstro.M = GridMinlapa;
                Map[posicaoY, posicaoX] = GridMonstro;
            } //Minlapa
            for (int i = 0; i < 4; i++)
            {
                GameObject GridMonstro = new GameObject();
                while (true)
                {
                    posicaoY = random.Next(9);
                    posicaoX = random.Next(35, 59);
                    if (Map[posicaoY, posicaoX] == null) break;
                }
                Aculo GridAculo = new Aculo
                {
                    Animo = 40,
                    ConhecimentoDrop = 171,
                    Life = 550,
                    Energia = 300,
                    Persistencia = 25
                };
                GridAculo.Habilidades = new List<Habilidade>();
                //GridAculo.StartHabilidade();
                GridMonstro.M = GridAculo;
                Map[posicaoY, posicaoX] = GridMonstro;
            }  //Aculo


            return Map;
        }

        private GameObject[,] LoadingItensMapa(GameObject[,] Map) 
        {
            //ISSO AQUI � UM TESTE !!
            ItemPrimario item = new ItemPrimario();
            item.Nome = "TESTE";
            GameObject teste = new GameObject();
            teste.I = item;
            Map[3, 3] = teste;
            return Map;
        }
    }
}
