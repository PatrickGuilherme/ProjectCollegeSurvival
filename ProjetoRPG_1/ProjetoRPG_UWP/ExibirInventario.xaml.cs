using OpenQA.Selenium.Interactions;
using ProjetoRPG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class ExibirInventario : Page
    {
        private PersonagemJogavel jogador;
        private List<Item> ListItems;
        public ExibirInventario()
        {
            this.InitializeComponent();
            Voltar.Click += Btn_Voltar;
        }

        private void Btn_Voltar(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private Image IgmItens(string nomeItem)
        {
            Image image = new Image();
            string diretorio = "";
            switch (nomeItem)
            {
                case "Garrafa Vazia":
                    diretorio = "ItensPri/garrafavazia.png";
                    break;
                case "Água":
                    diretorio = "ItensPri/agua.png";
                    break;
                case "Substância Química":
                    diretorio = "ItensPri/substanciaquimica.png";
                    break;
                case "Pão":
                    diretorio = "ItensPri/pao.png";
                    break;
                case "Pombo":
                    diretorio = "ItensPri/pombo.png";
                    break;
                case "Pó":
                    diretorio = "ItensPri/po.png";
                    break;
                case "Papel":
                    diretorio = "ItensPri/papel.png";
                    break;
                case "Giz":
                    diretorio = "ItensPri/giz.png";
                    break;
                case "Mecanismo Eletrônico":
                    diretorio = "ItensPri/mecanismoeletronico.png";
                    break;
                case "Vidraria":
                    diretorio = "ItensPri/vidraria.png";
                    break;
                case "Blue Bull":
                    diretorio = "ItensSec/blueBull.png";
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
                case "Agenda":
                    diretorio = "mesa.jpg";
                    break;
                case "Caderno 1M":
                    diretorio = "mesa.jpg";
                    break;
                case "Caderno 10M":
                    diretorio = "mesa.jpg";
                    break;
                case "Enciclopédia":
                    diretorio = "mesa.jpg";
                    break;
                case "Notebook":
                    diretorio = "mesa.jpg";
                    break;
                case "Lápis":
                    diretorio = "mesa.jpg";
                    break;
                case "Lápis Mecânico":
                    diretorio = "mesa.jpg";
                    break;
                case "Caneta":
                    diretorio = "mesa.jpg";
                    break;
                case "Borracha Branca":
                    diretorio = "mesa.jpg";
                    break;
                case "Borracha Azul":
                    diretorio = "mesa.jpg";
                    break;
                case "Borracha Duas Cores":
                    diretorio = "mesa.jpg";
                    break;
                default:
                    diretorio = "mesa.jpg";
                    break;
            }
            image.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorio));
            return image;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ListItems = new List<Item>();
            jogador = e.Parameter as PersonagemJogavel;

            //Dependendo do jogador uma imagem diferente aparecerá.
            if (jogador.GetType() == typeof(Worker)) ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/Worker/Down.gif"));
            else if (jogador.GetType() == typeof(Expert)) ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/Expert/Down.gif"));
            else ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/Cheater/Down.gif"));
            
            //variaveis que definiram o nome, contador de colunas e contador de linhas.
            int contX = 0, contY = 0, cont = 0;

            //Passará para cada item no inventário e criará um botão para eles
            foreach (var item in jogador.inventario.Itens.ToList())
            {
                ListItems.Add(item);

                Image image;

                //Dependendo do item mudar a source da imagem
                image = IgmItens(item.Nome);

                Button button = new Button();
                button.Width = 216;
                button.Height = 84;

                //Para acessar o item respectivo ao botão usa o nome dele que reflete a posição do item na lista
                button.Name = cont.ToString();

                button.Content = image;
                button.Click += Btn_ClickEsquerdo;
                button.PointerPressed += Btn_ClickDireito;
                cont++;

                //Adiciona o botão criado dentro do canvas
                TabelaItens.Children.Add(button);

                if(item.GetType() == typeof(Equipamento) && jogador.EquipamentosEquipados.Contains(item as Equipamento)) 
                {
                    button.Background = new SolidColorBrush(Colors.Red);
                } else button.Background = new SolidColorBrush(Colors.White); 
                button.BorderBrush = new SolidColorBrush(Colors.Black);

                ToolTip toolTip = new ToolTip();
                
                toolTip.Content = item.Nome + ":\n\n" + item.Descricao;

                ToolTipService.SetToolTip(button, toolTip);

                Canvas.SetLeft(button, 216 * contX);
                Canvas.SetTop(button, 84 * contY);

                contX++;
                if(contX == 3) 
                {
                    contX = 0;
                    contY++;
                }
            }
        }

        private async void Btn_ClickEsquerdo(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            //Tratamento quando foi selecionado um equipamento
            if (ListItems.ElementAt<Item>(int.Parse(btn.Name)).GetType() == typeof(Equipamento))
            {
                // Caso ele já tenha equipado, selecionar de novo removerá o equipamento
                if (jogador.EquipamentosEquipados.Contains(ListItems.ElementAt<Item>(int.Parse(btn.Name))))
                {
                    btn.Background = new SolidColorBrush(Colors.White);
                    jogador.DesequiparEquipamento(ListItems.ElementAt<Item>(int.Parse(btn.Name)) as Equipamento);
                }
                // Caso ele não tenha equipado, ele equipará o item e deixará o botão vermelho para sinalizar o jogador
                else
                {
                    // Outra verificação é feita para ver se o jogador tem os status necessários para equipar o item selecionado
                    if (jogador.EquiparEquipamento(ListItems.ElementAt<Item>(int.Parse(btn.Name)) as Equipamento))
                    {
                        btn.Background = new SolidColorBrush(Colors.Red);
                        AvisoEquipado.IsOpen = true;
                        await Task.Delay(1000);
                        AvisoEquipado.IsOpen = false;
                    }
                }
            }
        }

        private void RemoverItem(Inventario inventario, Item item)
        {
            int cont = 0;
            foreach (var i in inventario.Itens.ToList())
            {
                if (i.Nome == item.Nome)
                {
                    inventario.Itens.RemoveAt(cont);
                    break;
                }
                cont++;
            }
        }

        private void Btn_ClickDireito(object sender, PointerRoutedEventArgs e)
        {
            Button btn = (Button)sender;

            Windows.UI.Xaml.Input.Pointer ptr = e.Pointer;
            Windows.UI.Input.PointerPoint ptrPt = e.GetCurrentPoint(btn);
            var properties = e.GetCurrentPoint(this).Properties;

            if (ptrPt.Properties.IsRightButtonPressed)
            {
              
                btn.Click -= Btn_ClickEsquerdo;
                btn.PointerPressed -= Btn_ClickDireito;
                btn.Visibility = Visibility.Collapsed;

                //desequipar
                if(ListItems.ElementAt<Item>(int.Parse(btn.Name)).GetType() == typeof(Equipamento) &&
                    jogador.EquipamentosEquipados.Contains(ListItems.ElementAt<Item>(int.Parse(btn.Name))))
                {
                    jogador.DesequiparEquipamento(ListItems.ElementAt<Item>(int.Parse(btn.Name)) as Equipamento);
                }

                RemoverItem(jogador.inventario, ListItems.ElementAt<Item>(int.Parse(btn.Name)));
            }
        }
    }
}
