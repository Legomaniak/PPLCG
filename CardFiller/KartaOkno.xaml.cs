﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CardFiller
{
    /// <summary>
    /// Interaction logic for KartaOkno.xaml
    /// </summary>
    public partial class KartaOkno : Window
    {
        public KartaOkno()
        {
            InitializeComponent();
        }
        public void Init(AKarta karta)
        {
            ScrollViewer sv = new ScrollViewer() { Content = karta.sp };
            this.karta.Content = sv;
        }
        private void buttonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
