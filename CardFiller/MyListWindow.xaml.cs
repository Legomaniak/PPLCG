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
using System.Windows.Shapes;

namespace CardFiller
{
    /// <summary>
    /// Interaction logic for MyListWindow.xaml
    /// </summary>
    public partial class MyListWindow : Window
    {
        public MyListWindow()
        {
            InitializeComponent();
        }
        public string Jmeno
        {
            set { label1.Content = value; }
        }

        private void clickOk(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
