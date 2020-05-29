using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProjetoRPG;
using Windows.UI.ViewManagement;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace ProjetoRPG_UWP {
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Page2 : Page {
        public Page2() {
            this.InitializeComponent();
            BtnWorker.Click += BtnWorker_Click;
            BtnCheater.Click += BtnCheater_Click;
            BtnExpert.Click += BtnExpert_Click;
        }
        private void BtnWorker_Click(object sender, RoutedEventArgs e) {
            ItemSecundario itsec = new ItemSecundario();
            itsec.BuffLife = 10;
            itsec.BuffAnimo = 10;
            itsec.Nome = "TESTE DE ITEM";
            itsec.Dano = 99;

            Worker player = new Worker {
                Nome = "João None",
                Descricao = "",
                Life = 300,
                Energia = 500,
                MenuCraft = new Craft(),
                MaxEnergia = 500,
                MaxLife = 300,
                Animo = 20,
                Nivel = 1,
                Conhecimento = 0,
                Persistencia = 15,
                PosicaoX = 19,
                PosicaoY = 2,
                inventario = new Inventario() {
                    Itens = new List<Item>()
                },
                Habilidades = new List<Habilidade>()
                };
            player.inventario.Itens.Add(itsec);

            Mapa Mapa = new Mapa();
            Mapa.MapaJogo = new GameObject[9, 132];
            Mapa.ConstruirMapa();
            var ListaParametros = new List<object>() {
                player,
                Mapa
            };
            player.StartHabilidade();
            this.Frame.Navigate(typeof(Movimento), ListaParametros);
        }
        private void BtnExpert_Click(object sender, RoutedEventArgs e) {
            Expert player = new Expert {
                Life = 400,
                Energia = 400,
                Animo = 15,
                MaxEnergia = 400,
                MaxLife = 400,
                MenuCraft = new Craft(),
                Persistencia = 20,
                PosicaoX = 19,
                PosicaoY = 2,
                Nivel = 1,
                Conhecimento = 0,
                inventario = new Inventario() {
                    Itens = new List<Item>()
                },
                Habilidades = new List<Habilidade>()
                };
            Mapa Mapa = new Mapa();
            Mapa.MapaJogo = new GameObject[9, 132];
            Mapa.ConstruirMapa();
            var ListaParametros = new List<object>() {
                    player,
                    Mapa
                };
            player.StartHabilidade();
            this.Frame.Navigate(typeof(Movimento), ListaParametros);
        }
        private void BtnCheater_Click(object sender, RoutedEventArgs e) {
            Cheater player = new Cheater {
                Life = 500,
                Energia = 300,
                MaxEnergia = 300,
                MenuCraft = new Craft(),
                MaxLife = 500,
                Animo = 17,
                Nivel = 1,
                Conhecimento = 0,
                PosicaoX = 19,
                PosicaoY = 2,
                Persistencia = 18,
                inventario = new Inventario() {
                    Itens = new List<Item>()
                },
                Habilidades = new List<Habilidade>()
            };
            Mapa Mapa = new Mapa();
            Mapa.MapaJogo = new GameObject[9, 132];
            Mapa.ConstruirMapa();
            var ListaParametros = new List<object>() {
                    player,
                    Mapa
                };
            player.StartHabilidade();
            this.Frame.Navigate(typeof(Movimento), ListaParametros);
        }
    }
}
