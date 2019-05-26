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
	public partial class CreateCarPage : ContentPage
	{
        CreateCarPageModel vm = new CreateCarPageModel();
        public CreateCarPage ()
		{
            
			InitializeComponent ();
            BindingContext = vm;
            
		}

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                vm.SelectedBrand = picker.Items[selectedIndex];
            }
        }
    }
}