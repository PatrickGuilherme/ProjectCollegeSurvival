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

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetoRPG_UWP {
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Instrucoes : Page {
        public Instrucoes() {
            this.InitializeComponent();
            Texto.FontSize = 15;
            //Texto.FontFamily = "Century Gothic";
            Texto.Text = "Movimentam o personagem:\n--W(cima)\n--S(baixo)\n   --A(Esquerda)\n--D(Direita)";
            Texto2.Text = "Mostra os status atuais do personagem";
            Texto3.Text = "Abre a tela de Craft";
            Texto4.Text = "Abre a tela de Inventário";
            BtnVoltar.Click += BtnVoltar_Click;

        }
        private void BtnVoltar_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
