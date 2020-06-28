using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookCollector.Converters
{
    class StringIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int intVal;
            if (int.TryParse(value as string, out intVal))
                return intVal;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
                return value.ToString();
            return value;
        }
    }
}
