using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
<<<<<<< HEAD
using Windows.UI.Xaml.Automation;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml;
using Windows.Foundation;
=======
>>>>>>> 796b2574da21a838fdd9a20b5fdef5d40233aa96

namespace Huaban.UWP.Controls
{
	using Huaban.UWP.Base;

	public class HBPage : Page
	{
		public HBPage()
		{
			ViewModel = (ViewModelBase)ControlHelper.GetViewModel(this.GetType());
			this.Loaded += (s, e) =>
			{
				if (!ViewModel.IsInited)
					ViewModel.Inited();
			};
		}
		public ViewModelBase ViewModel
		{
			private set
			{
				this.DataContext = value;
			}
			get
			{
				return this.DataContext as ViewModelBase;
			}
		}
		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);
			ViewModel?.OnNavigatedFrom(HBNavigationEventArgs.Convert(e));
		}
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);
			ViewModel?.OnNavigatedTo(HBNavigationEventArgs.Convert(e));
		}
		protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
		{
			base.OnNavigatingFrom(e);
			ViewModel?.OnNavigatingFrom(HBNavigatingCancelEventArgs.Convert(e));
		}
		protected override Size ArrangeOverride(Size finalSize)
		{
			ViewModel?.ArrangeOverride(finalSize);
			return base.ArrangeOverride(finalSize);
		}
	}
}
