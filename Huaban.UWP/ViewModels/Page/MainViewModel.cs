using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.Foundation;

namespace Huaban.UWP.ViewModels
{
	using Base;
	using Services;
	using Models;
	using Commands;
	using Views;

	public class MainViewModel : HBViewModel
	{
		public MainViewModel(Context context)
			: base(context)
		{
			SelectedMenu = MenuList[0];
		}

		public List<MenuItem> MenuList { set; get; } = new List<MenuItem>
		{
			new MenuItem { Title = "发现", Icon = "\xE11A", TemplateName = "FindTemplate" },
			new MenuItem { Title = "关注", Icon = "\xEB51", TemplateName = "FollowingTemplate" },
			new MenuItem { Title = "消息", Icon = "\xEA8F", TemplateName = "MessageTemplate" },
			new MenuItem { Title = "我的", Icon = "\xE77B", TemplateName = "MineTemplate" },
		};

		public List<MenuItem> FootMenuList { set; get; } = new List<MenuItem>
		{
			new MenuItem { Title = "关于", Icon = "\xE11A" },
			new MenuItem { Title = "设置", Icon = "\xEB51" },
		};

		private MenuItem _SelectedMenu;
		public MenuItem SelectedMenu
		{
			get { return _SelectedMenu; }
			set { SetValue(ref _SelectedMenu, value); }
		}

		public string AppDisplayName { get; } = Windows.ApplicationModel.Package.Current.DisplayName;

		public override Size ArrangeOverride(Size finalSize)
		{
			var width = finalSize.Width;
			var itemWidth = (width - 12) / (MenuList.Count + 1);
			foreach (var item in MenuList)
			{
				item.Width = itemWidth;
			}
			return base.ArrangeOverride(finalSize);
		}
	}
}
