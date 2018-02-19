using CDCFoods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCFoods.Dal
{
    public class TipoItemMenuDal
    {
        private ObservableCollection<TipoItemMenu> TipoItemMenu = new ObservableCollection<TipoItemMenu>();

        private static TipoItemMenuDal EntregadorInstance = new TipoItemMenuDal();

        private TipoItemMenuDal()
        {
            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 1,
                Nome = "Pizza",
                CaminhoArquivoFoto = "pizzas.png"
            });
            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 2,
                Nome = "Bebidas",
                CaminhoArquivoFoto = "bebidas.png"
            });
            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 3,
                Nome = "Saladas",
                CaminhoArquivoFoto = "saladas.png"
            });
            TiposItensCardapio.Add(new TipoItemCardapio()
            {
                Id = 4,
                Nome = "Carnes",
                CaminhoArquivoFoto = "carnes.png"
            });
        }

        public static TipoItemMenuDal GetInstance()
        {
            return EntregadorInstance;
        }

        public ObservableCollection<TipoItemMenuDal> GetAll()
        {
            return TipoItemMenu;
        }

        public void AddEntregador(TipoItemMenu item)
        {
            TipoItemMenu.Add(item);
        }

    }
}
