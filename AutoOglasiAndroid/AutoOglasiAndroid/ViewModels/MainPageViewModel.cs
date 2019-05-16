using AutoOglasiAndroid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PolovniAutomobili;
using AutoOglasiAndroid.Helpers;
using System.Threading.Tasks;

namespace AutoOglasiAndroid.ViewModels
{
    public class MainPageViewModel
    {
        public ObservableCollection<BrendAutomobilaModel> AllBrands { get; set; }
        List<BrendAutomobilaModel> Brands { get; set; }
        public MainPageViewModel()
        {
            AllBrands = new ObservableCollection<BrendAutomobilaModel>();
           
        }
        


        
    }
}
