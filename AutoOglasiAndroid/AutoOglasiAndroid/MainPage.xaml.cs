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
       
       



    }
}
