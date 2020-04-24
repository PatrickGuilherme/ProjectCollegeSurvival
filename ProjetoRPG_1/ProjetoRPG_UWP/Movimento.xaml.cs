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
using ProjetoRPG;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Threading.Tasks;
using OpenQA.Selenium;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    
    public sealed partial class Movimento : Page
    {
        public Movimento()
        {
            this.InitializeComponent();
        }

        protected override async void OnKeyDown(KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == Windows.System.VirtualKey.Down)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Down // O Método a ser chamado
                );
            }
            else if (e.Key == Windows.System.VirtualKey.Up)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Up // O Método a ser chamado
                );
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Right // O Método a ser chamado
                );
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.Normal,
                    Left // O Método a ser chamado
                );
            }
        }

        private async void Left()
        {
            // Manipular o componente de Interface
            ImgPlayerTranslateTransform.X -= 10;
            //Canvas.SetLeft(ImgBestFriend, Canvas.GetLeft(ImgBestFriend) - 5);
        }

        private async void Down()
        {
            // Manipular o componente de Interface
            ImgPlayerTranslateTransform.Y += 10;
            //Canvas.SetTop(ImgBestFriend, Canvas.GetTop(ImgBestFriend) + 5);
        }

        private async void Up()
        {
            // Manipular o componente de Interface
            ImgPlayerTranslateTransform.Y -= 10; 
            // Canvas.SetTop(ImgBestFriend, Canvas.GetTop(ImgBestFriend) - 5);

        }

        private async void Right()
        {
            // Manipular o componente de Interface
            ImgPlayerTranslateTransform.X += 10;
            //Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) + 5);

        }
    }


}
