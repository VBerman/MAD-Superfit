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
    public partial class RegistrationPage : ContentPage
    {
        public UserInfo User;

        public RegistrationPage(UserInfo user)
        {
            User = user;
            InitializeComponent();
        }

        private async void SignUp(object sender, EventArgs e)
        {
            User.Email = Email.Text;
            User.Password = Code.Text;
            User.RepeatPassword = RepeatCode.Text;
            
            if (User.Validation(out string stringResult))
            {
                await Navigation.PushModalAsync(new MainScreenPage());
            }
            else
            {
                await DisplayAlert("Error", stringResult, "Ok");
            }

        }

        private void SignIn(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}