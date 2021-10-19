using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Travelled
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage() 
        {

            InitializeComponent();
        }

        private async void Button_Plus_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new FlyoutPage1());
        }

    }
}
