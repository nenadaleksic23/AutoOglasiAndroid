using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AutoOglasiAndroid.Models;
using AutoOglasiAndroid.ViewModels;
using PolovniAutomobili;
using AutoOglasiAndroid.Helpers;
using System.Net.Http;
using System.Collections.ObjectModel;

namespace AutoOglasiAndroid
{
   
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
           
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
            else
            {
                //if (string.IsNullOrEmpty(Settings.UserName) && string.IsNullOrEmpty(Settings.Email) && Settings.UserID == 0)
                //{
                //    await Navigation.PushAsync(new NavigationPage(new LoginPage()));
                //}
                //else
                //{
                    AutomobiliModel  model = e.SelectedItem as AutomobiliModel;
                    await Navigation.PushAsync(new NavigationPage(new CarPage(model)));
                //}
               
            }

        }

    }
}
