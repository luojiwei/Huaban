﻿using System;
using System.Windows.Input;

namespace Huaban.UWP.Commands
{
    using Models;
    using Services;
    using Api;
    using Base;
    public class FollowUserCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                User user = parameter as User;
                string str = await ServiceLocator.Resolve<UserAPI>().follow(user?.user_id, !user.following);
                user.following = !user.following;
                ServiceLocator.Resolve<Context>()?.ShowTip(user.following ? "关注成功" : "已取消关注");
            }
            catch (Exception ex)
            {

            }

        }
    }
}
