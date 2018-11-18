using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace MusicStore
{
    public class ConvertIntToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string format = value as string;

            return "€" + format;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string format = value as string;

            return Double.Parse(format.Substring(1));
        }
    }
}
