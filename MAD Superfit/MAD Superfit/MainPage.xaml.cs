using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MAD_Superfit
{

    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Recipe> Recipes { get; set; } = new ObservableCollection<Recipe>();
        public String ChoosedFilter { get; set; } = "balanced";
        CancellationTokenSource Source;


        public MainPage()
        {

            InitializeComponent();
            Appearing += MainPage_Appearing;
            //MainPage_Appearing(null, null);

        }

        public void UnfocusButton()
        {

            HighProtein.BackgroundColor = Color.FromHex("#B461F5");
            HighFiber.BackgroundColor = Color.FromHex("#B461F5");
            Balanced.BackgroundColor = Color.FromHex("#B461F5");
            HighProtein.TextColor = Color.White;
            HighFiber.TextColor = Color.White;
            Balanced.TextColor = Color.White;

        }

        private async void MainPage_Appearing(object sender, EventArgs e)
        {
            if (Source != null)
            {
                Source.Cancel();
            }
            Source = new CancellationTokenSource();

            Recipes.Clear();

            await LoadRecipes($"https://api.edamam.com/search?q={FindString.Text}&app_id={App.AppId}&app_key={App.AppKey}&diet={ChoosedFilter}");
        }

        private async Task LoadRecipes(String stringRequest)
        {
            try
            {
                AI.IsRunning = true;
                var request = await App.http.GetAsync(stringRequest, Source.Token);

                if (request.IsSuccessStatusCode)
                {
                    var apiRequest = JsonConvert.DeserializeObject<Request>(await request.Content.ReadAsStringAsync());

                    foreach (var item in apiRequest.hits)
                    {
                        Recipes.Add(item.recipe);
                    }
                }
                else
                {
                    await DisplayAlert("API error", $"Code: {request.StatusCode}\nMessage: {JsonConvert.DeserializeObject(await request.Content.ReadAsStringAsync())}", "Ok");
                }
            }
            catch (Exception)
            {

            }
            //ActivityIndicator
            AI.IsRunning = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            UnfocusButton();
            var button = sender as Button;
            if (button != null)
            {


                ChoosedFilter = button.Text.ToLower();
                button.BackgroundColor = Color.White;
                button.TextColor = Color.FromHex("#B461F5");
                MainPage_Appearing(null, null);
            }
        }

        private void FindString_TextChanged(object sender, TextChangedEventArgs e)
        {
            MainPage_Appearing(null, null);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            Navigation.PushModalAsync(new ReceipePage(((sender as Grid).BindingContext as Recipe)));   
        }
    }
}
