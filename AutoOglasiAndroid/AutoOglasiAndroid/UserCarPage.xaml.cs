using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoOglasiAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PolovniAutomobili;

namespace AutoOglasiAndroid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserCarPage : ContentPage
	{
		public UserCarPage (AutomobiliModel model)
		{
			InitializeComponent ();
            BindingContext = new UserCarPageViewModel(model);
		}
	}
}