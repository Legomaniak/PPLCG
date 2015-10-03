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
    /// Interaction logic for Karta.xaml
    /// </summary>
    public partial class ViewKarta : UserControl
    {
        protected List<UIElement> Prvky = new List<UIElement>();
        public void Init()
        {
            SP.Children.Clear();
            foreach (UIElement u in Prvky) SP.Children.Add(u);
        }
        MyTextBoxNamed boxId = new MyTextBoxNamed() { Jmeno = "ID" };
        MyTextBoxNamed boxJmeno = new MyTextBoxNamed() { Jmeno = "Jméno" };
        MyTextBoxNamed boxPopis = new MyTextBoxNamed() { Jmeno = "Popis" };
        MyTextBoxNamed boxCitace = new MyTextBoxNamed() { Jmeno = "Citace" };
        MyTextBoxNamed boxAutor = new MyTextBoxNamed() { Jmeno = "Autor" };
        MyCheckBoxNamed boxKvalita = new MyCheckBoxNamed() { Jmeno = "Unikátní" };
        MyLabelNamed boxTyp = new MyLabelNamed() { Jmeno = "Typ" };
        MyComboBoxNamed boxSfera = new MyComboBoxNamed() { Jmeno = "Sféra" };
        MyListControlNamed boxDruh = new MyListControlNamed() { Jmeno = "Druh" };
        MyListControlNamed boxReakce = new MyListControlNamed() { Jmeno = "Reakce" };
        public ViewKarta()
        {
            InitializeComponent();
            boxSfera.ComboBox.Items.Clear();
            foreach (string s in Enum.GetNames(typeof(PPLCG.ESfery)))
            {
                boxSfera.ComboBox.Items.Add(new ComboBoxItem() { Content = s });
            }
            Prvky.Add(boxId);
            Prvky.Add(boxJmeno);
            Prvky.Add(boxPopis);
            Prvky.Add(boxCitace);
            Prvky.Add(boxAutor);
            Prvky.Add(boxTyp);
            Prvky.Add(boxSfera);
            Prvky.Add(boxKvalita);
            Prvky.Add(boxDruh);
            Prvky.Add(boxReakce);
            Init();
        }
        public ViewKarta(bool init)
        {
            InitializeComponent();
            //DataKarta = new PPLCG.DataKarta();
            //Prvky.Add(boxId);
            //Prvky.Add(boxJmeno);
            //Prvky.Add(boxPopis);
            //Prvky.Add(boxCitace);
            //Prvky.Add(boxAutor);
            //Prvky.Add(boxTyp);
            //Prvky.Add(boxSfera);
            //Prvky.Add(boxKvalita);
            //Prvky.Add(boxDruh);
            //Prvky.Add(boxReakce);
            //Init();
        }
        public void Init(PPLCG.DataKarta data)
        {

            boxDruh.ListControl.Init(data.Druh);
            boxReakce.ListControl.Init(data.Reakce);
            
            Binding myBinding = new Binding("Id");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxId.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Jmeno");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxJmeno.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Popis");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxPopis.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Text");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxCitace.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Autor");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxAutor.TextBox.SetBinding(TextBox.TextProperty, myBinding);

            myBinding = new Binding("Typ");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.OneWay;
            boxTyp.Text.SetBinding(Label.ContentProperty, myBinding);

            myBinding = new Binding("Sfera");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            myBinding.Converter = new ConvertorSfera();
            boxSfera.ComboBox.SetBinding(ComboBox.SelectedIndexProperty, myBinding);
            
            myBinding = new Binding("Kvalita");
            myBinding.Source = data;
            myBinding.Mode = BindingMode.TwoWay;
            boxKvalita.CheckBox.SetBinding(CheckBox.IsCheckedProperty, myBinding);

        }
        
    }
}
