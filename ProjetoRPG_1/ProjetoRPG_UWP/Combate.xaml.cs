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
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetoRPG_UWP {
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>

    public sealed partial class Combate : Page {
        PersonagemJogavel jogador;
        Personagem monstro;
        public Combate() {
            this.InitializeComponent();
            Ataque.Click += Btn_Ataque;
            Lancar_Habilidade.Click += Btn_Habilidade;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            var ListParametros = e.Parameter as List<Personagem>;
            jogador = ListParametros.ElementAt<Personagem>(0) as PersonagemJogavel;
            monstro = ListParametros.ElementAt<Personagem>(1);
            if (jogador.GetType() == typeof(Worker)) 
            {
                jogador = (Worker)jogador;
            }
            else if (jogador.GetType() == typeof(Expert)) 
            {
                jogador = (Expert)jogador;
            }
            else 
            {
                jogador = (Cheater)jogador;
            }
            monstro = (Monstro)monstro;

            int i = 0;
            jogador.Habilidades.ForEach(delegate (Habilidade habilidade) {
                if (i != 0) {
                    ListaH.Items.Add(habilidade);
                }
                i++;
            });
            AtualizarTexto();
        }

        private void Btn_Ataque(object sender, RoutedEventArgs e) {

            monstro.Life -= jogador.atacar(monstro, null, jogador.Habilidades.ElementAt<Habilidade>(0));

            AtualizarTexto();
            if (monstro.Life <= 0) {
                Frame.GoBack();
            }
        }
        private void Btn_Habilidade(object sender, RoutedEventArgs e) {
            Habilidade hbl = ListaH.SelectedItem as Habilidade;
            monstro.Life -= jogador.atacar(monstro, null, hbl);
            jogador.Energia -= hbl.GastoEnergia;
            AtualizarTexto();
            if (monstro.Life <= 0) {
                Frame.GoBack();
            }
        }
        private void AtualizarTexto() {
            Vida.Text = "Vida: " + jogador.Life.ToString();
            Energia.Text = "Energia: " + jogador.Energia;
            VidaM.Text = "Vida: " + monstro.Life.ToString();
            EnergiaM.Text = "Energia: " + monstro.Energia;
        }
    }
}
