using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoOglasiAndroid.ViewModels;
using PolovniAutomobili;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoOglasiAndroid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserCars : ContentPage
	{
		public UserCars ()
		{
			InitializeComponent ();
            BindingContext = new UserCarsViewModel();
		}



        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return;
            }
            else
            {
                AutomobiliModel model = e.SelectedItem as AutomobiliModel;
                await Navigation.PushAsync(new NavigationPage(new UserCarPage(model)));


            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new CreateCarPage()));
        }

       
    }
}