using ProjetoRPG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

            if (jogador.GetType() == typeof(Worker)) ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/Worker/Down.gif"));
            else if (jogador.GetType() == typeof(Expert)) ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/Expert/Down.gif"));
            else ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/Cheater/Down.gif"));
            
            int contX = 0, contY = 0, cont = 0;
            foreach (var item in jogador.inventario.Itens.ToList())
            {
                ListItems.Add(item);
                Button button = new Button();
                button.Width = 216;
                button.Height = 84;
                button.Name = cont.ToString();
                cont++;
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/mesa.jpg"));
                button.Content = image;
                button.Click += Btn_Click;
                TabelaItens.Children.Add(button);

                button.Background = new SolidColorBrush(Colors.White);
                button.BorderBrush = new SolidColorBrush(Colors.Black);
                ToolTip toolTip = new ToolTip();
                
                if (item.GetType() == typeof(ItemSecundario)) 
                {
                    toolTip.Content = item.Nome + ":\n\n" + item.Descricao;
                }
                else toolTip.Content = item.Nome + ":\n\n" + "Use esse bagulho pra fazer algo mais POTENTE.";

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

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Debug.WriteLine(ListItems.ElementAt<Item>(int.Parse(btn.Name)).Nome);
        }
    }
}
