using System.Windows;
using System;
using System.Globalization;

namespace TreeView.Helpers.Converters
{
    public class VisibilityConverter : Converter<VisibilityConverter>
    {
        public Visibility True { get; set; }
        public Visibility False { get; set; }

        public override object Convert(object value, Type targetType, object parameter,CultureInfo culture)
        {
            var boolean = (bool)value;

            if (boolean)
                return True;
            else
                return False;
        }
    }
}
