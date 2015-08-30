using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nini.Config;

namespace PPLCG
{
    public class Citace:ISaveLoad
    {
        public string Text = "";
        public string Autor = "";
        public Citace()
        {
            Text = "Nevim.";
            Autor = "Nikdo";
        }
        public Citace(string text, string autor)
        {
            Text = text;
            Autor = autor;
        }

        public EReturn Save(IConfig config)
        {
            if (config != null)
            {
                config.Set("Text", Text);
                config.Set("Autor", Autor);
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }

        public EReturn Load(IConfig config)
        {
            if (config != null)
            {
                Text = config.GetString("Text");
                Autor = config.GetString("Autor");
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
    }
}
