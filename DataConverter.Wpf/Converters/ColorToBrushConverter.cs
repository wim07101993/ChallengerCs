using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace DataConverter.Wpf.Converters
{
    public class ColorToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is Color color
                ? new SolidColorBrush(color)
                : Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is SolidColorBrush brush
                ? brush.Color
                : (object)default(Color);
        }
    }
}
