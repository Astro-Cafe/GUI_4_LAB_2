﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GUI_4_LAB_2.Helpers
{
	public class EnumToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return false;
			}
			return value.Equals(parameter);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value == null)
			{
				return false;
			}
			return value.Equals(parameter);
		}
	}
}
