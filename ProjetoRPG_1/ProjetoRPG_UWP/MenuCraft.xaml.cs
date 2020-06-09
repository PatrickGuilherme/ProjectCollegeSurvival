using OpenQA.Selenium;
using ProjetoRPG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
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
    public sealed partial class MenuCraft : Page
    {
        private PersonagemJogavel jogador;

        public MenuCraft()
        {
            this.InitializeComponent();
            Craftar.Click += Btn_Craftar;
            Voltar.Click += Btn_Voltar;
            InstaciarItemsSecundarios();
        }

        private void Btn_Voltar(object sender, RoutedEventArgs e) 
        {
            Frame.GoBack();
        }

        private void Btn_Craftar(object sender, RoutedEventArgs e) 
        {
            //Verifica se ele selecionou um item
            if (ListaCraft.SelectedValue != null)
            {
                //Pega o item secundario selecionado
                ItemSecundario item = ListaCraft.SelectedItem as ItemSecundario;
                
                if(jogador.MenuCraft.Craftar(jogador.inventario, item)) 
                {
                    MensagemErro(item.Nome + " agora está disponivel no seu inventário", "Novo item Criado");
                }
                else MensagemErro("Você não possui itens o suficiente para craftar este item", "Não foi possivel craftar " + item.Nome);
            }
            else
            {
                MensagemErro("Selecione um item na caixa de seleção antes de clicar no botão", "Selecione um item para craftar");
            }
        }

        private async void MensagemErro(string Mensagem, string Titulo) 
        {
            var dialog = new MessageDialog(Mensagem, Titulo);
            var result = await dialog.ShowAsync();
        }

        private void InstaciarItemsSecundarios() 
        {
            ItemSecundario itemCraft;
            
            itemCraft = new ItemSecundario(1);
            ListaCraft.Items.Add(itemCraft);

            itemCraft = new ItemSecundario(2);
            ListaCraft.Items.Add(itemCraft);

            itemCraft = new ItemSecundario(3);
            ListaCraft.Items.Add(itemCraft);
            
            itemCraft = new ItemSecundario(4);
            ListaCraft.Items.Add(itemCraft);

            itemCraft = new ItemSecundario(5);
            ListaCraft.Items.Add(itemCraft);

            itemCraft = new ItemSecundario(6);
            ListaCraft.Items.Add(itemCraft);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            jogador = e.Parameter as PersonagemJogavel;
            AtualizarTela(null);
        }

        private void ListaCraft_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AtualizarTela(ListaCraft.SelectedItem as ItemSecundario);
        }
       
        private void AtualizarTela(ItemSecundario itemSec)
        {
            if(itemSec != null)
            {
                TxtItemNome.Text = itemSec.Nome;
                TxtItemDescricaoTitulo.Text = "Descrição: ";
                TxtItemDescricao.Text = itemSec.Descricao;

                TxtItemBuffeLifeTitulo.Text = "Life: ";
                TxtItemBuffeLife.Text = "+" + itemSec.BuffLife;
                
                TxtItemBuffePersistenciaTitulo.Text = "Persistência: ";
                TxtItemBuffePersistencia.Text = "+" + itemSec.BuffPersistencia;

                TxtItemBuffeAnimoTitulo.Text = "Ânimo: ";
                TxtItemBuffeAnimo.Text = "+" + itemSec.BuffAnimo;

                TxtItemBuffeEnergiaTitulo.Text = "Energia: ";
                TxtItemBuffeEnergia.Text = "+" + itemSec.BuffEnergia;

                TxtItemDanoTitulo.Text = "Dano: ";
                TxtItemDano.Text = "-" + itemSec.Dano;

                TxtItemNivelTitulo.Text = "Nível requerido: ";
                TxtItemNivel.Text = itemSec.NivelRequerido.ToString();

                CanvasItemParte1.Background = new SolidColorBrush(Colors.LightGray);//cinza
                CanvasItemParte2.Background = new SolidColorBrush(Colors.LightGray);//cinza

                string preRequisito = "";
                foreach(var iS in itemSec.ItensPreRequesito)
                {
                    preRequisito += " [" + iS.Nome + "] ";
                }
                TxtItensPreRequisitoTitulo.Text = "Requisitos: ";
                TxtItensPreRequisito.Text = preRequisito;
                SetImgItemSec(itemSec.Nome);
            }
            else
            {
                TxtItemNome.Text = "";
                TxtItemDescricao.Text = "";
                TxtItemBuffeLife.Text = "";
                TxtItemBuffePersistencia.Text = "";
                TxtItemBuffeAnimo.Text = "";
                TxtItemBuffeEnergia.Text = "";
                TxtItemDano.Text = "";
                TxtItemNivel.Text = "";
                TxtItemDescricaoTitulo.Text = "";
                TxtItemBuffeLifeTitulo.Text = "";
                TxtItemBuffePersistenciaTitulo.Text = "";
                TxtItemBuffeAnimoTitulo.Text = "";
                TxtItemBuffeEnergiaTitulo.Text = "";
                TxtItemDanoTitulo.Text = "";
                TxtItemNivelTitulo.Text = "";
                TxtItensPreRequisitoTitulo.Text = "";
                TxtItensPreRequisito.Text = "";
                CanvasItemParte1.Background = new SolidColorBrush(Colors.White);
                CanvasItemParte2.Background = new SolidColorBrush(Colors.White);

                SetImgItemSec("");
            }
        }

        private void SetImgItemSec(string nomeItem)
        {
            string diretorio = "";
            switch (nomeItem)
            {
                case "Blue Bull":
                    diretorio = "ItensSec/bluebull.png";
                break;
                case "Sunbley":
                    diretorio = "ItensSec/sunbley.png";
                break;
                case "Café":
                    diretorio = "ItensSec/cafe.png";
                break;
                case "Notas de Aula":
                    diretorio = "ItensSec/notasdeaula.png";
                break;
                case "Calculadora":
                    diretorio = "ItensSec/calculadora.png";
                break;
                case "Mini Sol":
                    diretorio = "ItensSec/minisol.png";
                break;
                default:
                    //tira a borde da exibição
                    borderImg.BorderThickness = new Thickness(0);
                break;
            }
            ItemImg.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorio));
        }
    }
}
