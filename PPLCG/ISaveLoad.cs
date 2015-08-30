using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nini.Config;

namespace PPLCG
{
    public interface ISaveLoad
    {
        EReturn Save(IConfig config);
        EReturn Load(IConfig config);
    }
}
