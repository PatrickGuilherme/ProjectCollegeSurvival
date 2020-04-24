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
using System.Timers;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    
    public sealed partial class Movimento : Page
    {
        private bool MoveUp;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;
        private Timer MovementTimer = new Timer { Interval = 20 };

        public Movimento()
        {
            InitializeComponent();
            MovementTimer.Elapsed += movementTimer_Elapsed;
        }

        private void movementTimer_Elapsed(object sender, EventArgs e)
        {
            DoMovement();
        }

        private void DoMovement()
        {
            if (MoveLeft) Left();
            if (MoveRight) Right();
            if (MoveUp) Up();
            if (MoveDown) Down();
        }

        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            //base.OnKeyDown(e);
            if (e.Key == Windows.System.VirtualKey.Down)
            {
                MoveDown = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Up)
            {
                MoveUp = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                MoveRight = true;
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                MoveLeft = true;
            }

            DoMovement();
            MovementTimer.Start();
        }

        protected override void OnKeyUp(KeyRoutedEventArgs e) 
        {
            if (e.Key == Windows.System.VirtualKey.Down)
            {
                MoveDown = false;
            }
            else if (e.Key == Windows.System.VirtualKey.Up)
            {
                MoveUp = false;
            }
            else if (e.Key == Windows.System.VirtualKey.Right)
            {
                MoveRight = false;
            }
            else if (e.Key == Windows.System.VirtualKey.Left)
            {
                MoveLeft = false;
            }

            if (!(MoveUp || MoveDown || MoveLeft || MoveRight))
            {
                MovementTimer.Stop();
            }
        }

        private async void Left()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, LeftPlayer);
        }
        private async void Down()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, DownPlayer);
        }

        private async void Up()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, UpPlayer);
        }

        private async void Right()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, RightPlayer);
        }

        private void UpPlayer() 
        {
            Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) - 5);
        }
        private void DownPlayer()
        {
            Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) + 5);
        }
        private void RightPlayer()
        {
            Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) + 5);
        }
        private void LeftPlayer()
        {
            Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) - 5);
        }
    }


}
