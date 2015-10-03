using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;

namespace CardFiller
{
    public class ViewUdalost : ViewKarta
    {
        MyTextBoxIntNamed boxCena = new MyTextBoxIntNamed() { Jmeno = "Cena" };
        public ViewUdalost():base(false)
        {
            Prvky.Add(boxCena);
            Init();
        }
        public void Init(PPLCG.DataUdalost data)
        {
            base.Init(data);
            Binding myBinding = new Binding("Cena");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxCena.SetBinding(TextBox.TextProperty, myBinding);

        }
    }
}
