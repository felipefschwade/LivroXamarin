using CDCFoods.Dal;
using CDCFoods.Model;
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
        private EntregadorDal dalEntregadores = EntregadorDal.GetInstance();
        public EntregadoresNewPage()
        {
            InitializeComponent();
            PreparaParaNovoEntregador();
        }


        private async void BtnGravarClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nome.Text.Trim()) || string.IsNullOrEmpty(telefone.Text.Trim()))
            {
                await DisplayAlert("Erro", "Você precisa informar o nome e o telefone do entregador", "Ok");
            }
            else
            {
                dalEntregadores.AddEntregador(new Entregador() { Id = Convert.ToInt32(identregador.Text), Nome = nome.Text, Telefone = telefone.Text });
                PreparaParaNovoEntregador();
            }
        }

        private void PreparaParaNovoEntregador()
        {
            var novoId = dalEntregadores.GetAll().Max(x => x.Id) + 1;
            identregador.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
            telefone.Text = string.Empty;
        }
    }
}