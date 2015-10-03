using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace CardFiller
{
    class ViewNepritel:ViewKarta
    {
        MyTextBoxIntNamed boxZivoty = new MyTextBoxIntNamed() { Jmeno = "Životy" };
        MyTextBoxIntNamed boxUtok = new MyTextBoxIntNamed() { Jmeno = "Útok" };
        MyTextBoxIntNamed boxObrana = new MyTextBoxIntNamed() { Jmeno = "Obrana" };
        MyTextBoxIntNamed boxOhrozeni = new MyTextBoxIntNamed() { Jmeno = "Ohrožení" };
        MyTextBoxIntNamed boxStretnuti = new MyTextBoxIntNamed() { Jmeno = "Střetnutí" };
        MyListControlNamed boxStin = new MyListControlNamed() { Jmeno = "Stín" };

        public ViewNepritel() : base(false)
        {
            Prvky.Add(boxZivoty);
            Prvky.Add(boxUtok);
            Prvky.Add(boxObrana);
            Prvky.Add(boxOhrozeni);
            Prvky.Add(boxStretnuti);
            Prvky.Add(boxStin);
            Init();
        }
        public void Init(PPLCG.DataNepritel data)
        {
            base.Init(data);

            boxStin.ListControl.Init(data.Stin);

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

            myBinding = new Binding("Ohrozeni");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxOhrozeni.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Stretnuti");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxStretnuti.TextBox.SetBinding(TextBox.TextProperty, myBinding);

        }
    }
}
