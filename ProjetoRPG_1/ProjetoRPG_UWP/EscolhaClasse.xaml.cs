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


namespace ProjetoRPG_UWP {
    
    public sealed partial class Page2 : Page {

        /// <summary>
        /// Metodo de construtor
        /// </summary>
        public Page2() {
            this.InitializeComponent();
            BtnWorker.Click += BtnWorker_Click;
            BtnCheater.Click += BtnCheater_Click;
            BtnExpert.Click += BtnExpert_Click;
        }

        /// <summary>
        /// Metodo de de criar worker
        /// </summary>
        private void BtnWorker_Click(object sender, RoutedEventArgs e) {
            Worker player = new Worker();
            Mapa Mapa = new Mapa();
            Mapa.MapaJogo = new GameObject[9, 132];
            Mapa.ConstruirMapa();
            var ListaParametros = new List<object>() {
                player,
                Mapa
            };
            //player.StartHabilidade();
            
            this.Frame.Navigate(typeof(Movimento), ListaParametros);
        }


        /// <summary>
        /// Metodo de criar expert
        /// </summary>
        private void BtnExpert_Click(object sender, RoutedEventArgs e) {
            Expert player = new Expert();
            Mapa Mapa = new Mapa();
            Mapa.MapaJogo = new GameObject[9, 132];
            Mapa.ConstruirMapa();
            var ListaParametros = new List<object>() {
                    player,
                    Mapa
                };
           // player.StartHabilidade();
            this.Frame.Navigate(typeof(Movimento), ListaParametros);
        }

        /// <summary>
        /// Metodo de criar cheater
        /// </summary>
        private void BtnCheater_Click(object sender, RoutedEventArgs e) {
            Cheater player = new Cheater();
            Mapa Mapa = new Mapa();
            Mapa.MapaJogo = new GameObject[9, 132];
            Mapa.ConstruirMapa();
            var ListaParametros = new List<object>() {
                    player,
                    Mapa
                };
            //player.StartHabilidade();
            this.Frame.Navigate(typeof(Movimento), ListaParametros);
        }
    }
}
