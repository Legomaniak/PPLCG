﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace CardFiller
{
    class ViewSpojenec : ViewKarta
    {
        MyTextBoxIntNamed boxZivoty = new MyTextBoxIntNamed() { Jmeno = "Životy" };
        MyTextBoxIntNamed boxUtok = new MyTextBoxIntNamed() { Jmeno = "Útok" };
        MyTextBoxIntNamed boxObrana = new MyTextBoxIntNamed() { Jmeno = "Obrana" };
        MyTextBoxIntNamed boxVule = new MyTextBoxIntNamed() { Jmeno = "Vůle" };
        MyTextBoxIntNamed boxZdroje = new MyTextBoxIntNamed() { Jmeno = "Zdroje" };
        public ViewSpojenec() : base(false)
        {
            Prvky.Add(boxZivoty);
            Prvky.Add(boxUtok);
            Prvky.Add(boxObrana);
            Prvky.Add(boxVule);
            Prvky.Add(boxZdroje);
            Init();
        }
        public void Init(PPLCG.DataSpojenec data)
        {
            base.Init(data);
            Binding myBinding = new Binding("Zivoty");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxZivoty.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Utok");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxUtok.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Obrana");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxObrana.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Vule");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxVule.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Zdroje");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxZdroje.TextBox.SetBinding(TextBox.TextProperty, myBinding);
        }
    }
}
