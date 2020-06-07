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
            ListaH.SelectionChanged += ComboBoxs_SelectionChanged;
            ListaI.SelectionChanged += ComboBoxs_SelectionChanged;
            Lancar_Habilidade.Click += Btn_Habilidade;
            Inventario.Click += Btn_Inventario;
            Defesa.Click += Btn_Defesa;
        }

        /// <summary>
        /// Metodo de exibição de descrição de itens (Em construção)
        /// </summary>
        private void ComboBoxs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string descricao;
            
            if(ListaH.SelectedItem != null)
            {
                Habilidade hbl = ListaH.SelectedItem as Habilidade;
                descricao = "Dano: -" + hbl.Dano + "\n" +
                            "Gato energia: -" + hbl.GastoEnergia + "\n" +
                            "Descrição: " + hbl.Descricao + "\n" +
                            "Buffer Life: +" + hbl.BuffLife + "\n" +
                            "Buffer Animo: +" + hbl.BuffAnimo + "\n" +
                            "Buffer Persistência: " + hbl.BuffPersistencia;
                DescricaoHabilidade.Text = descricao;
            }

            if(ListaI.SelectedItem != null)
            {
                ItemSecundario item = ListaI.SelectedItem as ItemSecundario;
                descricao = "Dano: -" + item.Dano + "\n" +
                            "Descrição: " + item.Descricao + "\n" +
                            "Buffer Life: +" + item.BuffLife + "\n" +
                            "Buffer Animo: +" + item.BuffAnimo + "\n" +
                            "Buffer Persistência: " + item.BuffPersistencia;
                DescricaoItem.Text = descricao; 
            }
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
                    monstro.Life -= dano;

                    //exibir marcador de dano do monstro
                    _ = ExibeDanoCombateAsync(dano, 1);

                    //monstro ataca
                    InteligenciaMonstro();
                }


                //Atualizar os textos da tela
                AtualizarTexto();

                //Remove item do combobox
                _ = ListaI.Items.Remove(item);

                //Checa se alguem morreu
                checkLife();
            }
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
        /// Metodo para transição de telas
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            //Captura os personagens vindos de outra tela (movimento) 
            var ListParametros = e.Parameter as List<Personagem>;
            jogador = ListParametros.ElementAt<Personagem>(0) as PersonagemJogavel;
            monstro = ListParametros.ElementAt<Personagem>(1) as Monstro;

            /*AREA DE TESTE*/
            monstro.ConhecimentoDrop = 250;
            Item item = new ItemPrimario();
            item.Nome = "EAI MEN!!!";
            monstro.ItemDrop = item;
            jogador.LevelUp();
            /*-----------------*/

            ImgJogadorCombate();
            ImgMonstroCombate();
            PreencherCBHabilidades();
            PreencherCBItens();
            AtualizarTexto();
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
                ListaI.Items.Add(itemSecundario);
            });
        }


        /// <summary>
        /// Define a imagem do jogador na tela de combate
        /// </summary>
        private void ImgJogadorCombate()
        {

            string diretorioJogador;

            //Definir a imagem do personagem jogavel
            if (jogador.GetType() == typeof(Worker))
            {
                diretorioJogador = "Worker/None.png";
            }
            else if (jogador.GetType() == typeof(Expert))
            {
                diretorioJogador = "Expert/Fubica.png";
            }
            else
            {
                diretorioJogador = "Cheater/Nobody.png";
            }
            ImgPlayer.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioJogador));
        }

        /// <summary>
        /// Define a imagem do monstro na tela de combate
        /// </summary>
        private void ImgMonstroCombate()
        {
            string diretorioMonstro;

            //Definir a imagem do mosntro
            if (monstro.GetType() == typeof(Aculo))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstro.GetType() == typeof(Anaculo))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if(monstro.GetType() == typeof(Atom))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstro.GetType() == typeof(Gasefic))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstro.GetType() == typeof(Lapain))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstro.GetType() == typeof(Minlapa))
            {
                diretorioMonstro = "Aculo.png";
            }
            else if (monstro.GetType() == typeof(Mintost))
            {
                diretorioMonstro = "Aculo.png";
            }
            else //Toest
            {
                diretorioMonstro = "Aculo.png";
            }
            ImgMonstro.Source = new BitmapImage(new Uri("ms-appx:///Assets/" + diretorioMonstro));
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
                //exibir marcação de dano que o monstro levou
                DanoMonstro.Text = "" + dano;
                await Task.Delay(200);
                DanoMonstro.Text = " ";
            }
            //dano no jogador
            else
            {
                //exibir marcação de dano que o monstro levou
                DanoJogador.Text = "" + dano;
                await Task.Delay(200);
                DanoJogador.Text = " ";
            }
        }

        private async Task ExibirAcaoCombatentesAsync(int personagem, string acaoUtilizada)
        {

            //dano no monstro
            if (personagem >= 1)
            {
                //ação utilizada pelo monstro 
                AcaoCombate.Text = monstro.Nome + "usou " + acaoUtilizada;
                await Task.Delay(600);
                AcaoCombate.Text = "";
            }
            //dano no jogador
            else
            {
                //ação utilizada pelo jogador
                AcaoCombate.Text = jogador.Nome + "usou" + acaoUtilizada;
                await Task.Delay(600);
                AcaoCombate.Text = "";
            }
        }

        /// <summary>
        /// Metodo de utilização da habilidade mais basica do personagem
        /// </summary>
        private void Btn_Ataque(object sender, RoutedEventArgs e)
        {
            int dano = jogador.Atacar(monstro, null, jogador.Habilidades.ElementAt<Habilidade>(0));
            monstro.Life -= dano;
            _ = ExibeDanoCombateAsync(dano,1);

            //mostro ataca
            InteligenciaMonstro();

            AtualizarTexto();
            //verifica quem morreu
            checkLife();
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
                    _ = jogador.ColetarItem(monstro.ItemDrop);
                }
                jogador.Conhecimento += monstro.ConhecimentoDrop;
                jogador.Animo -= contAnimo;
                jogador.Persistencia -= contPersistencia;
                jogador.LevelUp();
                Frame.GoBack();
            }
            //jogador morto monstro vivo
            else if (jogador.Life <= 0)
            {
                //criar tela ou mensagem de personagem morto (game over)
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

                    if(hbl.Dano > 0)
                    {
                        //ataque do jogador
                        int dano = jogador.Atacar(monstro, null, hbl);
                        monstro.Life -= dano;

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
            Vida.Text = "Vida: " + jogador.Life.ToString();
            Energia.Text = "Energia: " + jogador.Energia;
            VidaM.Text = "Vida: " + monstro.Life.ToString();
            EnergiaM.Text = "Energia: " + monstro.Energia;
            NomeJogador.Text = jogador.Nome;
            NomeMonstro.Text = monstro.Nome;
        }

        /// <summary>
        /// Metodo para descrever a inteligencia do personagem
        /// </summary>
        private void InteligenciaMonstro()
        {
            //delay para ação do monstro
            _ = Task.Delay(700);

            //Retira a persistencia quando o mosntro se defendeu
            if (defesaMonstro)
            {
                Debug.WriteLine("Desativação da defesa ");
                defesaMonstro = false;
                this.monstro.Persistencia -= 10;
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
                    jogador.Life -= dano;
                    _ = ExibeDanoCombateAsync(dano, 2);
                }
                //Defende
                else
                {
                    Debug.WriteLine("ESCUDOS UTILIZADOS");
                    this.monstro.Persistencia += 10;
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
                        jogador.Life -= dano; 
                        _ = ExibeDanoCombateAsync(dano, 2);

                    }
                    //Defende
                    else
                    {
                        Debug.WriteLine("ESCUDOS UTILIZADOS");
                        this.monstro.Persistencia += 10;
                        defesaMonstro = true;
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
                        jogador.Life -=dano;
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
                        jogador.Life -= dano;
                        _ = ExibeDanoCombateAsync(dano, 2);
                    }
                    //Defende
                    else
                    {
                        Debug.WriteLine("ESCUDOS UTILIZADOS");
                        this.monstro.Persistencia += 10;
                        defesaMonstro = true;
                    }
                }
            }
        }
    }
}
