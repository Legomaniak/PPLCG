using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLCG
{
    public class DataSpojenec:DataKarta
    {
        public int Zdroje
        {
            get { return _Zdroje; }
            set { _Zdroje = value; OnPropertyChanged("Zdroje"); }
        }
        int _Zdroje = 0;
        public int Vule
        {
            get { return _Vule; }
            set { _Vule = value; OnPropertyChanged("Vule"); }
        }
        int _Vule = 0;
        public int Utok
        {
            get { return _Utok; }
            set { _Utok = value; OnPropertyChanged("Utok"); }
        }
        int _Utok = 0;
        public int Obrana
        {
            get { return _Obrana; }
            set { _Obrana = value; OnPropertyChanged("Obrana"); }
        }
        int _Obrana = 0;
        public int Zivoty
        {
            get { return _Zivoty; }
            set { _Zivoty = value; OnPropertyChanged("Zivoty"); }
        }
        int _Zivoty = 0;
        public DataSpojenec()
        {
             Zdroje = 0;
             Vule = 0;
             Utok = 0;
             Obrana = 0;
             Zivoty = 0;
            Typ = ETypy.Spojenec;
        }
        public DataSpojenec(DataKarta dk, int zivoty, int utok, int obrana, int vule, int zdroje) : base(dk)
        {
            Zdroje = zdroje;
            Vule = vule;
            Utok = utok;
            Obrana = obrana;
            Zivoty = zivoty;
        }
        public override EReturn Save(Nini.Config.IConfig config)
        {
            base.Save(config);
            //Nini.Config.IConfig config = source.AddConfig("Spojenec");
            if (config != null)
            {
                config.Set("Zdroje", Zdroje);
                config.Set("Vule", Vule);
                config.Set("Utok", Utok);
                config.Set("Obrana", Obrana);
                config.Set("Zivoty", Zivoty);
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        public override EReturn Load(Nini.Config.IConfig config)
        {
            base.Load(config);
            //Nini.Config.IConfig config = GetConfig(source, "Spojenec");
            if (config != null)
            {
                Zdroje = config.GetInt("Zdroje");
                Vule = config.GetInt("Vule");
                Utok = config.GetInt("Utok");
                Obrana = config.GetInt("Obrana");
                Zivoty = config.GetInt("Zivoty");
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
    }
}
