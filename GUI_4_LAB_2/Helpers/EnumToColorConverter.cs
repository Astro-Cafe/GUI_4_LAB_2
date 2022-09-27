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
            string content = value as string;
            if (content == "evil")
            {
                return Brushes.PaleVioletRed;
            }
            else if (content == "neutral")
            {
                return Brushes.LightYellow;
            }
            else if (content == "good")
            {
                return Brushes.LightGreen;
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
