using CDCFoods.Dal;
using CDCFoods.Model;
using PCLStorage;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CDCFoods.Pages.ItensCardapio
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoItensNewPage : ContentPage
    {
        private TipoItemCardapioDal dalTiposItensCardapio = TipoItemCardapioDal.GetInstance();
        private string caminhoArquivo;
        public TipoItensNewPage()
        {
            InitializeComponent();
            PreparaParaNovoTipoItemCardapio();
            RegistraClickBotaoCamera(idTipoItemCardapio.Text.Trim());
            RegistraClickBotaoAlbum();
        }

        private void RegistraClickBotaoCamera(string idparafoto)
        {
            // Criação do método anônimo para captura do evento click dobotão
            BtnCamera.Clicked += async (sender, args) =>
            {
                // Inicialização do plugin de interação com a câmera e álbum
                await CrossMedia.Current.Initialize();
                // Verificação de disponibilização da câmera e se é possível tirar foto
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Não existe câmera", "A câmera não está disponível.", "OK");
                    return;
                }
                /* Método que habilita a câmera, informando a pasta onde a foto deverá
                ser armazenada, o nome a ser dado ao arquivo e se é ou não para armazenar a foto também no álbum */
                try
                {
                    var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                    {
                        Directory = FileSystem.Current.LocalStorage.Name,
                        Name = "tipoitem_" + idparafoto + ".jpg",
                        SaveToAlbum = true
                    });
                    if (file == null) return;
                    // Armazena o caminho da foto para ser utilizado na gravação do item
                    caminhoArquivo = file.Path;
                    // Recupera a foto e a atribui para o controle visual
                    fotoTipoItemcardapio.Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    });
                }
                catch (Exception e)
                {
                    return;
                }
            };
        }

        private void RegistraClickBotaoAlbum()
        {
            // Criação do método anônimo para captura do evento click do botão
            BtnAlbum.Clicked += async (sender, args) =>
            {
                // Inicialização do plugin de interação com a câmera e álbum
                await CrossMedia.Current.Initialize();
                // Verificação de disponibilização do álbum
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await DisplayAlert("Álbum não suportado", "Não existe permissão para acessar o álbum de fotos", "OK");
                    return;
                }
                // Método que habilita o álbum e permite a seleção de uma foto
                var file = await CrossMedia.Current.PickPhotoAsync();
                // Caso o usuário não tenha selecionado uma foto, clicando no botão cancelar
                if (file == null) return;
                /* Nas instruções abaixo é feito uso dos components PCLStorag e PCLSpecialFolder */
                // Recupera o arquivo com base no caminho da foto selecionada
                var getArquivoPCL = FileSystem.Current.GetFileFromPathAsync(file.Path);
                // Recupera o caminho raiz da aplicação no dispositivo
                // Guarda o caminho do arquivo para ser utilizado na gravação do item criado
                caminhoArquivo = file.Path;
                // Recupera o arquivo selecionado e o atribui ao controle no formulário
                fotoTipoItemcardapio.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            };
        }

        public void BtnGravarClick(object sender, EventArgs e)
        {
            if (nome.Text.Trim() == string.Empty)
            {
                this.DisplayAlert("Erro",
                "Você precisa informar o nome para o novo tipo de item do cardápio.",
                "Ok");
            }
            else
            {
                dalTiposItensCardapio.Add(new TipoItemCardapio()
                {
                    Id = Convert.ToUInt32(idTipoItemCardapio.Text),
                    Nome = nome.Text,
                    CaminhoArquivoFoto = caminhoArquivo
                });
                PreparaParaNovoTipoItemCardapio();
            }
        }

        private void PreparaParaNovoTipoItemCardapio()
        {
            var novoId = dalTiposItensCardapio.GetAll().Max(x => x.Id) + 1;
            idTipoItemCardapio.Text = novoId.ToString().Trim();
            nome.Text = string.Empty;
            fotoTipoItemcardapio.Source = null;
        }
    }
}