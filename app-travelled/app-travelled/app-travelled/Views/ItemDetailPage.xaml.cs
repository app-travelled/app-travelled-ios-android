using app_travelled.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace app_travelled.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}