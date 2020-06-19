using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public sealed partial class HistoriaGame : Page
    {
        public HistoriaGame()
        {
            this.InitializeComponent();
            BtnVoltar.Click += BtnVoltar_Click;
            BtnAcao.Click += BtnAcao_Click;
            BtnMudarImagem.Click += BtnMudarImagem_Click;
            string historia = "João None Workefield, Tais Fubica Expers e Zé Nobody Cheafer são estudante calouros na graduação de engenharia na instituição SENSE(Serviço Nacional de Sobrevivência Escolar). Como estudantes eles devem enfrentar os desafios da vida acadêmica, estes envolvem derrotar todos reis dos monstros do conhecimento(Lapain, Toest, Atom e Anaculo) que farão de tudo para prender os estudantes em um looping infinito de repetição de acontecimentos, ou seja, a cada morte você irá reiniciar tudo. Cabe a você ajudar estes estudantes a enfrentarem estes desafios.";
            TxtHistoria.Text = historia;
        }

        private void BtnMudarImagem_Click(object sender, RoutedEventArgs e)
        {
            ImgMonstros.Visibility = Visibility.Visible;
            TxtHistoria.Text = "";
            BtnMudarImagem.Visibility = Visibility.Collapsed;
            BtnAcao.Visibility = Visibility.Visible;
        }

        private void BtnAcao_Click(object sender, RoutedEventArgs e)
        {
                this.Frame.Navigate(typeof(Page2));
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
