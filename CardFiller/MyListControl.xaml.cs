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
        List<PPLCG.MyString> MyList;
        public void Init(List<PPLCG.MyString> myList)
        {
            MyList = myList;
            foreach(PPLCG.MyString ms in MyList)
            {
                MyString myString = new MyString();
                myString.Init(ms);
                stackPanel1.Children.Add(myString);
            }
        }

        private void Remove(object sender, RoutedEventArgs e)
        {
            if (MyList == null) return;
            int index = stackPanel1.Children.Count - 1;
            stackPanel1.Children.RemoveAt(index);
            MyList.RemoveAt(index);

        }

        private void Add(object sender, RoutedEventArgs e)
        {
            if (MyList == null) return;
            PPLCG.MyString ms = new PPLCG.MyString();
            MyList.Add(ms);
            MyString myString = new MyString();
            myString.Init(ms);
            stackPanel1.Children.Add(myString);
        }
    }
}
