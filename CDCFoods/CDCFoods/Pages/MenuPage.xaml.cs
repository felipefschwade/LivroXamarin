using CDCFoods.Pages.Entregadores;
using CDCFoods.Pages.Garcons;
using CDCFoods.Pages.ItensCardapio;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private async void Garcons_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GarconsPage());
        }

        private async void Entregadores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntregadoresPage());
        }

        private async void TiposItensCardapio_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TiposItensCardapioPage());
        }
    }
}