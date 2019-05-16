using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoOglasiAndroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AutoOglasiAndroid
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegiserPage : ContentPage
	{
		public RegiserPage ()
		{
			InitializeComponent ();
            BindingContext = new RegisterPageViewModel(); 
		}
	}
}