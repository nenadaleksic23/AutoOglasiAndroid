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
    public class Employee
    {
        public string id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            //GetBrands();
            InitializeComponent();
            ApiHelper helper = new ApiHelper();
            helper.GetAllBrandsAsync();
            MainPageViewModel vm = new MainPageViewModel();
            vm.AllBrands = helper.CarBrands;
            BindingContext = vm;
            
        }
       
       



    }
}
