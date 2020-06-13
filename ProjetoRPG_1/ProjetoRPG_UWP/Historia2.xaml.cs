﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// O modelo de item de Página em Branco está documentado em https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjetoRPG_UWP {
    /// <summary>
    /// Uma página vazia que pode ser usada isoladamente ou navegada dentro de um Quadro.
    /// </summary>
    public sealed partial class Historia2 : Page {
        public Historia2() {
            this.InitializeComponent();
            btn2.PointerMoved += btn_mouse;
            btn2.Click += Btn_Click;
        }
        private void btn_mouse(object sender, RoutedEventArgs e) {
            //this.Frame.Navigate(typeof(Historia));
            btn2.Background = new SolidColorBrush(Colors.White);

        }
        private void Btn_Click(object sender, RoutedEventArgs e) {
            this.Frame.Navigate(typeof(Historia3));

        }
    }
}
