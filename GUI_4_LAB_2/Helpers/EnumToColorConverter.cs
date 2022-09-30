using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GUI_4_LAB_2.Helpers
{
    public class EnumToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string content = value.ToString();

            if (content == "evil")
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b60a1c"));
            }
            else if (content == "neutral")
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f7d202"));
            }
            else if (content == "good")
            {
                return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#309143"));
            }
            else
            {
                return Binding.DoNothing;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
