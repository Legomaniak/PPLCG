using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace CardFiller
{
    public class AKarta
    {
        public PPLCG.IKarta Karta;
        public StackPanel sp = new StackPanel();
        public AKarta(PPLCG.DataKarta data)
        {         
            ViewKarta vk = new ViewKarta();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
    public class KartaHrdina : AKarta
    {
        public KartaHrdina(PPLCG.DataHrdina data) : base(data)
        {
            Karta = data;
            ViewHrdina vk = new ViewHrdina();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
    public class KartaLokace : AKarta
    {
        public KartaLokace(PPLCG.DataLokace data) : base(data)
        {
            Karta = data;
            ViewLokace vk = new ViewLokace();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
    public class KartaDoplnek: AKarta
    {
        public KartaDoplnek(PPLCG.DataDoplnek data) : base(data)
        {
            Karta = data;
            ViewDoplnek vk = new ViewDoplnek();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
    public class KartaNepritel : AKarta
    {
        public KartaNepritel(PPLCG.DataNepritel data) : base(data)
        {
            Karta = data;
            ViewNepritel vk = new ViewNepritel();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
    public class KartaSpojenec : AKarta
    {
        public KartaSpojenec(PPLCG.DataSpojenec data) : base(data)
        {
            Karta = data;
            ViewSpojenec vk = new ViewSpojenec();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
    public class KartaUdalost : AKarta
    {
        public KartaUdalost(PPLCG.DataUdalost data) : base(data)
        {
            Karta = data;
            ViewUdalost vk = new ViewUdalost();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
    public class KartaZrada : AKarta
    {
        public KartaZrada(PPLCG.DataZrada data) : base(data)
        {
            Karta = data;
            ViewZrada vk = new ViewZrada();
            vk.Init(data);
            sp.Children.Add(vk);
        }
    }
}
