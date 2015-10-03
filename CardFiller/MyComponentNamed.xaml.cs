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
    /// Interaction logic for MyComponentNamed.xaml
    /// </summary>
    public partial class MyComponentNamed : UserControl
    {
        public MyComponentNamed()
        {
            InitializeComponent();
        }
        public string Jmeno
        {
            get { return jmeno.Content.ToString(); }
            set { jmeno.Content = value; }
        }
    }

    public class MyLabelNamed : MyComponentNamed
    {
        Label label;
        public MyLabelNamed()
        {
            label = new Label();
            komponenta.Children.Add(label);
        }
        public Label Text { get { return label; } }
    }
    public class MyComboBoxNamed : MyComponentNamed
    {
        ComboBox _comboBox;
        public MyComboBoxNamed()
        {
            _comboBox = new ComboBox();
            komponenta.Children.Add(_comboBox);

        }
        public ComboBox ComboBox
        {
            get { return _comboBox; }
        }
    }
    public class MyCheckBoxNamed : MyComponentNamed
    {
        CheckBox _checkBox;
        public MyCheckBoxNamed()
        {
            _checkBox = new CheckBox();
            komponenta.Children.Add(_checkBox);

        }
        public CheckBox CheckBox
        {
            get { return _checkBox; }
        }
    }
    public class MyTextBoxNamed : MyComponentNamed
    {
        TextBox _textBox;
        public MyTextBoxNamed()
        {
            _textBox = new TextBox();
            komponenta.Children.Add(_textBox);

        }
        public TextBox TextBox
        {
            get { return _textBox; }
        }
    }
    public class MyTextBoxIntNamed : MyComponentNamed
    {
        TextBox _textBox;
        public MyTextBoxIntNamed()
        {
            _textBox = new MyTextBoxInt();
            komponenta.Children.Add(_textBox);

        }
        public TextBox TextBox
        {
            get { return _textBox; }
        }
    }
    public class MyListControlNamed : MyComponentNamed
    {
        MyListControl _listControl;
        public MyListControlNamed()
        {
            _listControl = new MyListControl();
            //ScrollViewer sv = new ScrollViewer();
            //sv.Content = _listControl;
            komponenta.Children.Add(_listControl);

        }
        public MyListControl ListControl
        {
            get { return _listControl; }
        }
    }
}
