using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public interface IKarta: ISaveLoad
    {
        string Id { get; set; }
    }
}
