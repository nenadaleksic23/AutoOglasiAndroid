using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PolovniAutomobili;
using AutoOglasiAndroid.Helpers;
using AutoOglasiAndroid.Models;
using Xamarin.Forms;

namespace AutoOglasiAndroid.ViewModels
{
     class UserCarsViewModel:ActivityIndicator
     {
        public UserCarsViewModel()
        {
            GetCarsForUser();
        }
        ApiHelper ApiHelper = new ApiHelper();
        private ObservableCollection<AutomobiliModel> _automobili { get; set; }
        private Command _AddNewCarCommand;
        public Command AddNewCarCommand
        {
            get
            {
                return this._AddNewCarCommand = new Command(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new CreateCarPage());
                });
            }
        }
        public ObservableCollection<AutomobiliModel>automobili
        {
            get
            {
                return this._automobili;
            }
            set
            {
                this._automobili = value;
                OnPropertyChanged();
            }
        }

        private async void GetCarsForUser()
        {
            if(Settings.UserID == 0)
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage(string.Empty));
            }
            else
            {
                automobili = new ObservableCollection<AutomobiliModel>();
                await ApiHelper.GetCarsForUser(Settings.UserID);
                automobili = ApiHelper.CarsForUser;
            }
           
        }
    }
}
