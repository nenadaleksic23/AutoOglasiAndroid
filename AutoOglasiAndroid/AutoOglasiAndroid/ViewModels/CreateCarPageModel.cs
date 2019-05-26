using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using PolovniAutomobili;
using AutoOglasiAndroid.Helpers;
using Xamarin.Forms;
using AutoOglasiAndroid.Models;
using System.Linq;

namespace AutoOglasiAndroid.ViewModels
{
    public class CreateCarPageModel :ActivityIndicator
    {

        public string Godiste { get; set; }
        public string Opis { get; set; }
        public int KorisnikID { get; set; }
        public string SnagaMotora { get; set; }
        public string Kubikaza { get; set; }
        public string SlikaAutomobila { get; set; }
        public int BrendAutomobilaID { get; set; }
        public string NazivAutomobila { get; set; }

        ApiHelper ApiHelper = new ApiHelper();
        public ObservableCollection<BrendAutomobilaModel> CarBrands { get; set; }
        public BrendAutomobilaModel ChosenBrand { get; set; }
        public string SelectedBrand = string.Empty;
        private Command _AddNewCarCommand;


        public CreateCarPageModel()
        {
            GetAllBrands();
            CarModel = new AutomobiliModel();
        }
        private AutomobiliModel _carModel { get; set; }

        public Command AddNewCarCommand
        {
            get {
                return _AddNewCarCommand = new Command(() =>
                {
                    insertCar();
                    Application.Current.MainPage = new UserCars();
                });
            }
        }
       public AutomobiliModel CarModel
        {
            get
            {
                return this._carModel;
            }
            set
            {
                this._carModel = value;
                OnPropertyChanged();
            }
        }

        private async void GetAllBrands()
        {
            CarBrands = new ObservableCollection<BrendAutomobilaModel>();
            await ApiHelper.GetAllBrandsAsync();
            CarBrands = ApiHelper.CarBrands;
        }
        private async void insertCar()
        {          
            CarModel.BrendAutomobilaID = CarBrands.Where(m => m.NazivBrenda == SelectedBrand).Select(m => m.BrendID).FirstOrDefault();
            CarModel.KorisnikID = Settings.UserID;
            CarModel.Godiste = Godiste;
            CarModel.SnagaMotora = double.Parse(SnagaMotora);
            CarModel.SlikaAutomobila = SelectedBrand + ".jpg";
            CarModel.Kubikaza = double.Parse(Kubikaza);
            CarModel.SnagaMotora = double.Parse(SnagaMotora);
            CarModel.NazivAutomobila = NazivAutomobila;
            CarModel.Opis = Opis;
            string x = await ApiHelper.InsertCar(CarModel);
            if(x == "OK")
            {
                Application.Current.MainPage = new MainPage();
            }

        }
    }
}
