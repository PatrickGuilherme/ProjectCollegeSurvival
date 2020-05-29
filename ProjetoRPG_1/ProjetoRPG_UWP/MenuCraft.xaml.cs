using OpenQA.Selenium;
using ProjetoRPG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetoRPG_UWP
{
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class MenuCraft : Page
    {
        private PersonagemJogavel jogador;

        public MenuCraft()
        {
            this.InitializeComponent();
            Craftar.Click += Btn_Craftar;
            InstaciarItemsSecundarios();
            
        }

        private void Btn_Craftar(object sender, RoutedEventArgs e) 
        {
            if (ListaCraft.SelectedValue != null)
            {
                ItemSecundario item = ListaCraft.SelectedItem as ItemSecundario;
                item.addItem(item.Nome);

                if(jogador.MenuCraft.Craftar(jogador.inventario, item)) 
                {
                    MensagemErro("Querido usuário, parabéns. Você criou um novo item. Cuide bem!", "Congratulações!");
                }
                else MensagemErro("Querido, usuário, que pena. Você ta pobre em items.", "Deu ruim, pai...");
            }
            else
            {
                MensagemErro("Querido usuário, por favor. Seja amigo. Me ajude aqui. Selecione um item.", "Ai tu me quebra...");
            }
        }

        private async void MensagemErro(string Mensagem, string Titulo) 
        {
            var dialog = new MessageDialog(Mensagem, Titulo);
            var result = await dialog.ShowAsync();
        }

        private void InstaciarItemsSecundarios() 
        {
            //List<ItemSecundario> ListItems = new List<ItemSecundario>();
            ItemSecundario BlueBull = new ItemSecundario();
            BlueBull.Nome = "BLUE BULL";
            BlueBull.BuffEnergia = 20;
            BlueBull.NivelRequerido = 2;
            BlueBull.BuffAnimo = 0;
            BlueBull.BuffLife = 0;
            BlueBull.BuffPersistencia = 0;
            BlueBull.ListaAuxiliar = new List<ItemPrimario>();
            BlueBull.Dano = 0;
            BlueBull.ItensPreRequesito = new List<ItemPrimario>();
            BlueBull.Descricao = @"O blue bull é um energético sendo umitem consumível de duração de 1 turno, aumentando a energia do personagem sem nenhuma semelhança a qualquer outra bebidad existente.";
            ListaCraft.Items.Add(BlueBull);

            ItemSecundario SunBley = new ItemSecundario();
            SunBley.BuffAnimo = 0;
            SunBley.BuffEnergia = 10;
            SunBley.BuffLife = 0;
            SunBley.BuffPersistencia = 0;
            SunBley.Dano = 0;
            SunBley.ListaAuxiliar = new List<ItemPrimario>();
            SunBley.NivelRequerido = 2;
            SunBley.ItensPreRequesito = new List<ItemPrimario>();
            SunBley.Nome = "SUNBLEY";
            SunBley.Descricao = @"O energético é um item consumível de duração de 1 turno, aumentando a energia do personagem.";
            ListaCraft.Items.Add(SunBley);

            ItemSecundario Cafe = new ItemSecundario();
            Cafe.BuffAnimo = 8;
            Cafe.BuffEnergia = 0;
            Cafe.BuffLife = 0;
            Cafe.BuffPersistencia = 0;
            Cafe.Dano = 0;
            Cafe.ListaAuxiliar = new List<ItemPrimario>();
            Cafe.NivelRequerido = 2;
            Cafe.ItensPreRequesito = new List<ItemPrimario>();
            Cafe.Nome = "CAFÉ";
            Cafe.Descricao = "O café é um item consumível de duração de 1 turno, aumentando o ânimo do personagem.";
            ListaCraft.Items.Add(Cafe);

            ItemSecundario NotasAula = new ItemSecundario();
            NotasAula.BuffAnimo = 0;
            NotasAula.BuffEnergia = 0;
            NotasAula.BuffLife = 0;
            NotasAula.BuffPersistencia = 10;
            NotasAula.Dano = 0;
            NotasAula.ListaAuxiliar = new List<ItemPrimario>();
            NotasAula.ItensPreRequesito = new List<ItemPrimario>();
            NotasAula.NivelRequerido = 3;
            NotasAula.Nome = "NOTAS DE AULA";
            NotasAula.Descricao = "A anotação é um item usável de duração de 1 turno, aumentando a persistência do personagem.";
            ListaCraft.Items.Add(NotasAula);

            ItemSecundario Calculadora = new ItemSecundario();
            Calculadora.BuffAnimo = 0;
            Calculadora.BuffEnergia = 0;
            Calculadora.BuffLife = 0;
            Calculadora.BuffPersistencia = 0;
            Calculadora.ListaAuxiliar = new List<ItemPrimario>();
            Calculadora.Dano = 100;
            Calculadora.ItensPreRequesito = new List<ItemPrimario>();
            Calculadora.NivelRequerido = 3;
            Calculadora.Nome = "CALCULADORA";
            Calculadora.Descricao = "A calculadora é um item usável, causador de dano, DESTRUIDOR DE COLAS.";
            ListaCraft.Items.Add(Calculadora);

            ItemSecundario MiniSol = new ItemSecundario();
            MiniSol.BuffAnimo = 0;
            MiniSol.BuffEnergia = 0;
            MiniSol.Dano = 300;
            MiniSol.ListaAuxiliar = new List<ItemPrimario>();
            MiniSol.BuffLife = 0;
            MiniSol.ItensPreRequesito = new List<ItemPrimario>();
            MiniSol.BuffPersistencia = 0;
            MiniSol.NivelRequerido = 3;
            MiniSol.Nome = "MINI SOL";
            MiniSol.Descricao = "O MiniSol é um item usável, causador de dano, DESTRUIDOR DE MUNDOS.";
            ListaCraft.Items.Add(MiniSol);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            jogador = e.Parameter as PersonagemJogavel;
        }
    }
}
