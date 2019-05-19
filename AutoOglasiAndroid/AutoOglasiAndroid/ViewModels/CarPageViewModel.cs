using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AutoOglasiAndroid.Helpers;
using PolovniAutomobili;
using AutoOglasiAndroid.Models;
using Xamarin.Forms;
using Android.Content.Res;

namespace AutoOglasiAndroid.ViewModels
{
    class CarPageViewModel
    {
        ApiHelper apiHelper = new ApiHelper();
        public AutomobiliModel automobiliModel { get; set; }
        public CarPageViewModel(AutomobiliModel model)
        {
            automobiliModel = model;
            GetComments();
        }
         

    private async void GetComments()
        {
            automobiliModel.KomentariZaAutomobil = new List<KomentariModel>();
            await apiHelper.GetCommentByCarIdAsync(automobiliModel.AutomobilID);
            automobiliModel.KomentariZaAutomobil = apiHelper.Komentari;
        }
        
    }
}
