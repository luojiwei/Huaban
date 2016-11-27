﻿using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using ImageLib;
using ImageLib.Cache.Storage;
using ImageLib.Gif;

namespace Huaban.UWP
{
	using Base;
	using Services;
	using Models;

	sealed partial class App : Application
	{
		public static Context AppContext { private set; get; } = new Context();

		public App()
		{
			this.InitializeComponent();
			this.InitLocator();
			this.Suspending += OnSuspending;
<<<<<<< HEAD

			ImageLoader.Initialize(new ImageConfig.Builder()
			{
				
				MemoryCacheImpl = new LRUMemoryCache(),
				StorageCacheImpl = new LimitedStorageCache(ApplicationData.Current.LocalCacheFolder,
				"cache", new SHA1CacheGenerator(), 1024 * 1024 * 1024)
			}.AddDecoder<GifDecoder>().Build(), true);

=======
>>>>>>> 796b2574da21a838fdd9a20b5fdef5d40233aa96
		}
		private void InitLocator()
		{
			ServiceLocator.BuildLocator();
			ServiceLocator.RegisterInstance(AppContext);
            var config = new ImageConfig.Builder()
                .LimitedStorageCache(ApplicationData.Current.LocalCacheFolder, "cache", new SHA1CacheGenerator(), 1024 * 1024 * 1024)
                .NewApi(false)
                .AddDecoder<GifDecoder>()
                .Build();
            ImageLoader.Initialize(config);
        }

		//加载数据
		private async Task LoadData()
		{
			var user = await StorageHelper.ReadLocal(o => SerializeExtension.JsonDeserlialize<User>(o));
			var token = await StorageHelper.ReadLocal(o => SerializeExtension.JsonDeserlialize<AuthToken>(o));
			if (token != null)
			{
				token = await AppContext.API.OAuthorAPI.RefreshToken(token);
			}

			AppContext.User = user;
			if (token != null && token.ExpiresIn > DateTime.Now)
			{
				await AppContext.SetToken(token);
			}
		}

		protected async override void OnLaunched(LaunchActivatedEventArgs e)
		{
			await LoadData();

			Frame rootFrame = Window.Current.Content as Frame;
			if (rootFrame == null)
			{
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					//TODO: 从之前挂起的应用程序加载状态
				}

				// 将框架放在当前窗口中
				Window.Current.Content = rootFrame;
			}

			if (e.PrelaunchActivated == false)
			{
				if (rootFrame.Content == null)
				{
<<<<<<< HEAD
					
					rootFrame.Navigate(typeof(Views.MainView), e.Arguments);
=======
					rootFrame.Navigate(typeof(Views.ShellView), e.Arguments);
>>>>>>> 796b2574da21a838fdd9a20b5fdef5d40233aa96
				}
				
				Window.Current.Activate();
			}
		}

		/// <summary>
		/// 导航到特定页失败时调用
		/// </summary>
		///<param name="sender">导航失败的框架</param>
		///<param name="e">有关导航失败的详细信息</param>
		void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
		{
			throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
		}

		/// <summary>
		/// 在将要挂起应用程序执行时调用。  在不知道应用程序
		/// 无需知道应用程序会被终止还是会恢复，
		/// 并让内存内容保持不变。
		/// </summary>
		/// <param name="sender">挂起的请求的源。</param>
		/// <param name="e">有关挂起请求的详细信息。</param>
		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: 保存应用程序状态并停止任何后台活动
			deferral.Complete();
		}
	}
}
