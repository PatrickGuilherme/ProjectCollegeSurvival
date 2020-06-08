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
        private void ImgMonstroCombate(Monstro monstroVencedor)
        {
            string diretorioMonstro;

            //Definir a imagem do mosntro
            if (monstroVencedor.GetType() == typeof(Aculo))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstroVencedor.GetType() == typeof(Anaculo))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstroVencedor.GetType() == typeof(Atom))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstroVencedor.GetType() == typeof(Gasefic))
            {
                diretorioMonstro = "gasefic.png";
            }
            else if (monstroVencedor.GetType() == typeof(Lapain))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstroVencedor.GetType() == typeof(Minlapa))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstroVencedor.GetType() == typeof(Mintost))
            {
                diretorioMonstro = "Aculo.png";
            }
            else //Toest
            {
                diretorioMonstro = "Aculo.png";
            }
            ImgMonstro.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioMonstro));
        }
    }
}
