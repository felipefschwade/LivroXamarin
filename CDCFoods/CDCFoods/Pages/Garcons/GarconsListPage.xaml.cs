using CDCFoods.Dal;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.Garcons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarconsListPage : ContentPage
    {
        private GarcomDal dalGarcons = GarcomDal.GetInstance();
        public GarconsListPage()
        {
            InitializeComponent();
            lvEntregadores.ItemsSource = dalGarcons.GetAll();
        }
    }
}