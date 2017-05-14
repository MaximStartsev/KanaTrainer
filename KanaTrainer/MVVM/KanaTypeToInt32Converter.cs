using System;
using System.Globalization;
using System.Windows.Data;

namespace MaximStartsev.KanaTrainer.MVVM
{
    class KanaTypeToInt32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Int32)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (KanaType)value;
        }
    }
}
