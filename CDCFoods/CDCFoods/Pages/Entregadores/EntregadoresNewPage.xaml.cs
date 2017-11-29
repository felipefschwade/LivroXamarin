using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.Entregadores
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EntregadoresNewPage : ContentPage
    {
        public EntregadoresNewPage()
        {
            InitializeComponent();
        }

        private async void BtnGravarClick(object sender, EventArgs e)
        {
            await DisplayAlert("Aa", "aa", "Ok");
        }
    }
}