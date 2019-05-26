using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoOglasiAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoOglasiAndroid.Models;

namespace AutoOglasiAndroid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CarPage : ContentPage
	{
		public CarPage (PolovniAutomobili.AutomobiliModel model)
		{
            //IsLoggedAsync();
			InitializeComponent ();
            BindingContext = new CarPageViewModel(model);
		}

        public async void IsLoggedAsync()
        {
            if (string.IsNullOrEmpty(Settings.UserName) && string.IsNullOrEmpty(Settings.Email) && Settings.UserID == 0)
            {
                await Navigation.PushAsync(new NavigationPage(new LoginPage(string.Empty)));
            }
        }
	}
}