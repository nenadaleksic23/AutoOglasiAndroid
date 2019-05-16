using AutoOglasiAndroid.Helpers;
using PolovniAutomobili;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AutoOglasiAndroid.ViewModels
{
    public class RegisterPageViewModel : ActivityIndicator
    {
        public string Message { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserModel user;
        private Command _RegisterUserCommand;
        private Command _TransferToLogin;


       
        public Command RegisterUserCommand
        {
            get
            {
                return _RegisterUserCommand = new Command(() =>
                {
                    RegisterUser();
                });
            }
        }

        public Command TransferToLogin
        {
            get
            {
                return _TransferToLogin = new Command(() =>
                {
                    Application.Current.MainPage = new LoginPage();
                });
            }
        }

        private void RegisterUser()
        {
            IsBusy = true;
            user = new UserModel();
            user.ImePrezime = FullName;
            user.Email = Email;
            user.Password = Password;
            ApiHelper apiHelper = new ApiHelper();
            apiHelper.RegisterUserAsync(user);
            if(apiHelper.UserModel.Message != "OK")
            {
                Message = apiHelper.UserModel.Message;
            }
            IsBusy = false;

        }




    }
}
