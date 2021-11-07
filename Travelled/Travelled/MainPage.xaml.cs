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

        private void ButtonVisited_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Visited());
        }

        private void ButtonToVisit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Tovisit());
        }
    }
}
