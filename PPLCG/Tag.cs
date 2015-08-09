using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public enum Tags
    {
        Buff, Debuff, Attack, Deffence, Balanced
    }
    public class Tag
    {
        public Tags Typ;
        public String Druh;
    }
}
