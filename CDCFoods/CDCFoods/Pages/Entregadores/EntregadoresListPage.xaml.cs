using CDCFoods.Dal;
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
    public partial class EntregadoresListPage : ContentPage
    {
        private EntregadorDal dalEntregador = EntregadorDal.GetInstance();
        public EntregadoresListPage()
        {
            InitializeComponent();
            lvEntregadores.ItemsSource = dalEntregador.GetAll();
        }
    }
}