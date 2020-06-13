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
using Windows.UI.Popups;

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    
    public sealed partial class Movimento : Page
    {
        private PersonagemJogavel jogador;
        private Mapa Mapa;
        private object objBlock = new Object();
        private bool MoveUp;
        private string Diretorio;
        private double PosicaoAux, VMatrizY = 0.08571, VMatrizX = 0.050;
        private bool MoveDown;
        private bool MoveLeft;
        private bool MoveRight;
        private List<Image> ListImageItem;
        private List<Image> ListImageBoss;
        private bool ImagemDown = false, ImagemUp = false, ImagemLeft = false, ImagemRight = false;
        private Timer MovementTimer = new Timer { Interval = 20 };
        
        //Construtor
        public Movimento()
        {
            InitializeComponent();
            MovementTimer.Elapsed += MovementTimer_Elapsed;
            Auxilio.Click += Btn_Auxilio;
            KeyDown += ImgPlayer_KeyDown;
            KeyUp += ImgPlayer_KeyUp;
        }

        //Inicia as threads na direção pressionada
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

        //Evento ao pressionar e soltar as teclas
        protected override void OnKeyUp(KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Z)
            {
                StatusVida.Maximum = jogador.MaxLife;
                StatusVida.Value = jogador.Life;
                StatusEnergia.Maximum = jogador.MaxEnergia;
                StatusEnergia.Value = jogador.Energia;

                StatusAnimo.Text = "Ânimo: " + jogador.Animo;
                StatusPersistencia.Text = "Persistência: " + jogador.Persistencia;
                StatusConhecimento.Text = "Conhecimento: " + jogador.Conhecimento + "   Nivel: " + jogador.Nivel;
                StatusNome.Text = jogador.Nome;
                Status.IsOpen = true;
            }
            else if (e.Key == Windows.System.VirtualKey.C)
            {
                this.Frame.Navigate(typeof(MenuCraft), jogador);
            }
            else if (e.Key == Windows.System.VirtualKey.I)
            {
                CancelarMovimento();
                this.Frame.Navigate(typeof(ExibirInventario), jogador);
            }
            else if (e.Key == Windows.System.VirtualKey.S)
            {
                MoveDown = false;
            }
            else if (e.Key == Windows.System.VirtualKey.W)
            {
                MoveUp = false;
            }
            else if (e.Key == Windows.System.VirtualKey.D)
            {
                MoveRight = false;
            }
            else if (e.Key == Windows.System.VirtualKey.A)
            {
                MoveLeft = false;
            }

            if (!(MoveUp || MoveDown || MoveLeft || MoveRight))
            {
                MovementTimer.Stop();
            }
        }

        //Evento ao pressionar continuamente as teclas
        protected override void OnKeyDown(KeyRoutedEventArgs e)
        {
            Status.IsOpen = false;
            if (e.Key == Windows.System.VirtualKey.S)
            {
                MoveDown = true;
            }
            else if (e.Key == Windows.System.VirtualKey.W)
            {
                MoveUp = true;
            }

            else if (e.Key == Windows.System.VirtualKey.D)
            {
                MoveRight = true;
            }
            else if (e.Key == Windows.System.VirtualKey.A)
            {
                MoveLeft = true;
            }

            lock (objBlock)
            {
                DoMovement();
            }

            MovementTimer.Start();
        }

        //Inicia a thread do movimento UP
        private async void Up()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, UpPlayer);
        }

        //Ações e eventos do movimento UP
        private void UpPlayer()
        {
            //Encontra uma posição null que ele pode mover
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX, jogador.PosicaoY - VMatrizY))
            {
                PosicaoMovimentoValida(1);
            }
            //Ponto de deslocamento de area (tamanho padrão: 12x9)
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento != null)
            {
                PontoDeslocamentoArea(1);
            }
            //Quando ele encotra um item na matriz
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Item != null)
            {
                ColetaItemMapa((int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX));
            }
            //Se ele encontrar um monstro numa posição do mapa
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Monstro != null)
            {
                IniciarCombate((int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX));
            }
            //Exibição da posição do personagem na tela de movimento
            ExibirPosicaoJogador();
        }

        //Inicia a thread do movimento DOWN
        private async void Down()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, DownPlayer);
        }

        //Ações e eventos no movimento DOWN
        private void DownPlayer()
        {
            //Encontra uma posição null que ele pode mover
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX, jogador.PosicaoY + VMatrizY))
            {
                PosicaoMovimentoValida(2);
            }
            //Ponto de deslocamento de area (tamanho padrão: 12x9)
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento != null)
            {
                PontoDeslocamentoArea(2);
            }
            //Quando ele encotra um item na matriz
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Item != null)
            {
                ColetaItemMapa((int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX));
            }
            //Se ele encontrar um monstro numa posição do mapa
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Monstro != null)
            {
                IniciarCombate((int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX));
            }
            //Exibição da posição do personagem na tela de movimento
            ExibirPosicaoJogador();
        }

        //Inicia a thread do movimento LEFT
        private async void Left()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, LeftPlayer);
        }

        //Ações e eventos do movimento LEFT
        private void LeftPlayer()
        {
            //Encontra uma posição null que ele pode mover
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX - VMatrizX, jogador.PosicaoY))
            {
                PosicaoMovimentoValida(4);
            }
            //Ponto de deslocamento de area (tamanho padrão: 12x9)
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento != null)
            {
                PontoDeslocamentoArea(4);
            }
            //Quando ele encotra um item na matriz
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Item != null)
            {
                ColetaItemMapa((int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX));
            }
            //Se ele encontrar um monstro numa posição do mapa
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Monstro != null)
            {
                IniciarCombate((int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX));
            }
            //Exibição da posição do personagem na tela de movimento
            ExibirPosicaoJogador();
        }

        //Inicia a thread do movimento RIGHT
        private async void Right()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, RightPlayer);
        }

        //Ações e eventos do movimento RIGHT
        private void RightPlayer()
        {
            //Encontra uma posição null que ele pode mover
            if (jogador.PodeMover(Mapa.MapaJogo, jogador.PosicaoX + VMatrizX, jogador.PosicaoY))
            {
                PosicaoMovimentoValida(3);
            }
            //Ponto de deslocamento de area (tamanho padrão: 12x9)
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento != null)
            {
                PontoDeslocamentoArea(3);
            }
            //Quando ele encotra um item na matriz
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Item != null)
            {
                ColetaItemMapa((int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX));
            }
            //Se ele encontrar um monstro numa posição do mapa
            else if (Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Monstro != null)
            {
                IniciarCombate((int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX));
            }
            //Exibição da posição do personagem na tela de movimento
            ExibirPosicaoJogador();
        }

        //Inicia com imagem padrão o player
        private void ImgPlayer_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.W && ImagemUp) ImagemUp = false;
            else if (e.Key == Windows.System.VirtualKey.S && ImagemDown) ImagemDown = false;
            else if (e.Key == Windows.System.VirtualKey.D && ImagemRight) ImagemRight = false;
            else if (e.Key == Windows.System.VirtualKey.A && ImagemLeft) ImagemLeft = false;
        }

        //Muda a imagem do player de acordo com a direção passada
        private void ImgPlayer_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.S)
            {
                if (!ImagemDown)
                {
                    ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Diretorio + "/Down.gif"));
                    ImagemDown = true;
                }
            }
            else if (e.Key == Windows.System.VirtualKey.W)
            {
                if (!ImagemUp)
                {
                    ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Diretorio + "/Up.gif"));
                    ImagemUp = true;
                }
            }
            else if (e.Key == Windows.System.VirtualKey.D)
            {
                if (!ImagemRight)
                {
                    ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Diretorio + "/Right.gif"));
                    ImagemRight = true;
                }
            }
            else if (e.Key == Windows.System.VirtualKey.A)
            {
                if (!ImagemLeft)
                {
                    ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Diretorio + "/Left.gif"));
                    ImagemLeft = true;
                }
            }
        }


        //Impede o movimento quando ocorrer exibição de mensagem ou combate com inimigos
        private void CancelarMovimento()
        {
            MoveUp = false;
            MoveDown = false;
            MoveLeft = false;
            MoveRight = false;
        }

        //Exibe a posição na matriz referente ao jogodor
        private void ExibirPosicaoJogador()
        {
            PosicaoMatrizX.Text = Math.Floor(jogador.PosicaoX).ToString();
            PosicaoMatrizY.Text = Math.Floor(jogador.PosicaoY).ToString();
        }

        //Calcula a posição da imagem do personagem a ser exibida na tela
        private void AtualizarImagem()
        {
            //1200x630 - 100px 70px
            Canvas.SetLeft(ImgPlayer, 100 * (jogador.PosicaoX - Math.Floor(jogador.PosicaoX / 12) * 12) + 1);
            Canvas.SetTop(ImgPlayer, 70 * jogador.PosicaoY + 1);
        }

        //Atualiza o personagem em uma posição na tela e na posição Y
        private void PosicaoMovimentoValida(int chamada)
        {
            //| CHAMADA |     
            //|1 - UP   |
            //|2 - DOWN |
            //|3 - RIGTH|
            //|4 - LEFT |

            if (chamada > 4 || chamada < 1) return;

            switch (chamada)
            {
                case 1://up
                    Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) - 6);//muda a imagem do personagem
                    jogador.PosicaoY = Math.Round(jogador.PosicaoY - VMatrizY, 4);//muda o y da matriz da posição do jogador
                    break;

                case 2://down
                    Canvas.SetTop(ImgPlayer, Canvas.GetTop(ImgPlayer) + 6);//muda a imagem do personagem
                    jogador.PosicaoY = Math.Round(jogador.PosicaoY + VMatrizY, 4);//muda o y da matriz da posição do jogador
                    break;

                case 3://right
                    Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) + 5);//muda a imagem do personagem
                    jogador.PosicaoX = Math.Round(jogador.PosicaoX + VMatrizX, 4);//muda o X da matriz da posição do jogador
                    break;

                case 4://left
                    Canvas.SetLeft(ImgPlayer, Canvas.GetLeft(ImgPlayer) - 5);//muda a imagem do personagem
                    jogador.PosicaoX = Math.Round(jogador.PosicaoX - VMatrizX, 4);//muda o X da matriz da posição do jogador
                    break;
            }

        }

        //Transição de area do mapa
        private void PontoDeslocamentoArea(int chamada)
        {
            //| CHAMADA |     
            //|1 - UP   |
            //|2 - DOWN |
            //|3 - RIGTH|
            //|4 - LEFT |

            if (chamada > 4 || chamada < 1) return;
            Debug.WriteLine(Canvas.GetTop(ImgPlayer));
            Debug.WriteLine(Canvas.GetLeft(ImgPlayer));

            switch (chamada)
            {
                case 1://up
                    //Muda o background do mapa quando muda a região 
                    background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[2] + "Mapa.png"));

                    //Auxiliar para armazenar o novo valor da posição "X" ou "Y" 
                    PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[0];

                    //Altera a posição do jogador na matriz
                    jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY - VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[1];
                    break;

                case 2://down
                    //Muda o background do mapa quando muda a região 
                    background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[2] + "Mapa.png"));

                    //Auxiliar para armazenar o novo valor da posição "X" ou "Y" 
                    PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[0];

                    //Altera a posição do jogador na matriz
                    jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY + VMatrizY), (int)Math.Floor(jogador.PosicaoX)].Deslocamento[1];
                    break;

                case 3://right
                    //Muda o background do mapa quando muda a região 
                    background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento[2] + "Mapa.png"));

                    //Auxiliar para armazenar o novo valor da posição "X" ou "Y" 
                    PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento[0];

                    //Altera a posição do jogador na matriz
                    jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX + VMatrizX)].Deslocamento[1];
                    break;

                case 4://left
                       //Muda o background do mapa quando muda a região 
                    background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento[2] + "Mapa.png"));

                    //Auxiliar para armazenar o novo valor da posição "X" ou "Y" 
                    PosicaoAux = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento[0];

                    //Altera a posição do jogador na matriz
                    jogador.PosicaoX = Mapa.MapaJogo[(int)Math.Floor(jogador.PosicaoY), (int)Math.Floor(jogador.PosicaoX - VMatrizX)].Deslocamento[1];
                    break;
            }

            //Altera a posição Y do jogador na matriz
            jogador.PosicaoY = PosicaoAux;
            ExibirItemTela();
            ExibirChefeTela();
            //Atualiza a imagem do personagem de acordo com a direção que ele vai
            AtualizarImagem();
        }

        private void ExibirItemTela() 
        {
            int cont = (int)(jogador.PosicaoX - (jogador.PosicaoX - Math.Floor(jogador.PosicaoX / 12) * 12));

            foreach (var image in ListImageItem)
            {
                image.Source = null;
            }

            ListImageItem.Clear();

            for(int i = 0; i < 9; i++) 
            {
                for(int j = cont; j < cont + 12; j++) 
                {
                    if(Mapa.MapaJogo[i, j] != null && Mapa.MapaJogo[i, j].Item != null) 
                    {
                        Image ItemImage = new Image();
                        ItemImage.Name = (i*j).ToString();
                        ItemImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/objeto.png"));
                        ItemImage.Width = 100;
                        ItemImage.Height = 70;
                        canvas.Children.Add(ItemImage);
                        ListImageItem.Add(ItemImage);

                        Canvas.SetLeft(ItemImage, 109 * (j - (j/12) * 12) + 1);
                        Canvas.SetTop(ItemImage, 78 * i + 1);
                    }
                }
            }
        }
        private void ExibirChefeTela() 
        {
            int cont = (int)(jogador.PosicaoX - (jogador.PosicaoX - Math.Floor(jogador.PosicaoX / 12) * 12));
            string diretorio = "";
            bool permissaoImagem = false;
            int width = 100, height = 70;

            foreach (var image in ListImageBoss)
            {
                image.Source = null;
            }

            ListImageBoss.Clear();

            for (int i = 0; i < 9; i++)
            {
                for (int j = cont; j < cont + 12; j++)
                {
                    if (Mapa.MapaJogo[i, j] != null && Mapa.MapaJogo[i, j].Monstro != null)
                    {
                        switch (Mapa.MapaJogo[i, j].Monstro.Nome) 
                        {
                            case "Anaculo":
                                diretorio = "Anaculo";
                                width = 87;
                                height = 222;
                                permissaoImagem = true;
                                break;
                            case "Toest":
                                diretorio = "Toest";
                                permissaoImagem = true;
                                break;
                            case "ATOM":
                                diretorio = "Atom";
                                permissaoImagem = true;
                                break;
                            case "Lapain":
                                diretorio = "Lapain";
                                permissaoImagem = true;
                                break;
                        }
                        if (permissaoImagem) 
                        {
                            Image BossImage = new Image();
                            BossImage.Name = (i * j).ToString();
                            BossImage.Source = new BitmapImage(new Uri("ms-appx:///Assets/monstros/GridSprites/Grid" + diretorio + ".png"));
                            BossImage.Width = width;
                            BossImage.Height = height;
                            canvas.Children.Add(BossImage);
                            ListImageBoss.Add(BossImage);


                            Canvas.SetLeft(BossImage, 109 * (j - (j / 12) * 12) + BossImage.ActualWidth/2);
                            Canvas.SetTop(BossImage, 78 * i - BossImage.ActualHeight/2);
                            permissaoImagem = false;
                        }
                    }
                }
            }
        }

        //Coleta de item no mapa
        private void ColetaItemMapa(int x, int y)
        {
            //Coleta o item do mapa
            if(jogador.inventario.Itens.Count < 18) 
            {
                jogador.ColetarItem(Mapa.MapaJogo[x, y].Item);
                foreach (var image in ListImageItem)
                {
                    if (image.Name == (x * y).ToString())
                    {
                        image.Source = null;
                    }
                }

                //Impede o movimento do personagem enquando a mensagem estiver ativa 
                CancelarMovimento();
                Mensagem("Item: " + Mapa.MapaJogo[x, y].Item.Nome, "Novo Item adquirido");

                //Retira o item do mapa
                Mapa.MapaJogo[x, y] = null;
            }
            else 
            {
                CancelarMovimento();
                Mensagem("Querido usuário, sua mochila está cheia. Coma alguma coisa e pense bem no que tu fez.", "INVENTÁRIO CHEIO");
            }

        }

        //Transição para tela de combate
        private void IniciarCombate(int x, int y)
        {
            //Cria uma lista que contem o jogador e o monstro
            var ListaParametros = new List<Personagem>() {
                    jogador,
                    Mapa.MapaJogo[x, y].Monstro
                };

            //Elimina o monstro no mapa
            Mapa.MapaJogo[x, y] = null;

            //Cancela os movimento enquanto esta vai para a tela de combate
            CancelarMovimento();
            Frame.Navigate(typeof(Combate), ListaParametros);
        }


        //Exibição de mensagens de aviso
        private async void Mensagem(string Mensagem, string Titulo)
        {
            var dialog = new MessageDialog(Mensagem, Titulo);
            var result = await dialog.ShowAsync();
        }

        private void Btn_Auxilio(object sender, RoutedEventArgs e) 
        {
            //Debug.WriteLine("POSIÇÃO X:  " + Canvas.GetLeft(ImgPlayer));
            //Debug.WriteLine("POSIÇÃO Y:  " + Canvas.GetTop(ImgPlayer));
            //Debug.WriteLine("POSIÇÃO X:  " + jogador.PosicaoX);
            //Debug.WriteLine("POSIÇÃO Y:  " + jogador.PosicaoY
        }

        //Evita o delay da execução dos eventos de movimento
        private void MovementTimer_Elapsed(object sender, EventArgs e)
        {
            DoMovement();
        }


        //Recebe os parametros (player) vindo de outra tela
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
                Diretorio = "Worker";
            }
            else if (jogador.GetType() == typeof(Expert))
            {
                jogador = (Expert)jogador;
                Diretorio = "Expert";
            }
            else 
            {
                jogador = (Cheater)jogador;
                Diretorio = "Cheater";
            }

            background.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + (Math.Floor(jogador.PosicaoX / 12) + 1) + "Mapa.png"));
            PlayerFace.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Diretorio + "/Face.png"));
            ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + Diretorio + "/Down.gif"));
            ListImageItem = new List<Image>();
            ListImageBoss = new List<Image>();
            ExibirItemTela();
            ExibirChefeTela();

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
