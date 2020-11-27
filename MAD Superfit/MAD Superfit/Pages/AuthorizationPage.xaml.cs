using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAD_Superfit.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPage : ContentPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }


        public UserInfo User = new UserInfo() { };


        private async void SignIn(object sender, EventArgs e)
        {
            User.Email = EntryEmail.Text;


            ///User.Valitation(out string result)
            
            if (EntryEmail.Text.Contains("@"))
            {
                await Navigation.PushModalAsync(new AuthorizationPasswrordPage(User));

            }
            else
            {
                await DisplayAlert("Email incorrect", "Need symbol '@'", "Ok");
            }
        }

        private void SignUp(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new RegistrationPage(User));
        }

    }
}