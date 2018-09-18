﻿using iHuaban.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace iHuaban.App.Models
{
    public class Menu
    {
        public string Title { set; get; }
        public string Icon { set; get; }
        public string Template { set; get; }
        public double PinMinWidth { set; get; }
        public string ScaleSize { set; get; }
        public string ItemTemplateName { set; get; }
        public ViewModelBase ViewModel { set; get; }
        public DataTemplate ItemTemplate=> (DataTemplate)Application.Current.Resources[ItemTemplateName];
    }
}