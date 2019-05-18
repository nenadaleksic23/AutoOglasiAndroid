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
    public class MainPageViewModel : ActivityIndicator
    {
        ApiHelper apiHelper = new ApiHelper();
        public ObservableCollection<BrendAutomobilaModel> AllBrands { get; set; }
        public ObservableCollection<AutomobiliModel> automobiliModels { get; set; }
        public ObservableCollection<string> CarYears { get; set; }
        private BrendAutomobilaModel _SelectedBrand { get; set; }
        private string _SelectedYear { get; set; }
        public BrendAutomobilaModel SelectedBrand
        {
            get
            {
                return this._SelectedBrand;
            }
            set
            {
                this._SelectedBrand = value;
                OnPropertyChanged();
            }
        }
        public string SelectedYear
        {
            get
            {
                return this._SelectedYear;
            }
            set
            {
                this._SelectedYear = value;
                OnPropertyChanged();
            }
        } 


        public MainPageViewModel()
        {
            
            GetAllBrands();
            AddYearsToModel(1990);
            GetAllCars();
        }

        private async void GetAllBrands()
        {
           
            await apiHelper.GetAllBrandsAsync();
            AllBrands = apiHelper.CarBrands;
        }

        public void AddYearsToModel(float year)
        {
            CarYears = new ObservableCollection<string>();
            while(year <= DateTime.Now.Year)
            {
                CarYears.Add(year.ToString());
                year++;
            }

        }
        public async void GetAllCars()
        {
            automobiliModels = new ObservableCollection<AutomobiliModel>();
            await apiHelper.GetAllCarsAsync();
            automobiliModels = apiHelper.automobiliModels;
        }

        


        
    }
}
