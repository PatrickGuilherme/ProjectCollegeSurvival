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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Vitoria : Page
    {
        PersonagemJogavel personagem;
        
        public Vitoria()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string Diretorio;
            personagem = e.Parameter as PersonagemJogavel;

            if (personagem.GetType() == typeof(Worker))
            {
                personagem = (Worker)personagem;
                Diretorio = "Worker/None.png";
            }
            else if (personagem.GetType() == typeof(Expert))
            {
                personagem = (Expert)personagem;
                Diretorio = "Expert/Fubica.png";
            }
            else
            {
                personagem = (Cheater)personagem;
                Diretorio = "Cheater/Nobody.png";
            }

            ImageVencedor.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Diretorio));
        }
    }
}
