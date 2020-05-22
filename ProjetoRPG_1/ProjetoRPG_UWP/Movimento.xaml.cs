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
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml.Media.Imaging;
using System.Drawing;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x416

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    
    public sealed partial class Movimento : Page
    {
        //private Worker jogador = new Worker();
        private PersonagemJogavel jogador;
        private Mapa Mapa;
        private object objBlock = new Object();
        private bool MoveUp;
        private double PosicaoAux, VMatrizY = 0.08571, VMatrizX = 0.050;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;
        private Timer MovementTimer = new Timer { Interval = 20 };
        

        public Movimento()
        {
            InitializeComponent();
            MovementTimer.Elapsed += MovementTimer_Elapsed;
            Auxilio.Click += Btn_Auxilio;
        }

        private void Btn_Auxilio(object sender, RoutedEventArgs e) 
        {
            Debug.WriteLine("POSIÇÃO X:  " + Canvas.GetLeft(ImgPlayer));
            Debug.WriteLine("POSIÇÃO Y:  " + Canvas.GetTop(ImgPlayer));
            Debug.WriteLine("POSIÇÃO X:  " + jogador.PosicaoX);
            Debug.WriteLine("POSIÇÃO Y:  " + jogador.PosicaoY);

        }

        private void MovementTimer_Elapsed(object sender, EventArgs e)
        {
            DoMovement();
        }

        private void DoMovement()
        {
            if (MoveLeft)
            {
                Left();
            }
            if (MoveRight)
            {
                Right();
            }
            if (MoveUp)
            {
                Up();
            }
            if (MoveDown)
            {
                Down();
            }
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

        private void CancelarMovimento()
        {
            MoveUp = false;
            MoveDown = false;
            MoveLeft = false;
            MoveRight = false;
        }

        private void UpPlayer() 
        {
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX, jogador.PosicaoY - VMatrizY))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) - 6);
                jogador.PosicaoY = Math.Round(jogador.PosicaoY - VMatrizY, 4);
            }
            else if(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento != null)
            {
                Debug.WriteLine(Canvas.GetTop(ImgPlayer));
                Debug.WriteLine(Canvas.GetLeft(ImgPlayer));
                background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[2]+".png"));
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem();
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                    jogador,
                    Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)] = null;
                CancelarMovimento();
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }
        private void DownPlayer()
        {
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX, jogador.PosicaoY + VMatrizY))
            {
                Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) + 6);
                jogador.PosicaoY  = Math.Round(jogador.PosicaoY + VMatrizY, 4);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento != null)
            {
                Debug.WriteLine(Canvas.GetTop(ImgPlayer));
                Debug.WriteLine(Canvas.GetLeft(ImgPlayer));
                background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[2] + ".png"));
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem();
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                    jogador,
                    Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)] = null;
                CancelarMovimento();
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }
        private void RightPlayer()
        {
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX + VMatrizX, jogador.PosicaoY))
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) + 5);
                jogador.PosicaoX = Math.Round(jogador.PosicaoX + VMatrizX, 4);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento != null)
            {
                background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento[2] + ".png"));
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem();
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                jogador,
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)] = null;
                CancelarMovimento();
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }
        private void LeftPlayer()
        {
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX - VMatrizX, jogador.PosicaoY)) 
            {
                Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) - 5);
                jogador.PosicaoX = Math.Round(jogador.PosicaoX - VMatrizX, 4);
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento != null)
            {
                background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento[2] + ".png"));
                PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento[0];
                jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento[1];
                jogador.PosicaoY = PosicaoAux;
                AtualizarImagem();
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].I != null)
            {
                jogador.ColetarItem(Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].I);
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)] = null;
            }
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].M != null)
            {
                var ListaParametros = new List<Personagem>() {
                jogador,
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].M
                };
                Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)] = null;
                CancelarMovimento();
                Frame.Navigate(typeof(Combate), ListaParametros);
            }
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }

        private void AtualizarImagem() 
        {
            //1200x630 - 100px 70px
            Canvas.SetLeft(ImgPlayer, 100 * (jogador.PosicaoX - Math.Floor(jogador.PosicaoX/12) * 12) + 1);
            /*Essa função ta errada(?)*/
            Canvas.SetTop(ImgPlayer, 70 * jogador.PosicaoY + 1);
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
            
            AtualizarImagem();
            /*AREA DE TESTE*/
            Debug.WriteLine("TAMANHO PAGINA: " + Window.Current.Bounds.Height);
            Debug.WriteLine("ITENS ECONTRADOS: " + jogador.inventario.Itens.Count) ;
            Debug.WriteLine("LIFE: " + jogador.Life);
            Debug.WriteLine("ENERGIA: " + jogador.Energia);
            Debug.WriteLine("CONHECIMENTO: " + jogador.Conhecimento);
            Debug.WriteLine("NIVEL: " + jogador.Nivel);
            /*===========*/
        }
    }


}
