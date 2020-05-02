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
            Worker player = new Worker
            {
                Life = 300,
                Energia = 500,
                Animo = 20,
                Persistencia = 15
            };
            this.Frame.Navigate(typeof(Movimento), player);
        }
        private void BtnExpert_Click(object sender, RoutedEventArgs e)
        {
            Expert player = new Expert
            {
                Life = 400,
                Energia = 400,
                Animo = 15,
                Persistencia = 20
            };
            this.Frame.Navigate(typeof(Movimento), player);
        }
        private void BtnCheater_Click(object sender, RoutedEventArgs e)
        {
            Cheater player = new Cheater
            {
                Life = 500,
                Energia = 300,
                Animo = 17,
                Persistencia = 18
            };
            this.Frame.Navigate(typeof(Movimento), player);
        }
    }
}
