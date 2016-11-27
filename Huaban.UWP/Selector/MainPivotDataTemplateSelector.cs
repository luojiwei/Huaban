using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;

namespace Huaban.UWP.Selectors
{
	using Models;
	public class MainPivotDataTemplateSelector : DataTemplateSelector
	{
		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
		{
			var dataItem = item as MenuItem;
			if (dataItem == null || App.Current.Resources?.MergedDictionaries?.Count < 2)
			{
				return base.SelectTemplateCore(item, container);
			}
			if (App.Current.Resources.MergedDictionaries.Count == 3)
			{
				var resource = App.Current.Resources.MergedDictionaries[1];
				if (resource.ContainsKey(dataItem.TemplateName))
				{
					return resource[dataItem.TemplateName] as DataTemplate;
				}

			}
			return base.SelectTemplateCore(item, container);
		}
	}
}
