using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BookCollector.Converters
{
    class StringDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal decVal;
            if (decimal.TryParse(value as string, out decVal))
                return decVal;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal)
                return value.ToString();
            return value;
        }
    }
}
