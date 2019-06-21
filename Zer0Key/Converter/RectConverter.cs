using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Zer0Key
{
    public class RectConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var width = (double)values[0];
            var awidth = (double)values[1];
            var height = (double)values[2];

            var result = width <= 0 ? awidth : width;
            return new Rect(0, 0, result, height);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
