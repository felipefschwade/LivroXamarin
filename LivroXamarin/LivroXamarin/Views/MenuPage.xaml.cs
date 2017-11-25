
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LivroXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            BindingContext = this;
            InitializeComponent();
            Content = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Button()
                    {
                        Text = "Garçons",
                        Image = "icone_garcons.png",
                        Command = new Command(() => Navigation.PushAsync(new GarconsPage()))
                    }
                }
            };
        }
    }
}