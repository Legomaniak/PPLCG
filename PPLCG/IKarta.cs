using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public interface IKarta
    {
        DataKarta Karta { get; }
        bool Save(Nini.Config.IConfigSource source);
        bool Load(Nini.Config.IConfigSource source);
    }
}
