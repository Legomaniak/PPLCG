using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardFiller
{
    class ViewZrada : ViewKarta
    {
        MyListControlNamed boxStin = new MyListControlNamed() { Jmeno = "Stín" };

        public ViewZrada() : base(false)
        {
            Prvky.Add(boxStin);
            Init();
        }
        public void Init(PPLCG.DataZrada data)
        {
            base.Init(data);
            boxStin.ListControl.Init(data.Stin);
        }
        
    }
}
