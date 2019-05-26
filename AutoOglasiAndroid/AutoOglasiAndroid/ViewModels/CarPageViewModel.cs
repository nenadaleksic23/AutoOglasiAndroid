using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using AutoOglasiAndroid.Helpers;
using PolovniAutomobili;
using AutoOglasiAndroid.Models;
using Xamarin.Forms;
using Android.Content.Res;
using System.Threading.Tasks;

namespace AutoOglasiAndroid.ViewModels
{
    public class CarPageViewModel : ActivityIndicator
    {
        ApiHelper apiHelper = new ApiHelper();
        private string _HaveComments { get; set; }
        private ObservableCollection<KomentariModel> _Komentari { get; set; }
        public AutomobiliModel automobiliModel { get; set; }
        private Command _InsertCommentCommand;
        private string _WrittenComment { get; set; }
        public Command InsertCommentCommand
        {
            get
            {
                return this._InsertCommentCommand = new Command(() =>
                {
                    InsertComment();
                });
            }
        }

        public string WrittenComment
        {
            get
            {
                return this._WrittenComment;
            }
            set
            {
                this._WrittenComment = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<KomentariModel> Komentari
        {
            get
            {
                return this._Komentari;
            }
            set
            {
                this._Komentari = value;
                OnPropertyChanged();
            }
        }

        public string HaveComments
        {
            get
            {
                return this._HaveComments;
            }
            set
            {
                this._HaveComments = value;
                OnPropertyChanged();
            }
        }
        public CarPageViewModel(AutomobiliModel model)
        {
            automobiliModel = model;
            GetComments(automobiliModel.AutomobilID);
        }
         

    protected async void GetComments(int id)
        {
            automobiliModel.KomentariZaAutomobil = new List<KomentariModel>();
            await apiHelper.GetCommentByCarIdAsync(id);
            Komentari = apiHelper.Komentari;
            if(Komentari.Count == 0)
            {
                HaveComments = "There is no comments for this car!";
            }
            else
            {
                HaveComments = string.Empty;
            }
        }

        protected async void InsertComment()
        {
            Settings.UserID = 1;
            if(Settings.UserID == 0)
            {               
                return;
            }            
            KomentariModel model = new KomentariModel();
            model.KorisnikID = Settings.UserID;
            model.AutomobilID = automobiliModel.AutomobilID;
            model.Komentar = WrittenComment;
            string response= await apiHelper.InsertComment(model);
            if(response == "OK")
            {
                Komentari.Add(model);
            }
        }

    }
}
