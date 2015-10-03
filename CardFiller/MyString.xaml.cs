using System;
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
    /// Interaction logic for MyString.xaml
    /// </summary>
    public partial class MyString : UserControl
    {
        public MyString()
        {
            InitializeComponent();
        }
        public void Init(PPLCG.MyString ms)
        {
            Binding myBinding = new Binding("String");
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.Source = ms;
            text.SetBinding(TextBox.TextProperty, myBinding);
        }
    }
}
