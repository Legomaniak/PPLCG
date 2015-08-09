using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class KartaDoplnek : IKarta
    {
        public DataKarta Karta { get; set; }
        public DataDoplnek Doplnek { get; set; }

        public KartaDoplnek()
        {
            Karta = new DataKarta();
            Doplnek = new DataDoplnek();
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            if (Karta.Save(source)) ;
            else if (Doplnek.Save(source)) ;
            else return true;
            return false;
        }

        public bool Load(Nini.Config.IConfigSource source)
        {
            if (Karta.Load(source)) ;
            else if (Doplnek.Load(source)) ;
            else return true;
            return false;
        }
    }
    public class KartaHrdina : IKarta
    {
        public DataKarta Karta { get; set; }
        public DataHrdina Hrdina { get; set; }

        public KartaHrdina()
        {
            Karta = new DataKarta();
            Hrdina = new DataHrdina();
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            if (Karta.Save(source)) ;
            else if (Hrdina.Save(source)) ;
            else return true;
            return false;
        }

        public bool Load(Nini.Config.IConfigSource source)
        {
            if (Karta.Load(source)) ;
            else if (Hrdina.Load(source)) ;
            else return true;
            return false;
        }
    }
    public class KartaLokace : IKarta
    {
        public DataKarta Karta { get; set; }
        public DataLokace Lokace { get; set; }

        public KartaLokace()
        {
            Karta = new DataKarta();
            Lokace = new DataLokace();
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            if (Karta.Save(source)) ;
            else if (Lokace.Save(source)) ;
            else return true;
            return false;
        }

        public bool Load(Nini.Config.IConfigSource source)
        {
            if (Karta.Load(source)) ;
            else if (Lokace.Load(source)) ;
            else return true;
            return false;
        }
    }
    public class KartaNepritel : IKarta
    {
        public DataKarta Karta { get; set; }
        public DataNepritel Nepritel { get; set; }

        public KartaNepritel()
        {
            Karta = new DataKarta();
            Nepritel = new DataNepritel();
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            if (Karta.Save(source)) ;
            else if (Nepritel.Save(source)) ;
            else return true;
            return false;
        }

        public bool Load(Nini.Config.IConfigSource source)
        {
            if (Karta.Load(source)) ;
            else if (Nepritel.Load(source)) ;
            else return true;
            return false;
        }
    }
    public class KartaSpojenec : IKarta
    {
        public DataKarta Karta { get; set; }
        public DataSpojenec Spojenec { get; set; }

        public KartaSpojenec()
        {
            Karta = new DataKarta();
            Spojenec = new DataSpojenec();
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            if (Karta.Save(source)) ;
            else if (Spojenec.Save(source)) ;
            else return true;
            return false;
        }

        public bool Load(Nini.Config.IConfigSource source)
        {
            if (Karta.Load(source)) ;
            else if (Spojenec.Load(source)) ;
            else return true;
            return false;
        }
    }
    public class KartaUdalost : IKarta
    {
        public DataKarta Karta { get; set; }
        public DataUdalost Udalost { get; set; }

        public KartaUdalost()
        {
            Karta = new DataKarta();
            Udalost = new DataUdalost();
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            if (Karta.Save(source)) ;
            else if (Udalost.Save(source)) ;
            else return true;
            return false;
        }

        public bool Load(Nini.Config.IConfigSource source)
        {
            if (Karta.Load(source)) ;
            else if (Udalost.Load(source)) ;
            else return true;
            return false;
        }
    }
    public class KartaZrada : IKarta
    {
        public DataKarta Karta { get; set; }
        public DataZrada Zrada { get; set; }

        public KartaZrada()
        {
            Karta = new DataKarta();
            Zrada = new DataZrada();
        }
        public bool Save(Nini.Config.IConfigSource source)
        {
            if (Karta.Save(source)) ;
            else if (Zrada.Save(source)) ;
            else return true;
            return false;
        }

        public bool Load(Nini.Config.IConfigSource source)
        {
            if (Karta.Load(source)) ;
            else if (Zrada.Load(source)) ;
            else return true;
            return false;
        }
    }
}
