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
        private Worker PlayerAuxiliar = new Worker();
        private object jogador;
        private object objBlock = new Object();
        private bool MoveUp;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;
        private Timer MovementTimer = new Timer { Interval = 20 };
        private Mapa GeradorMapa = new Mapa();
        private GameObject[,] Mapa = new GameObject[46, 351];

        public Movimento()
        {
            InitializeComponent();
            Mapa = GeradorMapa.ConstruirMapa(Mapa);
            MovementTimer.Elapsed += MovementTimer_Elapsed;
        }

        private void MovementTimer_Elapsed(object sender, EventArgs e)
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

            lock (objBlock) 
            {
                DoMovement();
            }

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
            if (PlayerAuxiliar.PodeMover(Mapa, (double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador), (double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador) - 1))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) - 5);
                jogador.GetType().GetProperty("posicaoY").SetValue(jogador, Math.Round((double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador) - 0.20, 2));
            }
            PosicaoMatrizX.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador)).ToString();
            PosicaoMatrizY.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador)).ToString();
        }
        private void DownPlayer()
        {
            if (PlayerAuxiliar.PodeMover(Mapa, (double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador), (double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador) + 1))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) + 5);
                jogador.GetType().GetProperty("posicaoY").SetValue(jogador, Math.Round((double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador) + 0.20, 2));
            }
            PosicaoMatrizX.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador)).ToString();
            PosicaoMatrizY.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador)).ToString();
        }
        private void RightPlayer()
        {
            if (PlayerAuxiliar.PodeMover(Mapa, (double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador) + 1, (double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador)))
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) + 5);
                jogador.GetType().GetProperty("posicaoX").SetValue(jogador, Math.Round((double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador) + 0.20, 2));
            }
            PosicaoMatrizX.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador)).ToString();
            PosicaoMatrizY.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador)).ToString();

        }
        private void LeftPlayer()
        {
            if(PlayerAuxiliar.PodeMover(Mapa, (double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador) - 1, (double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador))) 
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) - 5);
                jogador.GetType().GetProperty("posicaoX").SetValue(jogador, Math.Round((double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador) - 0.20, 2));
            }
            PosicaoMatrizX.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoX").GetValue(jogador)).ToString();
            PosicaoMatrizY.Text = Math.Floor((double)jogador.GetType().GetProperty("posicaoY").GetValue(jogador)).ToString();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            jogador = e.Parameter; // get parameter

            //Type tp = param.GetType();

            //if (tp.Equals(typeof(Worker)))
            //{
            //    Worker player = new Worker();
            //    player.Life = 300;
            //    player.Energia = 500;
            //    player.Animo = 20;
            //    player.Persistencia = 15;
            //}
            //else if (tp.Equals(typeof(Expert)))
            //{
            //    Expert player = new Expert();
            //    player.Life = 400;
            //    player.Energia = 400;
            //    player.Animo = 15;
            //    player.Persistencia = 20;
            //}
            //else
            //{
            //    Cheater player = new Cheater();
            //    player.Life = 500;
            //    player.Energia = 300;
            //    player.Animo = 17;
            //    player.Persistencia = 18;
            //}
        }
    }


}
