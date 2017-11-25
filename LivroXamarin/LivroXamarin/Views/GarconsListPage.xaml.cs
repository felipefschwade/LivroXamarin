using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LivroXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarconsListPage : ContentPage
    {
        public GarconsListPage()
        {
            BindingContext = this;
            InitializeComponent();
        }

        public IEnumerable<string> GetGarcons { get {
            return new List<string>
            {
                "Braulio",
                "Jhonata",
                "José Pedro",
                "Tafarel",
                "Romario",
                "Juca",
                "João",
                "CARLOS"
            };
        }}
    }
}