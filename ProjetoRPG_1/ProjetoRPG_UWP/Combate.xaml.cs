using ProjetoRPG;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace ProjetoRPG_UWP
{

    /// <summary>
    /// Um monstro e um personagem jogavel entram em combate até a morte
    /// </summary>
    public sealed partial class Combate : Page
    {
        private PersonagemJogavel jogador;
        private Monstro monstro;
        private int contPersistencia, contAnimo;
        private MediaPlayer musicBattle;
        private bool defesaMonstro;

        /// <summary>
        /// Metodo construtor para assinar os eventos da tela do XAML
        /// </summary>
        public Combate()
        {
            this.InitializeComponent();

            defesaMonstro = false;
            contPersistencia = 0;
            contAnimo = 0;

            Ataque.Click += Btn_Ataque;
            Inventario.Click += Btn_Inventario;
            Defesa.Click += Btn_Defesa;
            Lancar_Habilidade.Click += Btn_Habilidade;

            ListaH.SelectionChanged += ComboBoxs_SelectionChanged_Habilidade;
            ListaI.SelectionChanged += ComboBoxs_SelectionChanged_Inventario;
            
        }

        /// <summary>
        /// Tocar musica durante a batalha
        /// </summary>
        private void InicarMusicaBatalha()
        {
            //Musica de inimigos normis
            string music = "themeBattle.mp3";

            //musica do boss final
            if (monstro.GetType() == typeof(Anaculo))
            {
                music = "themeFinalBoss.mp3";
            }
            //Musica dos outros bosses
            else if (monstro.GetType() == typeof(Atom) || monstro.GetType() == typeof(Lapain) || monstro.GetType() == typeof(Toest))
            {
                music = "themeBoss.mp3";
            }

            try
            {
                Uri pathUri = new Uri("ms-appx:///Assets/Musicas/" + music);
                musicBattle = new MediaPlayer();
                musicBattle.Source = MediaSource.CreateFromUri(pathUri);
                musicBattle.Play();
                Debug.Write("Som foi execultado");
            }
            catch (Exception ex)
            {
                if (ex is FormatException)
                {
                    Debug.Write("erro ao execultar som");
                }
            }
        }

        /// <summary>
        /// Metodo de utilização da habilidade mais basica do personagem
        /// </summary>
        private void Btn_Ataque(object sender, RoutedEventArgs e)
        {
            int dano = jogador.Atacar(monstro, null, jogador.Habilidades.ElementAt<Habilidade>(0));
            _ = ExibeDanoCombateAsync(dano, 1);

            //mostro ataca
            InteligenciaMonstro();

            AtualizarTexto();
            //verifica quem morreu
            checkLife();
        }

        /// <summary>
        /// Metodo para aumentar a persistencia (defesa) do personagem para 
        /// </summary> 
        private void Btn_Defesa(object sender, RoutedEventArgs e)
        {
            //Aumenta a defesa do jogador
            jogador.Persistencia += 5;

            //Monstro ataca jogador 
            InteligenciaMonstro();

            AtualizarTexto();

            checkLife();
            //tirar a defesa do jogador
            jogador.Persistencia -= 5;
        }

        /// <summary>
        /// Metodo para utilizar um item selecionado no combobox
        /// </summary>
        private void Btn_Inventario(object sender, RoutedEventArgs e)
        {
            if (ListaI.SelectedValue != null)
            {
                Item item = ListaI.SelectedItem as ItemSecundario;
                //Aplicar boost no personagem
                jogador.UsarItem(item);

                if (item.Dano > 0)
                {
                    //Atacar o monstro
                    int dano = jogador.Atacar(monstro, item, null);


                    //exibir marcador de dano do monstro
                    _ = ExibeDanoCombateAsync(dano, 1);


                    //monstro ataca
                    InteligenciaMonstro();
                }

                //Atualizar os textos da tela
                AtualizarTexto();

                //Remove item do combobox
                _ = ListaI.Items.Remove(item);
                ToolTipService.SetToolTip(ListaI, null);

                //Checa se alguem morreu
                checkLife();
            }
        }

        /// <summary>
        /// Metodo para utilizar uma habilidade selecionada no combobox do jogador
        /// </summary>
        private void Btn_Habilidade(object sender, RoutedEventArgs e)
        {
            if (ListaH.SelectedValue != null)
            {
                Habilidade hbl = ListaH.SelectedItem as Habilidade;
                //verificar se o usuario tem a energia para usar a habilidade
                if (jogador.UsarHabilidade(hbl))
                {
                    //armazena os buffes para tirar no fim da rodada
                    contAnimo += hbl.BuffAnimo;
                    contPersistencia += hbl.BuffPersistencia;

                    if (hbl.Dano > 0)
                    {
                        //ataque do jogador
                        int dano = jogador.Atacar(monstro, null, hbl);

                        //exibir marcador de dano do monstro
                        _ = ExibeDanoCombateAsync(dano, 1);
                    }

                    //habilidade de passar a vez
                    if (!hbl.DesativaHabilidade)
                    {
                        InteligenciaMonstro();
                    }
                }
                else
                {
                    Mensagem("Você não possui energia o suficiente para usar a habilidade", "Aviso");
                }
                AtualizarTexto();
                checkLife();
            }
        }

        /// <summary>
        /// Preenche a combobox de habilidades do jogador
        /// </summary>
        private void PreencherCBHabilidades()
        {
            int i = 0;
            //Preenche na combobox as habilidades do jogador
            jogador.Habilidades.ForEach(delegate (Habilidade habilidade) {
                if (i != 0)
                {
                    ListaH.Items.Add(habilidade);
                }
                i++;
            });
        }

        /// <summary>
        /// Preenche a combobox de itens do jogador
        /// </summary>
        private void PreencherCBItens()
        {
            //Preenche na combobox os itens do jogador
            jogador.inventario.GetItemSecundarios().ForEach(delegate (ItemSecundario itemSecundario)
            {
                if (jogador.Nivel >= itemSecundario.NivelRequerido)
                {
                    ListaI.Items.Add(itemSecundario);
                }
            });
        }

        private void ExibeDescricaoMonstro()
        {
            ToolTip toolTip = new ToolTip();
            toolTip.Content = monstro.Nome + "\n\n" + monstro.Descricao;
            ToolTipService.SetToolTip(ImgMonstro, toolTip);
        }
        
        /// <summary>
        /// Metodo de exibição de descrição de habilidades
        /// </summary>
        private void ComboBoxs_SelectionChanged_Habilidade(object sender, SelectionChangedEventArgs e)
        {
            string descricao;

            if (ListaH.SelectedItem != null)
            {
                ToolTip toolTip = new ToolTip(); 
                
                Habilidade hbl = ListaH.SelectedItem as Habilidade;
                descricao = "Dano: -" + hbl.Dano + "\n" +
                            "Gato energia: -" + hbl.GastoEnergia + "\n" +
                            "Descrição: " + hbl.Descricao + "\n" +
                            "Buffer Life: +" + hbl.BuffLife + "\n" +
                            "Buffer Animo: +" + hbl.BuffAnimo + "\n" +
                            "Buffer Persistência: " + hbl.BuffPersistencia;
                toolTip.Content = descricao;
                ToolTipService.SetToolTip(ListaH, toolTip);
              //DescricaoHabilidade.Text = descricao;
            }
        }

        /// <summary>
        /// Metodo de exibição de descrição dos itens
        /// </summary>
        private void ComboBoxs_SelectionChanged_Inventario(object sender, SelectionChangedEventArgs e)
        {
            string descricao;

            if (ListaI.SelectedItem != null)
            {
                ToolTip toolTip = new ToolTip();

                Item item = ListaI.SelectedItem as Item;
                descricao = "Dano: -" + item.Dano + "\n" +
                            "Buffer energia: -" + item.BuffEnergia + "\n" +
                            "Descrição: " + item.Descricao + "\n" +
                            "Buffer Life: +" + item.BuffLife + "\n" +
                            "Buffer Animo: +" + item.BuffAnimo + "\n" +
                            "Buffer Persistência: " + item.BuffPersistencia;
                toolTip.Content = descricao;
                ToolTipService.SetToolTip(ListaI, toolTip);
                //DescricaoHabilidade.Text = descricao;
            }
        }

        /// <summary>
        /// Verifica se algum personagem morreu (jogador ou monstro)
        /// </summary>
        private void checkLife()
        {
            //monstro morto jogador vivo
            if (monstro.Life <= 0 && jogador.Life > 0)
            {
                if (monstro.ItemDrop != null)
                {
                    jogador.ColetarItem(monstro.ItemDrop);
                }
                jogador.Conhecimento += monstro.ConhecimentoDrop;
                jogador.Animo -= contAnimo;
                jogador.Persistencia -= contPersistencia;
                jogador.LevelUp();
                musicBattle.Pause();
                musicBattle = null;
                Frame.GoBack();
            }
            //jogador morto monstro vivo
            else if (jogador.Life <= 0)
            {
                musicBattle.Pause();
                musicBattle = null;
                this.Frame.Navigate(typeof(GameOver), monstro);
                //criar tela ou mensagem de personagem morto (game over)
            }
        }

        /// <summary>
        /// Metodo para descrever a inteligencia do personagem
        /// </summary>
        private void InteligenciaMonstro()
        {
            //Retira a persistencia quando o mosntro se defendeu
            if (defesaMonstro)
            {
                Debug.WriteLine("Desativação da defesa ");
                defesaMonstro = false;
                this.monstro.Persistencia -= 12;
            }

            //Ramdow das ações
            Random random = new Random();

            //Ação de atacar ou defender
            int acao = random.Next(3);// 0 1 2

            //Quantidade de habilidades do monstro
            int qtdHabilidade = this.monstro.Habilidades.Count();

            //Numero da habilidade ramdomizada
            int numhabilidade;

            //O monstro está na vantagem da batalha por isso age com pouca cautela na defesa
            if (this.monstro.Life >= jogador.Life)
            {
                //Ataca
                if (acao <= 1)
                {
                    //Qual habilidade ele vai usar
                    numhabilidade = random.Next(qtdHabilidade);

                    //Se ele não tiver energia pra usar ele escolhe outra habilidade
                    while (monstro.Habilidades[numhabilidade].GastoEnergia > this.monstro.Energia)
                    {
                        numhabilidade = random.Next(qtdHabilidade);
                    }

                    //Teste
                    Debug.WriteLine("Quantidade de habilidades: " + qtdHabilidade);
                    Debug.WriteLine("Numero para habilidade sorteado: " + numhabilidade);
                    Debug.WriteLine("Habilidade usada: " + monstro.Habilidades[numhabilidade].Nome);

                    //Usar a habilidade
                    monstro.UsarHabilidade(monstro.Habilidades[numhabilidade]);
                    int dano = monstro.Atacar(jogador, null, monstro.Habilidades[numhabilidade]);
                    _ = ExibirAcaoCombatentesAsync(monstro.Habilidades[numhabilidade].Nome);
                    _ = Task.Delay(900);
                    _ = ExibeDanoCombateAsync(dano, 2);
                }
                //Defende
                else
                {
                    _ = ExibirAcaoCombatentesAsync("Escudo");

                    Debug.WriteLine("ESCUDOS UTILIZADOS");
                    this.monstro.Persistencia += 12;
                    defesaMonstro = true;
                }
            }
            //O monstro esta deixou de ter vantagem na batalha por isso demonstra caltela
            else
            {
                //Se o monstro tiver mais da metada do seu life, ele vai usar seus arcenais mais poderosos e focar na defesa
                if (this.monstro.Life > this.monstro.MaxLife / 2)
                {
                    //Ataca com a melhor habilidade  
                    if (acao == 1)
                    {
                        //Pega a habilidade de maior dano do personagem
                        int habityPower = 0;

                        //Habilidade inicial
                        Habilidade maiorHabilidade = monstro.Habilidades[0];

                        //Procura a maior habilidade de dano que ele possa usar com sua energia disponivel
                        foreach (var habilidade in this.monstro.Habilidades)
                        {
                            if (habilidade.Dano > habityPower && habilidade.GastoEnergia < this.monstro.Energia)
                            {
                                maiorHabilidade = habilidade;
                            }
                        }

                        Debug.WriteLine("Quantidade de habilidades: " + qtdHabilidade);
                        Debug.WriteLine("Habilidade (MELHOR): " + maiorHabilidade);

                        //Ataca com a habilidade
                        monstro.UsarHabilidade(maiorHabilidade);
                        int dano = monstro.Atacar(jogador, null, maiorHabilidade);
                        _ = ExibirAcaoCombatentesAsync(maiorHabilidade.Nome);
                        _ = ExibeDanoCombateAsync(dano, 2);
                    }
                    //Defende
                    else
                    {
                        Debug.WriteLine("ESCUDOS UTILIZADOS");
                        this.monstro.Persistencia += 12;
                        defesaMonstro = true;
                        _ = ExibirAcaoCombatentesAsync("Escudo");
                    }
                }
                //Se ele tiver seu life abaixo da metade ele tende a atacar mais utilizando a seu melhor habilidade e outras habilidades
                else
                {
                    //Ataca normalmente
                    if (acao == 0)
                    {
                        //Qual habilidade ele vai usar
                        numhabilidade = random.Next(qtdHabilidade);

                        //Se ele não tiver energia pra usar ele escolhe outra habilidade
                        while (monstro.Habilidades[numhabilidade].GastoEnergia > this.monstro.Energia)
                        {
                            numhabilidade = random.Next(qtdHabilidade);
                        }

                        Debug.WriteLine("Quantidade de habilidades: " + qtdHabilidade);
                        Debug.WriteLine("Numero para habilidade sorteado: " + numhabilidade);
                        Debug.WriteLine("Habilidade usada: " + monstro.Habilidades[numhabilidade].Nome);


                        //Usar a habilidade
                        _ = monstro.UsarHabilidade(monstro.Habilidades[numhabilidade]);
                        int dano = monstro.Atacar(jogador, null, monstro.Habilidades[numhabilidade]);
                        _ = ExibirAcaoCombatentesAsync(monstro.Habilidades[numhabilidade].Nome);
                        _ = ExibeDanoCombateAsync(dano, 2);
                    }
                    //ataca com melhor habilidade
                    else if (acao == 1)
                    {
                        //Pega a habilidade de maior dano do personagem
                        int habityPower = 0;

                        //Habilidade inicial
                        Habilidade maiorHabilidade = monstro.Habilidades[0];

                        //Procura a maior habilidade de dano que ele possa usar com sua energia disponivel
                        foreach (var habilidade in this.monstro.Habilidades)
                        {
                            if (habilidade.Dano > habityPower && habilidade.GastoEnergia < this.monstro.Energia)
                            {
                                maiorHabilidade = habilidade;
                            }
                        }

                        Debug.WriteLine("Quantidade de habilidades: " + qtdHabilidade);
                        Debug.WriteLine("Habilidade (MELHOR): " + maiorHabilidade);

                        //Ataca com a habilidade
                        _ = monstro.UsarHabilidade(maiorHabilidade);
                        int dano = monstro.Atacar(jogador, null, maiorHabilidade);
                        _ = ExibirAcaoCombatentesAsync(maiorHabilidade.Nome);
                        _ = ExibeDanoCombateAsync(dano, 2);
                    }
                    //Defende
                    else
                    {
                        Debug.WriteLine("ESCUDOS UTILIZADOS");
                        this.monstro.Persistencia += 12;
                        defesaMonstro = true;
                        _ = ExibirAcaoCombatentesAsync("Escudos");
                    }
                }
            }
        }

        /// <summary>
        /// Define a imagem do jogador na tela de combate
        /// </summary>
        private void ImgJogadorCombate()
        {

            string diretorioJogador;
            string diretorioImgFaceJogador;

            //Definir a imagem do personagem jogavel
            if (jogador.GetType() == typeof(Worker))
            {
                diretorioJogador = "Worker/Battle.gif";
                diretorioImgFaceJogador = "Worker/Face.png"; 
            }
            else if (jogador.GetType() == typeof(Expert))
            {
                diretorioJogador = "Expert/Battle.gif";
                diretorioImgFaceJogador = "Expert/Face.png";
            }
            else
            {
                diretorioImgFaceJogador = "Cheater/Face.png";
                diretorioJogador = "Cheater/Battle.gif";
            }
            ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioJogador));
            ImgJogadorFace.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioImgFaceJogador));
        }

        /// <summary>
        /// Define a imagem do monstro na tela de combate
        /// </summary>
        private void ImgMonstroCombate()
        {
            string diretorioMonstro;
            string diretorioImgFaceMonstro;
            //TESTE
            
            //Definir a imagem do mosntro
            if (monstro.GetType() == typeof(Aculo))
            {
                diretorioMonstro = "monstros/aculo.png";
                diretorioImgFaceMonstro = "monstros/rostos/aculo_r.png";
            }
            else if (monstro.GetType() == typeof(Anaculo))
            {
                diretorioImgFaceMonstro = "monstros/rostos/anaculo_r.png";
                diretorioMonstro = "monstros/anaculo.png";
            }
            else if (monstro.GetType() == typeof(Atom))
            {
                diretorioImgFaceMonstro = "monstros/rostos/atom_r.png";
                diretorioMonstro = "monstros/atom.png";
            }
            else if (monstro.GetType() == typeof(Gasefic))
            {
                diretorioImgFaceMonstro = "monstros/rostos/gasefic_r.png";
                diretorioMonstro = "monstros/gasefic.png";
            }
            else if (monstro.GetType() == typeof(Lapain))
            {
                diretorioImgFaceMonstro = "monstros/rostos/lapin_r.png";
                diretorioMonstro = "monstros/lapain.png";
            }
            else if (monstro.GetType() == typeof(Minlapa))
            {
                diretorioImgFaceMonstro = "monstros/rostos/minlapa_r.png";
                diretorioMonstro = "monstros/minlapa.png";
            }
            else if (monstro.GetType() == typeof(Mintost))
            {
                diretorioImgFaceMonstro = "monstros/rostos/mintost_r.png";
                diretorioMonstro = "monstros/mintost.png";
            }
            else //Toest
            {
                diretorioImgFaceMonstro = "monstros/rostos/toest_r.png";
                diretorioMonstro = "monstros/toest.png";
            }
            ImgMonstro.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioMonstro));
            ImgMonstroFace.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioImgFaceMonstro));

        }

        /// <summary>
        /// Exibição na tela do dano infligido no monstro
        /// </summary>
        private async Task ExibeDanoCombateAsync(int dano, int personagem)
        {

            //exibir o numero em negativo
            if (dano > 0)
            {
                dano *= -1;
            }

            //dano no monstro
            if (personagem == 1)
            {
                await Task.Delay(200);

                //exibir gif do dano
                ImgDanoMonstro.Visibility = Visibility.Visible;
                
                //exibir marcação de dano que o monstro levou 
                DanoMonstro.Text = "" + dano;
                await Task.Delay(200);

                //apagar o gif e o dano monstro
                ImgDanoMonstro.Visibility = Visibility.Collapsed;
                DanoMonstro.Text = " ";
            }
            //dano no jogador
            else
            {
                await Task.Delay(600);

                //exibir gif do dano
                ImgDanoJogador.Visibility = Visibility.Visible;

                //exibir marcação de dano que o monstro levou
                DanoJogador.Text = "" + dano;
                await Task.Delay(200);

                //apagar o gif e o dano monstro
                DanoJogador.Text = " ";
                ImgDanoJogador.Visibility = Visibility.Collapsed;
            }
        }
        private async Task ExibirAcaoCombatentesAsync(string acaoUtilizada)
        {

            await Task.Delay(600);
            //ação utilizada pelo monstro 
            AcaoCombate.Text = monstro.Nome + " usou " + acaoUtilizada;
            await Task.Delay(700);
            AcaoCombate.Text = "";
        }

        /// <summary>
        /// Exibição de mensagens de aviso
        /// </summary>
        private async void Mensagem(string Mensagem, string Titulo)
        {
            var dialog = new MessageDialog(Mensagem, Titulo);
            var result = await dialog.ShowAsync();
        }

        /// <summary>
        /// Atualiza os texto de exibição da pagina
        /// </summary>
        private void AtualizarTexto()
        {
            TxtVidaJ.Text = jogador.Life + " / " + jogador.MaxLife;
            TxtEnergiaJ.Text = + jogador.Energia + " / " + jogador.MaxEnergia;
            TxtAnimoJ.Text = jogador.Animo.ToString();
            TxtDefesaJ.Text = jogador.Persistencia.ToString();
            TxtVidaM.Text = monstro.Life + " / " + monstro.MaxLife;
            TxtEnergiaM.Text = monstro.Energia + " / " + monstro.MaxEnergia;
            TxtAnimoM.Text = monstro.Animo.ToString();
            TxtDefesaM.Text = monstro.Persistencia.ToString();

            VidaP.Value = jogador.Life;
            EnergiaP.Value = jogador.Energia;
            VidaM.Value = monstro.Life;
            EnergiaM.Value = monstro.Energia;
            NomeJogador.Text = jogador.Nome;
            NomeMonstro.Text = monstro.Nome;
        }

        /// <summary>
        /// Metodo para transição de telas
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Captura os personagens vindos de outra tela (movimento) 
            var ListParametros = e.Parameter as List<Personagem>;
            jogador = ListParametros.ElementAt<Personagem>(0) as PersonagemJogavel;
            monstro = ListParametros.ElementAt<Personagem>(1) as Monstro;

            //Iniciar preenchimento das progress bars do jogador e monstro 
            EnergiaP.Maximum = jogador.MaxEnergia;
            VidaP.Maximum = jogador.MaxLife;
            EnergiaP.Value = jogador.MaxEnergia;
            VidaP.Value = jogador.Life;
            EnergiaM.Maximum = monstro.Energia;
            EnergiaM.Value = monstro.Energia;
            VidaM.Maximum = monstro.Life;
            VidaM.Value = monstro.Life;

            //Chamada de metodos
            InicarMusicaBatalha();
            ImgJogadorCombate();
            ImgMonstroCombate();
            PreencherCBHabilidades();
            PreencherCBItens();
            AtualizarTexto();
            ExibeDescricaoMonstro();

            //Define o background 
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = new BitmapImage(new Uri("ms-appx:///Assets/Combate/backgroundBattle.gif"));
            PaginaCombate.Background = ib;
        }
    }
}