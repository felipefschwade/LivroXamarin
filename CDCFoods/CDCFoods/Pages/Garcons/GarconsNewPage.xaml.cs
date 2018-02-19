using CDCFoods.Dal;
using CDCFoods.Model;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.Garcons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GarconsNewPage : ContentPage
    {
        private GarcomDal dalGarcons = GarcomDal.GetInstance();
        public GarconsNewPage()
        {
            InitializeComponent();
            PreparaParaNovoGarcon();
        }


        private async void BtnGravarClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nome.Text.Trim()) || string.IsNullOrEmpty(telefone.Text.Trim()))
            {
                await DisplayAlert("Erro", "Você precisa informar o nome e o telefone do entregador", "Ok");
            }
            else
            {
                dalGarcons.AddEntregador(new Garcom() { Id = Convert.ToInt32(idGarcon.Text), Nome = nome.Text, Telefone = telefone.Text });
                PreparaParaNovoGarcon();
            }
        }

        private void PreparaParaNovoGarcon()
        {
            var novoId = dalGarcons.GetAll().Max(x => x.Id) + 1;
            idGarcon.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
            telefone.Text = string.Empty;
        }
    }
}