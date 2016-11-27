using Windows.UI;
using Windows.Foundation.Metadata;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.Foundation;

namespace Huaban.UWP.Views
{
	using Controls;
	public sealed partial class MainView : HBPage
	{
		public MainView()
		{
			this.InitializeComponent();
			InitLayout();
			Window.Current.SizeChanged += (s, e) =>
			{
				InitLayout();
			};
		}

		private void InitLayout()
		{
			var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
			if (UIViewSettings.GetForCurrentView().UserInteractionMode == UserInteractionMode.Mouse)
			{
				
				coreTitleBar.ExtendViewIntoTitleBar = true;
				Window.Current.SetTitleBar(ExtTitleBar);

				var titleBar = ApplicationView.GetForCurrentView().TitleBar;

				titleBar.BackgroundColor = Colors.Transparent;
				titleBar.ButtonBackgroundColor = Colors.Transparent;
				titleBar.ButtonForegroundColor = Colors.Transparent;
				titleBar.ButtonHoverBackgroundColor = Color.FromArgb(122, 0, 0, 0);
				titleBar.ButtonHoverForegroundColor = Colors.Transparent;
				titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
				titleBar.ButtonInactiveForegroundColor = Colors.Transparent;
				titleBar.ButtonPressedBackgroundColor = Colors.Transparent;
				titleBar.ButtonPressedForegroundColor = Colors.Transparent;
				titleBar.ForegroundColor = Colors.Transparent;
				titleBar.InactiveBackgroundColor = Colors.Transparent;
				titleBar.InactiveForegroundColor = Colors.Transparent;

				ExtTitleBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
			}
			else
			{
				ExtTitleBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
				coreTitleBar.ExtendViewIntoTitleBar = false;
			}
		}

	}
}
