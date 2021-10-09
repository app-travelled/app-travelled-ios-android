using app_travelled.ViewModels;
using app_travelled.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace app_travelled
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
