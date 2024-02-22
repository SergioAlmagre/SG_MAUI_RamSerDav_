using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SG_MAUI_RamSerDav_.MVVM.Converter
{
    public class ConversorTema : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            

            if ((bool)value)
            {
                return "Light";
            }
            else
            {
                return "Dark";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
