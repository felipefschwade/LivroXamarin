using CDCFoods.Pages.TipoItensCardapio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.ItensCardapio.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GridCustomControl
    {
        public GridCustomControl()
        {
            InitializeComponent();
        }

        private async void OnTapLookForTipos(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new TiposDeItensCardapioSearchPage(idTipo, nomeTipo));
        }
    }
}