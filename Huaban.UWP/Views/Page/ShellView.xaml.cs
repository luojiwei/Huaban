﻿using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;

namespace Huaban.UWP.Views
{
	using Controls;
	using Services;
	using Base;
	public sealed partial class ShellView : HBPage
	{
		public ShellView()
		{
			this.InitializeComponent();
			Current = this;

			this.Loaded += (s, e) =>
			{
				InitLayout();
			};
			var context = ServiceLocator.Resolve<Context>();
			if (context != null)
			{
				context.NavigationService.SetFrame(MainFrame, DetailFrame);
			}

		}
		public static ShellView Current { private set; get; }

<<<<<<< HEAD
		private void InitImageLoader()
		{
			
		}

=======
>>>>>>> 796b2574da21a838fdd9a20b5fdef5d40233aa96
		private void InitLayout()
		{
			if (!ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons"))
			{
				var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
				coreTitleBar.ExtendViewIntoTitleBar = true;

				var titleBar = ApplicationView.GetForCurrentView().TitleBar;

				titleBar.BackgroundColor = Colors.Transparent;
				titleBar.ButtonBackgroundColor = Colors.Transparent;
				titleBar.ButtonForegroundColor = Colors.White;
				titleBar.ButtonHoverBackgroundColor = Color.FromArgb(122, 0, 0, 0);
				titleBar.ButtonHoverForegroundColor = Colors.White;
				titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
				titleBar.ButtonInactiveForegroundColor = Colors.White;
				titleBar.ButtonPressedBackgroundColor = Colors.Transparent;
				titleBar.ButtonPressedForegroundColor = Colors.White;
				titleBar.ForegroundColor = Colors.White;
				titleBar.InactiveBackgroundColor = Colors.Transparent;
				titleBar.InactiveForegroundColor = Colors.White;
			}
			else
			{
				ExtTitleBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
			}
		}
	}
}
