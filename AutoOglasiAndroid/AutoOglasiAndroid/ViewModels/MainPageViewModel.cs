using AutoOglasiAndroid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PolovniAutomobili;
using AutoOglasiAndroid.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;


namespace AutoOglasiAndroid.ViewModels
{
    public class MainPageViewModel : ActivityIndicator
    {
        ApiHelper apiHelper = new ApiHelper();
        public ObservableCollection<BrendAutomobilaModel> AllBrands { get; set; }
        private ObservableCollection<AutomobiliModel> _automobiliModels { get; set; }
        public ObservableCollection<string> CarYears { get; set; }
        private AutomobiliModel _SelectedCar { get; set; }
        private string _SelectedYear { get; set; }
        private Command _FitlerData;
        private Command _GoToUsePageCommand;

        private string _SelectedBrand { get; set; }

        public ObservableCollection<AutomobiliModel> automobiliModels {
            get
            {
                return this._automobiliModels;
            }
            set
            {
                this._automobiliModels = value;
                OnPropertyChanged();
            }
        }

        public string SelectedBrand
        {
            get
            {
                if (_SelectedBrand == null)
                    _SelectedBrand = "";
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
                if (_SelectedYear == null)
                    _SelectedYear = "";
                return this._SelectedYear;
            }
            set
            {
                this._SelectedYear = value;
                OnPropertyChanged();
            }
        }
        public Command FilterData
        {
            get
            {
                return this._FitlerData = new Command(() =>
                {
                    FilterCarsByCriteria();
                });
            }
        }
        public Command GoToUsePageCommand
        {
            get
            {
                return this._GoToUsePageCommand = new Command(() =>
                {
                    Application.Current.MainPage = new NavigationPage(new UserCars());
                });
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
        private async void GetAllCars()
        {
            automobiliModels = new ObservableCollection<AutomobiliModel>();
            await apiHelper.GetAllCarsAsync();
            automobiliModels = apiHelper.automobiliModels;
        }

        private async void FilterCarsByCriteria()
        {
            await apiHelper.GetCarByCriteria(SelectedBrand,SelectedYear);
            automobiliModels = apiHelper.automobiliModels;
        }
        





    }
}
