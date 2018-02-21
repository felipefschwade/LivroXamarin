using CDCFoods.Dal;
using CDCFoods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiposItensCardapioListPage : ContentPage
    {
        private TipoItemCardapioDal dalTipoItemCardapio = new TipoItemCardapioDal();
        public TiposItensCardapioListPage()
        {
            InitializeComponent();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }

        public async void OnAlterarClick(object sender, EventArgs args)
        {
            var mi = (MenuItem)sender;
            var item = mi.CommandParameter as TipoItemCardapio;
            await Navigation.PushModalAsync(new TipoItensCardapioEditPage(item));
        }

        public async void OnRemoverClick(object sender, EventArgs args)
        {
            var mi = ((MenuItem)sender);
            var item = mi.CommandParameter as TipoItemCardapio;
            var confirma = await DisplayAlert("Confirmação de exclusão", $"Confirma excluir o item {item.Nome.ToUpper()} ?", "Sim", "Não");
            if (confirma)
            {
                dalTipoItemCardapio.DeleteById(item.Id);
                lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }

    }
}