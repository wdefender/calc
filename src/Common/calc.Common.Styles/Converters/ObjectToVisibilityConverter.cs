using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace calc.Common.Styles.Converters
{
    public class ObjectToVisibilityConverter : MarkupExtension, IValueConverter
    {
        private static ObjectToVisibilityConverter converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new ObjectToVisibilityConverter());
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
