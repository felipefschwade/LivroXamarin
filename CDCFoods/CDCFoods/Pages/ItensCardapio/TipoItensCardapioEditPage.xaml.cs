using CDCFoods.Dal;
using CDCFoods.Model;
using PCLStorage;
using Plugin.Media;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoItensCardapioEditPage : ContentPage
    {
        private TipoItemCardapio tipoItemCardapio;
        private string caminhoArquivo;
        private TipoItemCardapioDal dalTiposItensCardapio = new TipoItemCardapioDal();
        public TipoItensCardapioEditPage(TipoItemCardapio tipoItemCardapio)
        {
            InitializeComponent();
            PopularFormulario(tipoItemCardapio);
            RegistraClickBotaoCamera(idtipoitemcardapio.Text.Trim());
            RegistraClickBotaoAlbum();
        }

        private void PopularFormulario(TipoItemCardapio tipoItemCardapio)
        {
            this.tipoItemCardapio = tipoItemCardapio;
            idtipoitemcardapio.Text = tipoItemCardapio.Id.ToString();
            nome.Text = tipoItemCardapio.Nome;
            caminhoArquivo = tipoItemCardapio.CaminhoArquivoFoto;
            fototipoitemcardapio.Source = ImageSource.FromFile(tipoItemCardapio.CaminhoArquivoFoto);
        }

        private void RegistraClickBotaoAlbum()
        {
            BtnAlbum.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
                    return;
                }
                var file = await CrossMedia.Current.PickPhotoAsync();
                var getArquivoPCL = await FileSystem.Current.GetFileFromPathAsync(file.Path);
                if (file == null) return;
                caminhoArquivo = file.Path;
                fototipoitemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        private void RegistraClickBotaoCamera(string idparafoto)
        {
            BtnCamera.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe câmera", "A câmera não está disponível.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = FileSystem.Current.LocalStorage.Name,
                    Name = "tipoitem_" + idparafoto.Trim() + ".jpg",
                    SaveToAlbum = true
                });

                if (file == null) return;
                fototipoitemcardapio.Source = ImageSource.FromFile(file.Path);
                caminhoArquivo = file.Path;
            };
        }

        public async void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty)
            {
                await DisplayAlert("Erro", "Você precisa informar o nome para o novo tipo de item do cardápio.", "Ok");
            }
            else
            {
                tipoItemCardapio.Nome = nome.Text;
                tipoItemCardapio.CaminhoArquivoFoto = caminhoArquivo;
                dalTiposItensCardapio.Update(tipoItemCardapio);
                await Navigation.PopModalAsync();
            }
        }
    }
}