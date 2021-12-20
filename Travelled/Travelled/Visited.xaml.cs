using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Travelled.DB;

namespace Travelled
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Visited : ContentPage
    {
        public Visited()
        {
            
            InitializeComponent();
        }

        private void ButtonUser_Clicked(object sender, EventArgs e)
        {
            UserRepository userRepository = new UserRepository();

            userRepository.findAllUsers();
        }
    }
}