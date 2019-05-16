using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PolovniAutomobili;
using Xamarin.Forms;
using AutoOglasiAndroid.Helpers;

namespace AutoOglasiAndroid.ViewModels
{
    public class LoginPageViewModel:ActivityIndicator,INotifyPropertyChanged
    {
        private string _Message { get; set; }
        
        private string _UserName;
        private string _Password;
        private Command _LoginCommand;
        private Command _TransferToRegisterPage;
        public UserModel userModel { get; set; }

        public string Message
        {
            get
            {
                return this._Message;
            }
            set
            {
                this._Message = value;
                OnPropertyChanged();
            }
        }
        public string Username
        {
            get
            {
                return this._UserName;
            }
            set
            {
                this._UserName = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                this._Password = value;
                OnPropertyChanged();
            }
        }
        public Command LoginCommand
        {
            get
            {
                return _LoginCommand = new Command(() =>
                {
                    LoginUser();
                });
            }
        }
        public Command TransferToRegisterPage
        {
            get
            {
                return _TransferToRegisterPage = new Command(() =>
                {                    
                    Application.Current.MainPage = new RegiserPage();
                });
            }
        }

        private async void LoginUser()
        {
            this.IsBusy = true;
            ApiHelper apiHelper = new ApiHelper();
            await apiHelper.LoginUserAsync(this.Username, this.Password);
            userModel =  apiHelper.UserModel;
            if(userModel.Message != "OK")
            {
                this.Message = userModel.Message;
            }
           
        }

        //public event PropertyChangedEventHandler PropertyChanged;

        //void OnPropertyChanged([CallerMemberName] string Name = "")
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        //}
    }
}
