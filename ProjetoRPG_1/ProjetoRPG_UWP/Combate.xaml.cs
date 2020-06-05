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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace ProjetoRPG_UWP {
    
    public sealed partial class Combate : Page {
        private PersonagemJogavel jogador;
        private Monstro monstro;
        private int rand, contPersistencia = 0, contAnimo = 0;

        /// <summary>
        /// Metodo construtor para assinar os eventos da tela do XAML
        /// </summary>
        public Combate() {
            this.InitializeComponent();
            Ataque.Click += Btn_Ataque;
            ListaH.SelectionChanged += ComboBox_SelectionChanged;
            Lancar_Habilidade.Click += Btn_Habilidade;
            Inventario.Click += Btn_Inventario;
            Defesa.Click += Btn_Defesa;
        }

        /// <summary>
        /// Metodo de exibição de descrição de itens (Em construção)
        /// </summary>
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Habilidade hbl = ListaH.SelectedItem as Habilidade;
            //Descricao.Text = hbl.Descricao;
        }
    
        /// <summary>
        /// Metodo para utilizar um item selecionado no combobox
        /// </summary>
        private void Btn_Inventario(object sender, RoutedEventArgs e)
        {
            if(ListaI.SelectedValue != null) {
                Item item = ListaI.SelectedItem as ItemSecundario;
                //Aplicar boost no personagem
                jogador.UsarItem(item);

                //Atacar monstro
                monstro.Life -= jogador.Atacar(monstro, item, null);

                AtualizarTexto();
                //Remove item do combobox
                ListaI.Items.Remove(item);

                //Checa se alguem morreu
                checkLife();
            }
        }


        /// <summary>
        /// Metodo para aumentar a persistencia (defesa) do personagem para 
        /// </summary> 
        private void Btn_Defesa(object sender, RoutedEventArgs e)
        {
            jogador.Persistencia += 5;
            
            //Inteligencia do inimigo 
            rand = InteligenciaAtacando(-1);
            AtualizarTexto();
            checkLife();
            jogador.Persistencia -= 5;

        }
        /// <summary>
        /// Metodo para transição de telas
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            base.OnNavigatedTo(e);
            
            //Captura os personagens vindos de outra tela (movimento) 
            var ListParametros = e.Parameter as List<Personagem>;
            jogador = ListParametros.ElementAt<Personagem>(0) as PersonagemJogavel;
            monstro = ListParametros.ElementAt<Personagem>(1) as Monstro;
            rand = -1;

            //Definir a classe do personagem jogavel
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
            
            //Preenche na combobox os itens do jogador
            int i = 0;
            jogador.inventario.GetItemSecundarios().ForEach(delegate (ItemSecundario itemSecundario)
            {
                ListaI.Items.Add(itemSecundario);
            });

            //Preenche na combobox as habilidades do jogador
            jogador.Habilidades.ForEach(delegate (Habilidade habilidade) {
                if (i != 0) {
                    ListaH.Items.Add(habilidade);
                }
                i++;
            });

            /*Monstro de teste que dropa item*/
            monstro.ConhecimentoDrop = 250;
            Item item = new ItemPrimario();
            item.Nome = "EAI MEN!!!";
            monstro.ItemDrop = item;

            AtualizarTexto();
        }

        /// <summary>
        /// Metodo de utilização da habilidade mais basica do personagem
        /// </summary>
        private void Btn_Ataque(object sender, RoutedEventArgs e) {
            rand = InteligenciaAtacando(rand);
            monstro.Life -= jogador.Atacar(monstro, null, jogador.Habilidades.ElementAt<Habilidade>(0));
            AtualizarTexto();
            //verifica quem morreu
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
                jogador.Animo -= contAnimo;
                jogador.Persistencia -= contPersistencia;
                jogador.LevelUp();
                Frame.GoBack();
            }
            //jogador morto monstro vivo
            else if(jogador.Life <= 0)
            {
                //criar tela ou mensagem de personagem morto (game over)
            }
        }

        /// <summary>
        /// Metodo para utilizar uma habilidade selecionada no combobox do jogador
        /// </summary>
        private void Btn_Habilidade(object sender, RoutedEventArgs e) {
            if (ListaH.SelectedValue != null)
            {
                Habilidade hbl = ListaH.SelectedItem as Habilidade;
                //verificar se o usuario tem a energia para usar a habilidade
                if (jogador.UsarHabilidade(hbl))
                {
                    //armazena os buffes para tirar no fim da rodada
                    contAnimo += hbl.BuffAnimo;
                    contPersistencia += hbl.BuffPersistencia;
                    
                    //habilidade de passar a vez
                    if (!hbl.DesativaHabilidade) 
                    {
                        rand = InteligenciaAtacando(rand);
                        Debug.WriteLine("PERDEU PLEBA");
                    } 

                    //ataque do jogador
                    monstro.Life -= jogador.Atacar(monstro, null, hbl);
                    jogador.Energia -= hbl.GastoEnergia;
                }
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

        /// <summary>
        /// Metodo para descrever a inteligencia do personagem
        /// </summary>
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
                    jogador.Life -= monstro.Atacar(jogador, null, monstro.Habilidades[0]);
                    Debug.WriteLine("Ele atacou com poder 1");
                }
                else
                {
                    monstro.UsarHabilidade(monstro.Habilidades[1]);
                    jogador.Life -= monstro.Atacar(jogador, null, monstro.Habilidades[1]);
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
