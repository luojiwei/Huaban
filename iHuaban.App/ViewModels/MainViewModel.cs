﻿using iHuaban.App.Models;
using iHuaban.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iHuaban.Core;
using iHuaban.App.Services;

namespace iHuaban.App.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Menu> Menu { set; get; } = new ObservableCollection<Menu>
        {
            new Menu
            {
                Title = Constants.MenuPhone,
                Icon = "\uE8EA",
                Template = Constants.TemplateGrid,
                PinMinWidth = 236,
                ScaleSize = "750:1334",
                ItemTemplateName = Constants.TemplatePhone,
                ViewModel = new PinListViewModel(new BoardService(Constants.ApiPhoneBoard))
            },
            new Menu
            {
                Title = Constants.MenuPC,
                Icon = "\uE770",
                Template = Constants.TemplateGrid,
                PinMinWidth = 360,
                ScaleSize = "1920:1080",
                ItemTemplateName = Constants.TemplatePC,
                ViewModel = new PinListViewModel(new BoardService(Constants.ApiPCBoard))
            },
            new Menu
            {
                Title = Constants.MenuFind,
                Icon = "\uE721",
                Template = Constants.TemplateFind,
                ViewModel = new SearchViewModel()
            },
            new Menu
            {
                Title = Constants.MenuMine,
                Icon = "\uE77B",
                Template = Constants.TemplateMine,
                ViewModel = new MineViewModel()
            }
        };
    }
}