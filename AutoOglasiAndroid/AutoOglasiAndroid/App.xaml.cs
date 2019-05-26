using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AutoOglasiAndroid.Models;


[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AutoOglasiAndroid
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if(Settings.UserID == 0)
            {
                MainPage = new NavigationPage(new LoginPage(string.Empty));
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
           
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
