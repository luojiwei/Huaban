using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huaban.UWP.Models
{
	using Base;
	public class MenuItem : ObservableObject
	{
		private string _Title;
		public string Title
		{
			get { return _Title; }
			set { SetValue(ref _Title, value); }
		}

		public string Icon { set; get; }

		public string TemplateName { set; get; }

		private bool _Authorization;
		public bool Authorization
		{
			get { return _Authorization; }
			set { SetValue(ref _Authorization, value); }
		}
		private double _Width;
		public double Width
		{
			get { return _Width; }
			set { SetValue(ref _Width, value); }
		}
	}
}
