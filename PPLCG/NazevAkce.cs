using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class NazevAkce
    {
        public string Nazev;
        public int Uroven;
        public NazevAkce(string NazevUroven)
        {
            Uroven = 0;
            Nazev = "Žádná akce";
            if (NazevUroven.Count() >= 5) if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 5, 5), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 5);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 4, 4), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 4);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 3, 3), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 3);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 2, 2), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 2);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 1, 1), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 1);
                else ;
            else if (NazevUroven.Count() == 4) if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 4, 4), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 4);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 3, 3), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 3);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 2, 2), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 2);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 1, 1), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 1);
                else ;
            else if (NazevUroven.Count() == 3) if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 3, 3), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 3);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 2, 2), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 2);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 1, 1), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 1);
                else ;
            else if (NazevUroven.Count() == 2) if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 2, 2), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 2);
                else if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 1, 1), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 1);
                else ;
            else if (NazevUroven.Count() == 1) if (int.TryParse(NazevUroven.Substring(NazevUroven.Count() - 1, 1), out Uroven)) Nazev = NazevUroven.Substring(0, NazevUroven.Count() - 1);
                else ;

        }
        public NazevAkce(string nazev, int uroven)
        {
            Nazev = nazev;
            Uroven = uroven;
        }
        public string GetNazevUroven()
        {
            return Nazev + Uroven;
        }
    }
}
