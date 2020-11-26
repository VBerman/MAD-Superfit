using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAD_Superfit
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReceipePage : ContentPage
    {
        public Recipe Recipe { get; set; }

        public ReceipePage(Recipe recipe)
        {
            Recipe = recipe;
            OnPropertyChanged(nameof(Recipe));
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}