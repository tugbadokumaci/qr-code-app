using System;
using System.Globalization;


namespace QrCodeApp.Mobile.Converters
{
    public class BoolToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                string[] texts = parameter?.ToString()?.Split('|') ?? new string[] { "False", "True" };
                return boolValue ? texts[1] : texts[0];
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}