using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Share;
using System.Diagnostics;

namespace Travelled
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Tovisit : ContentPage
    {
        public Tovisit()
        {
            InitializeComponent();
        }
        private void ShareButtonClicked(object sender, EventArgs e)
        {
            CrossShare.Current.OpenBrowser("https://github.com/app-travelled/app-travelled-ios-android");
        }

        private void CreditsButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreditsPage());
        }
        async void OnActionSheetSimpleClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Share Travelled with your family and friends!", "Cancel", null, "Email", "Twitter", "Facebook");
            Debug.WriteLine("Action: " + action);
        }
        async void FeelLuckyClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("ActionSheet: Send to?", "Cancel", null, "Email", "Twitter", "Facebook");
            Debug.WriteLine("Action: " + action);
        }

        async void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            App.IsUserLoggedIn = false;
            Navigation.InsertPageBefore(new LoginPageCS(), this);
            await Navigation.PopAsync();
        }
    }

}