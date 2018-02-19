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
	public partial class ItensNewPage : ContentPage
    {
        private TipoItemMenuDal dalTipoItemCardapio = TipoItemMenuDal.GetInstance();
        public ItensNewPage()
        {
            InitializeComponent();
            lvTiposItensCardapio.ItemsSource = dalTipoItemCardapio.GetAll();
        }
    }
}