using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAD_Superfit.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPasswrordPage : ContentPage
    {
        public AuthorizationPasswrordPage()
        {
            InitializeComponent();
        }

        private void Back(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}