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
        MainPageViewModel VM = new MainPageViewModel();
        public MainPage()
        {
           
            InitializeComponent();
            BindingContext = VM;
            
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null)
            {
                return;
            }
            else
            {
                    AutomobiliModel  model = e.SelectedItem as AutomobiliModel;
                    await Navigation.PushAsync(new NavigationPage(new CarPage(model)));

            }

        }

        private void Picker_SelectedIndexChangedBrands(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                VM.SelectedBrand = picker.Items[selectedIndex];
            }
        }

        private void Picker_SelectedIndexChangedYears(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                VM.SelectedYear = picker.Items[selectedIndex];
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new UserCars()));

        }
    }
}
