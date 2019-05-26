using PolovniAutomobili;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AutoOglasiAndroid.Helpers;

namespace AutoOglasiAndroid.ViewModels
{
    class UserCarPageViewModel : CarPageViewModel
    {
        public List<AutomobiliModel> AutomobiliModels { get; set; }
        public AutomobiliModel modelCar { get; set; }
        private Command _DeleteCar;
        public Command DeleteCar
        {
            get
            {
                return this._DeleteCar = new Command(() =>
                {
                    DeleteCarMethod();
                });
            }
        }
        public UserCarPageViewModel(PolovniAutomobili.AutomobiliModel model) : base(model)
        {
            this.modelCar = model;
            base.GetComments(model.AutomobilID);
           

        }

        private async void DeleteCarMethod()
        {
            ApiHelper apiHelper = new ApiHelper();
            string res = await apiHelper.DeleteCarAsync(modelCar.AutomobilID);
            if (res == "OK")
            {
                Application.Current.MainPage = new NavigationPage(new UserCars());
            }
        }
        
        
    }
}
