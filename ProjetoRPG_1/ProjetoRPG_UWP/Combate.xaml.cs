using ProjetoRPG;
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
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetoRPG_UWP {
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>

    public sealed partial class Combate : Page {
        PersonagemJogavel jogador;
        Monstro monstro;
        int rand;

        public Combate() {
            this.InitializeComponent();
            Ataque.Click += Btn_Ataque;
            Lancar_Habilidade.Click += Btn_Habilidade;
            Inventario.Click += Btn_Inventario;
            Defesa.Click += Btn_Defesa;
        }

        private void Btn_Inventario(object sender, RoutedEventArgs e)
        {
            if(ListaI.SelectedValue != null) {
                Item item = ListaI.SelectedItem as ItemSecundario;
                jogador.UsarItem(item);
                monstro.Life -= jogador.atacar(monstro, item, null);
                AtualizarTexto();
                ListaI.Items.Remove(item);
                checkLife();
            }
        }

        private void Btn_Defesa(object sender, RoutedEventArgs e)
        {
            jogador.Persistencia += 5;
            rand = InteligenciaAtacando(-1);
            AtualizarTexto();
            checkLife();
            jogador.Persistencia -= 5;

        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);

            var ListParametros = e.Parameter as List<Personagem>;
            jogador = ListParametros.ElementAt<Personagem>(0) as PersonagemJogavel;
            monstro = ListParametros.ElementAt<Personagem>(1) as Monstro;
            rand = -1;
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
            
            int i = 0;
            jogador.inventario.GetItemSecundarios().ForEach(delegate (ItemSecundario itemSecundario)
            {
                ListaI.Items.Add(itemSecundario);
            });

            jogador.Habilidades.ForEach(delegate (Habilidade habilidade) {
                if (i != 0) {
                    ListaH.Items.Add(habilidade);
                }
                i++;
            });

            /*AREA DE TESTE*/
            monstro.ConhecimentoDrop = 250;
            Item item = new ItemPrimario();
            item.Nome = "EAI MEN!!!";
            monstro.ItemDrop = item;
            /*============*/

            AtualizarTexto();
        }

        private void Btn_Ataque(object sender, RoutedEventArgs e) {
            rand = InteligenciaAtacando(rand);
            monstro.Life -= jogador.atacar(monstro, null, jogador.Habilidades.ElementAt<Habilidade>(0));
            AtualizarTexto();
            checkLife();
        }
        private void checkLife()
        {
            //monstro morto jogador vivo
            if (monstro.Life <= 0 && jogador.Life > 0)
            {
                if (monstro.ItemDrop != null)
                {
                    jogador.ColetarItem(monstro.ItemDrop);
                }
                jogador.Conhecimento += monstro.ConhecimentoDrop;
                jogador.LevelUp();
                Frame.GoBack();
                
            }
            //jogador morto monstro vivo
            else if(jogador.Life <= 0)
            {
                //criar tela ou mensagem de personagem morto (game over)
            }
        }
        private void Btn_Habilidade(object sender, RoutedEventArgs e) {
            if (ListaH.SelectedValue != null)
            {
                Habilidade hbl = ListaH.SelectedItem as Habilidade;
                //verificar se o usuario tem a energia para usar a habilidade
                jogador.UsarHabilidade(hbl);
                rand = InteligenciaAtacando(rand);
                monstro.Life -= jogador.atacar(monstro, null, hbl);               
                jogador.Energia -= hbl.GastoEnergia;
                AtualizarTexto();
                checkLife();
                

            }
        }
        private void AtualizarTexto() {
            Vida.Text = "Vida: " + jogador.Life.ToString();
            Energia.Text = "Energia: " + jogador.Energia;
            VidaM.Text = "Vida: " + monstro.Life.ToString();
            EnergiaM.Text = "Energia: " + monstro.Energia;

        }
        
        private int InteligenciaAtacando(int antRandom)
        {
            //o random anterior define se retira ou não a persistencia do inimigo
            if(antRandom > 10 && antRandom < 17)
            {
                monstro.Persistencia -= 5;
            }
            Random random = new Random();
            int numRandom = random.Next(20);
            Debug.WriteLine("numero sorteado " + numRandom);

            if (numRandom <= 10 || antRandom == -1)
            {
                if(numRandom < 5)
                {

                    monstro.UsarHabilidade(monstro.Habilidades[0]);
                    jogador.Life -= monstro.atacar(jogador, null, monstro.Habilidades[0]);
                    Debug.WriteLine("Ele atacou com poder 1");
                }
                else
                {
                    monstro.UsarHabilidade(monstro.Habilidades[1]);
                    jogador.Life -= monstro.atacar(jogador, null, monstro.Habilidades[1]);
                    Debug.WriteLine("Ele atacou com poder 2");
                }
            }
            else
            {
                if(numRandom < 17)
                {
                    monstro.Persistencia += 5;
                    Debug.WriteLine("Ele defendeu");
                    //defender
                }
            }
            return numRandom;
        }
        
    }
}
