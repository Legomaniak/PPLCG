using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nini.Config;

namespace PPLCG
{
    public class DataKarta : ANotifer, IKarta
    {
        public string Id
        {
            get { return _Id; }
            set { _Id = value; OnPropertyChanged("Id"); }
        }
        string _Id = "";
        public string Jmeno
        {
            get { return _Jmeno; }
            set { _Jmeno = value; OnPropertyChanged("Jmeno"); }
        }
        string _Jmeno = "";
        public string Popis
        {
            get { return _Popis; }
            set { _Popis = value; OnPropertyChanged("Popis"); }
        }
        string _Popis = "";
        public string Text
        {
            get { return _Text; }
            set { _Text = value; OnPropertyChanged("Text"); }
        }
        string _Text = "";
        public string Autor
        {
            get { return _Autor; }
            set { _Autor = value; OnPropertyChanged("Autor"); }
        }
        string _Autor = "";
        public ESfery Sfera
        {
            get { return _ASfera; }
            set
            {
                _ASfera = value; OnPropertyChanged("Sfera");
            }
        }
        ESfery _ASfera = ESfery.Neutralni;
        public ETypy Typ
        {
            get { return _Typ; }
            set
            {
                _Typ = value; OnPropertyChanged("Typ");
            }
        }
        ETypy _Typ = ETypy.Hrdina;
        public bool Kvalita
        {
            get { return _Kvalita; }
            set
            {
                _Kvalita = value; OnPropertyChanged("Kvalita");
            }
        }
        bool _Kvalita = false;
        public List<MyString> Reakce
        {
            get { return _Reakce; }
            set
            {
                _Reakce = value; OnPropertyChanged("Reakce");
            }
        }
        List<MyString> _Reakce;
        public List<MyString> Druh
        {
            get { return _Druh; }
            set
            {
                _Druh = value; OnPropertyChanged("Druh");
            }
        }
        List<MyString> _Druh;
        public bool IsValid
        {
            get { return _IsValid; }
            set
            {
                _IsValid = value; OnPropertyChanged("IsValid");
            }
        }
        bool _IsValid = false;
        public DataKarta()
        {
            Id = "K0";
            Jmeno = "Karta";
            Popis = "Prazdná karta";
            Sfera = ESfery.Neutralni;
            Typ = ETypy.Spojenec;
            Kvalita = false;
            Reakce = new List<MyString>();
            Druh = new List<MyString>();
            Text = "Nevim.";
            Autor = "Nikdo";
        }
        public DataKarta(string id, string jmeno, string popis, ESfery sfera, ETypy typ, bool kvalita, List<MyString> reakce, List<MyString> druh, string text, string autor)
        {
            Id = id;
            Jmeno = jmeno;
            Popis = popis;
            Sfera = sfera;
            Typ = typ;
            Kvalita = kvalita;
            Reakce = reakce;
            Druh = druh;
            Text = text;
            Autor = autor;
        }
        public DataKarta(DataKarta DK)
        {
            Id = DK.Id;
            Jmeno = DK.Jmeno;
            Popis = DK.Popis;
            Sfera = DK.Sfera;
            Typ = DK.Typ;
            Kvalita = DK.Kvalita;
            Reakce = DK.Reakce;
            Druh = DK.Druh;
            Text = DK.Text;
            Autor = DK.Autor;
        }
        public virtual EReturn Save(IConfig config)
        {
            //IConfig config = source.AddConfig("Karta");
            if (config != null)
            {
                config.Set("ID", Id);
                config.Set("Jmeno", Jmeno);
                config.Set("Popis", Popis);
                config.Set("Sfera", (int)Sfera);
                config.Set("Typ", (int)Typ);
                string s = "";
                foreach (MyString ss in Druh)
                    if (s == "") s = ss.String;
                    else s = s + "," + ss.String;
                config.Set("Druh", s);
                s = "";
                foreach (MyString ss in Reakce)
                    if (s == "") s = ss.String;
                    else s = s + "," + ss.String;
                config.Set("Reakce", s);
                config.Set("Text", Text);
                config.Set("Autor", Autor);
                config.Set("Kvalita", Kvalita);
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        public virtual EReturn Load(IConfig config)
        {
            //IConfig config = GetConfig(source, "Karta");
            if (config != null)
            {
                Id = config.GetString("ID");
                Jmeno = config.GetString("Jmeno");
                Popis = config.GetString("Popis");
                Sfera = (ESfery)config.GetInt("Sfera");
                Typ = (ETypy)config.GetInt("Typ");
                string s = config.GetString("Druh");
                string[] druh = s.Split(',');
                Druh = new List<MyString>();
                foreach (string ss in druh)
                {
                    MyString ms = new MyString();
                    ms.String = ss;
                    Druh.Add(ms);
                }
                s = config.GetString("Reakce");
                string[] reakce = s.Split(',');
                Reakce = new List<MyString>();
                foreach (string ss in reakce)
                {
                    MyString ms = new MyString();
                    ms.String = ss;
                    Reakce.Add(ms);
                }
                Text = config.GetString("Text");
                Autor = config.GetString("Autor");
                Kvalita = config.GetBoolean("Kvalita");
                return EReturn.NoError;
            }
            else return EReturn.Error;
        }
        //public IConfig GetConfig(IConfigSource source, string nameConfig)
        //{
        //    if (source.Configs[0].Name == nameConfig) return source.Configs[nameConfig];
        //    else return null;
        //}
    }
}
