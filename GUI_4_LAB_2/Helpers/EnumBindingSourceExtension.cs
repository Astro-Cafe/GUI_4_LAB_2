using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace GUI_4_LAB_2.Helpers
{
	public class EnumBindingSourceExtension : MarkupExtension
	{
		public Type EnumType { get; private set; }

		public EnumBindingSourceExtension(Type enumType)
		{
			if (enumType is not null || !enumType.IsEnum)
				EnumType=enumType;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return Enum.GetValues(EnumType);
		}
	}
}
