using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class MyString : ANotifer
    {
        private string _s = "";
        public string String
        {
            get { return _s; }
            set
            {
                _s = value;
                OnPropertyChanged("String");
            }
        }
    }
}
