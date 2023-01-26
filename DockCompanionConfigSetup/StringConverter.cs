using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DockCompanionConfigSetup
{
    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Code to replace the comma with a space
            return value.ToString().Replace(",", " | ");
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] splitString = value.ToString().Split(',');
            return splitString[splitString.Length - 1].TrimEnd(']');
        }
    }
}
