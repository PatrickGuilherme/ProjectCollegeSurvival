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
using System.Diagnostics;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    
    public sealed partial class Movimento : Page
    {
        private Worker PlayerAuxiliar = new Worker();
        private PersonagemJogavel jogador;
        private Mapa Mapa;
        private object objBlock = new Object();
        private bool MoveUp;
        private double PosicaoAux;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;
        private Timer MovementTimer = new Timer { Interval = 20 };
        

        public Movimento()
        {
            InitializeComponent();
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
            if (PlayerAuxiliar.PodeMover(Mapa.MapaJogo, jogador.PosicaoX, jogador.PosicaoY - 0.084))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) - 5);
                jogador.PosicaoY = Math.Round(jogador.PosicaoY - 0.084, 5);
            }
            else if(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)].Deslocamento != null)
            {
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem(0, -0.084);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                    jogador,
                    Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - 0.084), (int)Math.Floor(jogador.PosicaoX)] = null;
                MoveUp = false;
                MoveDown = false;
                MoveLeft = false;
                MoveRight = false;
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }
        private void DownPlayer()
        {
            if (PlayerAuxiliar.PodeMover(Mapa.MapaJogo, jogador.PosicaoX, jogador.PosicaoY + 0.084))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) + 5);
                jogador.PosicaoY  = Math.Round(jogador.PosicaoY + 0.084, 5);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)].Deslocamento != null)
            {
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem(0, 0.084);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                    jogador,
                    Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + 0.084), (int)Math.Floor(jogador.PosicaoX)] = null;
                MoveUp = false;
                MoveDown = false;
                MoveLeft = false;
                MoveRight = false;
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }
        private void RightPlayer()
        {
            if (PlayerAuxiliar.PodeMover(Mapa.MapaJogo, jogador.PosicaoX + 0.050, jogador.PosicaoY))
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) + 5);
                jogador.PosicaoX = Math.Round(jogador.PosicaoX + 0.050, 5);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)].Deslocamento != null)
            {
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem(0.050, 0);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                jogador,
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + 0.050)] = null;
                MoveUp = false;
                MoveDown = false;
                MoveLeft = false;
                MoveRight = false;
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }
        private void LeftPlayer()
        {
            if(PlayerAuxiliar.PodeMover(Mapa.MapaJogo, jogador.PosicaoX - 0.050, jogador.PosicaoY)) 
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) - 5);
                jogador.PosicaoX = Math.Round(jogador.PosicaoX - 0.050, 5);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)].Deslocamento != null)
            {
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem(-0.050, 0);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                jogador,
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - 0.050)] = null;
                MoveUp = false;
                MoveDown = false;
                MoveLeft = false;
                MoveRight = false;
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }

        private void AtualizarImagem(double X, double Y) 
        {
            Canvas.SetLeft(ImgPlayer, 100 * (((jogador.PosicaoX + X) - Math.Floor((jogador.PosicaoX + X) / 12) * 12)));
            Canvas.SetTop(ImgPlayer, 70 * ((jogador.PosicaoY + Y) - Math.Floor((jogador.PosicaoY + Y) / 9) * 9));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var ListParametros = e.Parameter as List<object>;
            jogador = ListParametros.ElementAt<object>(0) as PersonagemJogavel;
            Mapa = ListParametros.ElementAt<object>(1) as Mapa;

            Debug.WriteLine(jogador.ToString());
            if(jogador.GetType() == typeof(Worker))
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
            AtualizarImagem(0, 0);
            /*AREA DE TESTE*/
            Debug.WriteLine("ITENS ECONTRADOS: " + jogador.inventario.Itens.Count) ;
            Debug.WriteLine("LIFE: " + jogador.Life);
            Debug.WriteLine("ENERGIA: " + jogador.Energia);
            Debug.WriteLine("CONHECIMENTO: " + jogador.Conhecimento);
            Debug.WriteLine("NIVEL: " + jogador.Nivel);
            /*===========*/
        }
    }


}
