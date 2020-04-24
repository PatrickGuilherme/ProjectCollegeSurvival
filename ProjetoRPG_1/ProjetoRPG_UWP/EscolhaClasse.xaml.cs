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

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Page2 : Page
    {
        public Page2()
        {
            this.InitializeComponent();
            BtnWorker.Click += BtnWorker_Click;
            BtnCheater.Click += BtnCheater_Click;
            BtnExpert.Click += BtnExpert_Click;
        }
        private void BtnWorker_Click(object sender, RoutedEventArgs e)
        {
            Worker player = new Worker();
            player.Life = 300;
            player.Energia = 500;
            player.Animo = 20;
            player.Persistencia = 15;
            this.Frame.Navigate(typeof(Movimento), player);
        }
        private void BtnExpert_Click(object sender, RoutedEventArgs e)
        {
            Expert player = new Expert();
            player.Life = 400;
            player.Energia = 400;
            player.Animo = 15;
            player.Persistencia = 20;
            this.Frame.Navigate(typeof(Movimento), player);
        }
        private void BtnCheater_Click(object sender, RoutedEventArgs e)
        {
            Cheater player = new Cheater();
            player.Life = 500;
            player.Energia = 300;
            player.Animo = 17;
            player.Persistencia = 18;
            this.Frame.Navigate(typeof(Movimento), player);
        }
    }
}
