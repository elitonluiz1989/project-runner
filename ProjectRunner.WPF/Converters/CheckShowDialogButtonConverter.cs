using ProjectRunner.WPF.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace ProjectRunner.WPF.Converters
{
    public class CheckShowDialogButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (EFormFieldType)value is EFormFieldType.File or EFormFieldType.Path;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
