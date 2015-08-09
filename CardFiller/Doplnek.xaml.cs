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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardFiller
{
    /// <summary>
    /// Interaction logic for Doplnek.xaml
    /// </summary>
    public partial class Doplnek : UserControl
    {
        public Doplnek()
        {
            InitializeComponent();
        }
        public PPLCG.DataDoplnek GetData()
        {
            return new PPLCG.DataDoplnek();
        }
        public void SetData(PPLCG.DataDoplnek karta)
        {
            boxCena.Text = karta.Cena.ToString();
        }
    }
}
