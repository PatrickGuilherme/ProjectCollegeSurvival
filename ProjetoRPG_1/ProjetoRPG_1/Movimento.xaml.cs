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
        private PersonagemJogavel PersonagemAuxiliar;
        private object jogador;
        private object objBlock = new Object();
        private bool MoveUp;
        private double PosicaoX = 20, PosicaoY = 2, PosicaoAux;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;
        private Timer MovementTimer = new Timer { Interval = 20 };
        private Mapa GeradorMapa = new Mapa();
        private GameObject[,] Mapa = new GameObject[9, 132];

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
            if (PlayerAuxiliar.PodeMover(Mapa, PosicaoX, PosicaoY - 0.084))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) - 5);
                PosicaoY = Math.Round(PosicaoY - 0.084, 5);
            }
            else if(Mapa[(int)Math.Floor(PosicaoY - 0.084), (int)Math.Floor(PosicaoX)].Deslocamento != null)
            {
                PosicaoAux = Mapa[(int)Math.Floor(PosicaoY - 0.084), (int)Math.Floor(PosicaoX)].Deslocamento[0];
                PosicaoX = Mapa[(int)Math.Floor(PosicaoY - 0.084), (int)Math.Floor(PosicaoX)].Deslocamento[1];
                PosicaoY = PosicaoAux;
                Canvas.SetLeft(ImgPlayer, 100 * ((PosicaoX - Math.Floor(PosicaoX / 12) * 12)));
                Canvas.SetTop(ImgPlayer, 70 * ((PosicaoY - 0.084) - Math.Floor((PosicaoY - 0.084) / 9) * 9));
            }
            else if (Mapa[(int)Math.Floor(PosicaoY - 0.084), (int)Math.Floor(PosicaoX)].I != null)
            {
                PersonagemAuxiliar.ColetarItem(Mapa[(int)Math.Floor(PosicaoY - 0.084), (int)Math.Floor(PosicaoX)].I);
                Debug.WriteLine("QUANTIDADE DE ITENS ENCONTRADOS = {0}", PersonagemAuxiliar.inventario.Itens.Count);
                Mapa[(int)Math.Floor(PosicaoY - 0.084), (int)Math.Floor(PosicaoX)] = null;
            }
            PosicaoMatrizX.Text = Math.Floor(PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(PosicaoY).ToString();
        }
        private void DownPlayer()
        {
            if (PlayerAuxiliar.PodeMover(Mapa, PosicaoX, PosicaoY + 0.084))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) + 5);
                PosicaoY  = Math.Round(PosicaoY + 0.084, 5);
            }
            else if (Mapa[(int)Math.Floor(PosicaoY + 0.084), (int)Math.Floor(PosicaoX)].Deslocamento != null)
            {
                PosicaoAux = Mapa[(int)Math.Floor(PosicaoY + 0.084), (int)Math.Floor(PosicaoX)].Deslocamento[0];
                PosicaoX = Mapa[(int)Math.Floor(PosicaoY + 0.084), (int)Math.Floor(PosicaoX)].Deslocamento[1];
                PosicaoY = PosicaoAux;
                Canvas.SetLeft(ImgPlayer, 100 * ((PosicaoX - Math.Floor(PosicaoX / 12) * 12)));
                Canvas.SetTop(ImgPlayer, 70 * ((PosicaoY + 0.084) - Math.Floor((PosicaoY + 0.084) / 9) * 9));
            }
            else if (Mapa[(int)Math.Floor(PosicaoY + 0.084), (int)Math.Floor(PosicaoX)].I != null)
            {
                PersonagemAuxiliar.ColetarItem(Mapa[(int)Math.Floor(PosicaoY + 0.084), (int)Math.Floor(PosicaoX)].I);
                Debug.WriteLine("QUANTIDADE DE ITENS ENCONTRADOS = {0}", PersonagemAuxiliar.inventario.Itens.Count);
                Mapa[(int)Math.Floor(PosicaoY + 0.084), (int)Math.Floor(PosicaoX)] = null;
            }
            PosicaoMatrizX.Text = Math.Floor(PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(PosicaoY).ToString();
        }
        private void RightPlayer()
        {
            if (PlayerAuxiliar.PodeMover(Mapa, PosicaoX + 0.050, PosicaoY))
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) + 5);
                PosicaoX = Math.Round(PosicaoX + 0.050, 5);
            }
            else if (Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX + 0.050)].Deslocamento != null)
            {
                PosicaoAux = Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX + 0.050)].Deslocamento[0];
                PosicaoX = Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX + 0.050)].Deslocamento[1];
                PosicaoY = PosicaoAux;
                Canvas.SetLeft(ImgPlayer, 100 * (((PosicaoX + 0.050) - Math.Floor((PosicaoX + 0.050) / 12) * 12)));
                Canvas.SetTop(ImgPlayer, 70 * (PosicaoY - Math.Floor(PosicaoY / 9) * 9));
            }
            else if (Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX + 0.050)].I != null)
            {
                PersonagemAuxiliar.ColetarItem(Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX + 0.050)].I);
                Debug.WriteLine("QUANTIDADE DE ITENS ENCONTRADOS = {0}", PersonagemAuxiliar.inventario.Itens.Count);
                Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX + 0.050)] = null;
            }
            PosicaoMatrizX.Text = Math.Floor(PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(PosicaoY).ToString();
        }
        private void LeftPlayer()
        {
            if(PlayerAuxiliar.PodeMover(Mapa, PosicaoX - 0.050, PosicaoY)) 
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) - 5);
                PosicaoX = Math.Round(PosicaoX - 0.050, 5);
            }
            else if (Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX - 0.050)].Deslocamento != null)
            {
                PosicaoAux = Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX - 0.050)].Deslocamento[0];
                PosicaoX = Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX - 0.050)].Deslocamento[1];
                PosicaoY = PosicaoAux;
                Canvas.SetLeft(ImgPlayer, 100 * (((PosicaoX - 0.050) - Math.Floor((PosicaoX - 0.050) / 12) * 12)));
                Canvas.SetTop(ImgPlayer, 70 * (PosicaoY - Math.Floor(PosicaoY / 9) * 9));
            }
            else if (Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX - 0.050)].I != null)
            {
                PersonagemAuxiliar.ColetarItem(Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX - 0.050)].I);
                Debug.WriteLine("QUANTIDADE DE ITENS ENCONTRADOS = {0}", PersonagemAuxiliar.inventario.Itens.Count);
                Mapa[(int)Math.Floor(PosicaoY), (int)Math.Floor(PosicaoX - 0.050)] = null;
            }
            PosicaoMatrizX.Text = Math.Floor(PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(PosicaoY).ToString();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            jogador = e.Parameter;
            Debug.WriteLine(jogador.ToString());
            if(jogador.GetType() == typeof(Worker))
            {
                jogador = Convert.ChangeType(jogador, typeof(Worker));
                PersonagemAuxiliar = (Worker)jogador;
            }
            else if (jogador.GetType() == typeof(Expert))
            {
                jogador = Convert.ChangeType(jogador, typeof(Expert));
            }
            else 
            {
                jogador = Convert.ChangeType(jogador, typeof(Cheater));
            }
        }
    }


}
