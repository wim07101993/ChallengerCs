using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DataConverter.Wpf.Converters
{
    public class BrushToHexConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) 
                return null;

            static string LowerHexString(int i) => i.ToString("X2").ToLower();

            var brush = (SolidColorBrush)value;
            return $"#{LowerHexString(brush.Color.R)}{LowerHexString(brush.Color.G)}{LowerHexString(brush.Color.B)}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
