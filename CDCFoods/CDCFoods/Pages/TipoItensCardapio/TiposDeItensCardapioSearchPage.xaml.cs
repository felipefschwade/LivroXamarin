using CDCFoods.Dal;
using CDCFoods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.TipoItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TiposDeItensCardapioSearchPage : ContentPage
    {
        private TipoItemCardapioDal dalTipoItemCardapio = new TipoItemCardapioDal();
        private Label DisplayValue;
        private Label KeyValue;
        private IEnumerable<TipoItemCardapio> itens;

        public TiposDeItensCardapioSearchPage(Label keyValue, Label displayValue)
        {
            InitializeComponent();
            itens = dalTipoItemCardapio.GetAll();
            KeyValue = keyValue;
            DisplayValue = displayValue;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            lvTipos.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue)) lvTipos.ItemsSource = itens;
            else lvTipos.ItemsSource = itens.Where(i => i.Nome.Contains(e.NewTextValue));
            lvTipos.EndRefresh();
        }

        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as TipoItemCardapio;
            KeyValue.Text = item.Id.ToString();
            DisplayValue.Text = item.Nome.ToString();
            await Navigation.PopAsync();
        }
    }
}