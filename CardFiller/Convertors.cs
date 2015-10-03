using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace CardFiller
{
    public class ConvertorSfera : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)value;
            //string s = value.ToString();
            //switch (s)
            //{
            //    case "Ducha": return PPLCG.ESfery.Ducha;
            //    case "Neutralni": return PPLCG.ESfery.Neutralni;
            //    case "Taktiky": return PPLCG.ESfery.Taktiky;
            //    case "Vedeni": return PPLCG.ESfery.Vedeni;
            //    case "Veleni": return PPLCG.ESfery.Veleni;
            //    default: return PPLCG.ESfery.none;
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (PPLCG.ESfery)value;
        }
    }
}
