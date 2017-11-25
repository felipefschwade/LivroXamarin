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
    public partial class GarconsPage : TabbedPage
    {
        public GarconsPage()
        {
            InitializeComponent();
            Children.Add(new GarconsListPage() { Title = "Listagem", Icon="icone_list.png" });
            Children.Add(new GarconsNewPage() { Title = "Inserir Novo", Icon="icone_new" });
        }
    }
}