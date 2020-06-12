using ProjetoRPG;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Pagina de game over do jogo
    /// </summary>
    public sealed partial class GameOver : Page
    {
        public GameOver()
        {
            this.InitializeComponent();
            ReiniciarJogo.Click += ReiniciarJogo_Click;
        }

        private void ReiniciarJogo_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage), null);
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var monstroVencedor = e.Parameter as Monstro;
            if(monstroVencedor != null)
            {
                ImgMonstroCombate(monstroVencedor);
            }
        }

        /// <summary>
        /// Define a imagem do monstro na tela de combate
        /// </summary>
        private void ImgMonstroCombate(Monstro monstro)
        {
            string diretorioMonstro;

            //Definir a imagem do mosntro
            if (monstro.GetType() == typeof(Aculo))
            {
                diretorioMonstro = "monstros/aculo.png";
            }
            else if (monstro.GetType() == typeof(Anaculo))
            {
                diretorioMonstro = "monstros/anaculo.png";
            }
            else if (monstro.GetType() == typeof(Atom))
            {
                diretorioMonstro = "monstros/atom.png";
            }
            else if (monstro.GetType() == typeof(Gasefic))
            {
                diretorioMonstro = "monstros/gasefic.png";
            }
            else if (monstro.GetType() == typeof(Lapain))
            {
                diretorioMonstro = "monstros/lapain.png";
            }
            else if (monstro.GetType() == typeof(Minlapa))
            {
                diretorioMonstro = "monstros/minlapa.png";
            }
            else if (monstro.GetType() == typeof(Mintost))
            {
                diretorioMonstro = "monstros/mintost.png";
            }
            else //Toest
            {
                diretorioMonstro = "monstros/toest.png";
            }
            ImgMonstro.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioMonstro));
        }
    }
}
