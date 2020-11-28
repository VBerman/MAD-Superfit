using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace MAD_Superfit.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorizationPasswrordPage : ContentPage
    {
        public UserInfo User { get; set; }
        public ObservableCollection<Button> Buttons { get; set; } = new ObservableCollection<Button>();
        public AuthorizationPasswrordPage(UserInfo user)
        {
            User = user;

            for (int i = 0; i < 9; i++)
            {
                var button = new Button();
                button.Text = (i + 1).ToString();
                button.Clicked += Button_Clicked;
                Buttons.Add(button);
            }
            User.Password = "";

            InitializeComponent();

        }
        private void Back(object sender, EventArgs e)
        {

            Navigation.PopModalAsync();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {

            User.Password += (sender as Button)?.Text;
            if (User.Password.Length == 4)
            {
                if (await ApiWorker.Auth(User))
                {
                    await Navigation.PushModalAsync(new MainScreenPage());
                }
                else
                {
                    await DisplayAlert("Error", "Password or email incorrect", "Ok");
                    await Navigation.PopModalAsync();
                }
                User.Password = "";
            }
            else
            {
                var numberRandom = new Random();
                for (int i = 0; i < 10; i++)
                {
                    Buttons.Move(numberRandom.Next(0, 9), numberRandom.Next(0, 9));
                }
            }

        }

    }
}