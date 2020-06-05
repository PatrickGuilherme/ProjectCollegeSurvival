using ProjetoRPG;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    public sealed partial class ExibirInventario : Page
    {
        private PersonagemJogavel jogador;
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
            jogador = e.Parameter as PersonagemJogavel;
            int contX = 0, contY = 0;
            foreach (var item in jogador.inventario.Itens.ToList())
            {
                Button button = new Button();
                button.Content = item;
                button.Width = 252;
                button.Height = 72;
                Image image = new Image();
                image.Width = 252;
                image.Height = 72;
                image.Source = new BitmapImage(new Uri("ms-appx:///Assets/mesa.jpg"));
                button.Content = image;
                TabelaItens.Children.Add(button);
                //button.Background = (Brush)Color.White;
                //button.BorderBrush = (SolidColorBrush)Resources["Black"];
                
                Canvas.SetLeft(button, 252 * contX);
                Canvas.SetTop(button, 72 * contY);

                contX++;
                if(contX == 3) 
                {
                    contX = 0;
                    contY++;
                }
            }
        }
    }
}
