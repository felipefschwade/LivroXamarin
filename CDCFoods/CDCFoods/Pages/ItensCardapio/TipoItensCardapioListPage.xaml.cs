using CDCFoods.Dal;
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
        private TipoItemCardapioDal dalTipoItemCardapio = TipoItemCardapioDal.GetInstance();
        public TiposItensCardapioListPage()
        {
            InitializeComponent();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }
    }
}