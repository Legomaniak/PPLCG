using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CardFiller
{
    class MyTextBoxInt:TextBox
    {
        public MyTextBoxInt()
        {
            this.TextChanged += MyTextBoxInt_TextChanged;
        }

        private void MyTextBoxInt_TextChanged(object sender, TextChangedEventArgs e)
        {
           int val = 0;
            if (int.TryParse(this.Text, out val)) Foreground = Brushes.Black;
            else Foreground = Brushes.Red;
        }
    }
}
