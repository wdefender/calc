using calc.Common.Infrastructure.Enums;
using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace calc.UI.Keys.Converters
{
    public class KeyTypeToStyleConverter : MarkupExtension, IValueConverter
    {
        private static KeyTypeToStyleConverter converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new KeyTypeToStyleConverter());
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (KeyType)value == KeyType.NumericKey ? Application.Current.FindResource("ButtonStyle") as Style : Application.Current.FindResource("OperatorButtonStyle") as Style;


            //return Binding.DoNothing; /*value == null ? Visibility.Collapsed : Visibility.Visible;*/
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
