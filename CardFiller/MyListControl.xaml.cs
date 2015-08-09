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
    /// Interaction logic for MyListControl.xaml
    /// </summary>
    public partial class MyListControl : UserControl
    {
        public MyListControl()
        {
            InitializeComponent();
        }
        public List<string> data 
    {
        get { return _data; }
        set
        {
            _data = value;
            stackPanel1.Children.Clear();
            Add();
        }
    }
        List<string> _data = new List<string>();
        public void Add(object sender, RoutedEventArgs e)
        {
            Add();
        }
        public void Add()
        {
            ComboBox cb = new ComboBox();
            cb.IsEditable = true;
            foreach (string s in data) cb.Items.Add(s);
            stackPanel1.Children.Add(cb);
        }
        public void Add(string s)
        {
            ComboBox cb = new ComboBox();
            cb.IsEditable = true;
            cb.Items.Add(s);
            foreach (string ss in data) cb.Items.Add(ss);
            cb.SelectedIndex = 0;
            stackPanel1.Children.Add(cb);
        }

        private void Rmove(object sender, RoutedEventArgs e)
        {
            if (stackPanel1.Children.Count > 0) stackPanel1.Children.Remove(stackPanel1.Children[stackPanel1.Children.Count - 1]);
        }
        public List<string> GetSelected()
        {
            List<string> ret = new List<string>();
            foreach (ComboBox cb in stackPanel1.Children) if (cb.Text != null) ret.Add(cb.Text);
            return ret;
        }
    }
}
