using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class Faze
    {
        List<TypFaze> faze = new List<TypFaze>();
        public Faze()
        {
            faze.Add(new TypFaze() { Jméno = "Zdroje 1", AkcePovoleny = false });
            faze.Add(new TypFaze() { Jméno = "Zdroje 2", AkcePovoleny = true });
            faze.Add(new TypFaze() { Jméno = "Plánování 1", AkcePovoleny = true });
            faze.Add(new TypFaze() { Jméno = "Plánování 2", AkcePovoleny = true });
            faze.Add(new TypFaze() { Jméno = "Plánování 3", AkcePovoleny = true });
            faze.Add(new TypFaze() { Jméno = "Plánování 4", AkcePovoleny = true });
            faze.Add(new TypFaze() { Jméno = "Výprava 1", AkcePovoleny = true });
            faze.Add(new TypFaze() { Jméno = "Výprava 2", AkcePovoleny = false });
            faze.Add(new TypFaze() { Jméno = "Výprava 3", AkcePovoleny = true });
            faze.Add(new TypFaze() { Jméno = "Výprava 4", AkcePovoleny = false });
            faze.Add(new TypFaze() { Jméno = "Cestování 1", AkcePovoleny = false });
            faze.Add(new TypFaze() { Jméno = "Cestování 2", AkcePovoleny = true });
        }
        int kteraFaze = 0;
        public TypFaze AktualniFaze { get { return faze[kteraFaze]; } }
        public void PosunFazy()
        {
            kteraFaze = (kteraFaze + 1) % faze.Count;
        }
    }
    public class TypFaze
    {
        public string Jméno;
        public bool AkcePovoleny;
    }
}
