using ProjetoRPG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

                Image image = new Image();

                //Dependendo do item mudar a source da imagem
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/mesa.jpg"));

                Button button = new Button();
                button.Width = 216;
                button.Height = 84;

                //Para acessar o item respectivo ao botão usa o nome dele que reflete a posição do item na lista
                button.Name = cont.ToString();

                button.Content = image;
                button.Click += Btn_Click;

                cont++;

                //Adiciona o botão criado dentro do canvas
                TabelaItens.Children.Add(button);

                if(item.GetType() == typeof(Equipamento) && jogador.EquipamentosEquipados.Contains(item as Equipamento)) 
                {
                    button.Background = new SolidColorBrush(Colors.Red);
                } else button.Background = new SolidColorBrush(Colors.White); 
                button.BorderBrush = new SolidColorBrush(Colors.Black);

                ToolTip toolTip = new ToolTip();
                
                if (item.GetType() == typeof(ItemPrimario)) 
                {
                    toolTip.Content = item.Nome + ":\n\n" + "Use esse bagulho pra fazer algo mais POTENTE.";
                }
                else toolTip.Content = item.Nome + ":\n\n" + item.Descricao;

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

        private async void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            //Debug.WriteLine(ListItems.ElementAt<Item>(int.Parse(btn.Name)).Nome);

            //Tratamento quando foi selecionado um equipamento
            if (ListItems.ElementAt<Item>(int.Parse(btn.Name)).GetType() == typeof(Equipamento)) 
            {
                // Caso ele já tenha equipado, selecionar de novo removerá o equipamento
                if (jogador.EquipamentosEquipados.Contains(ListItems.ElementAt<Item>(int.Parse(btn.Name)))) 
                {
                    btn.Background = new SolidColorBrush(Colors.White);
                    jogador.EquipamentosEquipados.Remove(ListItems.ElementAt<Item>(int.Parse(btn.Name)) as Equipamento);
                }
                // Caso ele não tenha equipado, ele equipará o item e deixará o botão vermelho para sinalizar o jogador
                else 
                {
                    // Outra verificação é feita para ver se o jogador tem os status necessários para equipar o item selecionado
                    if(jogador.EquiparEquipamento(ListItems.ElementAt<Item>(int.Parse(btn.Name)) as Equipamento)) 
                    {
                        btn.Background = new SolidColorBrush(Colors.Red);
                        AvisoEquipado.IsOpen = true;
                        await Task.Delay(1000);
                        AvisoEquipado.IsOpen = false;
                    }
                }
            }
            else if(ListItems.ElementAt<Item>(int.Parse(btn.Name)).GetType() == typeof(ItemSecundario)) 
            {
                
            }
            else 
            {
                
            }
        }
    }
}
