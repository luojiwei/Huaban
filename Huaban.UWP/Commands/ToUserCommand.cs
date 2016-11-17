﻿using System;
using System.Windows.Input;

namespace Huaban.UWP.Commands
{
	public class ToUserCommand : ICommand
	{
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			App.AppContext.NavigationService.NavigateTo("User", parameter);
		}
	}
}
