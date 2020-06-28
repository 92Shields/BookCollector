using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookCollector.Converters
{
    class StringLongConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            long longVal;
            if (long.TryParse(value as string, out longVal))
                return longVal;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is long)
                return value.ToString();
            return value;
        }
    }
}
