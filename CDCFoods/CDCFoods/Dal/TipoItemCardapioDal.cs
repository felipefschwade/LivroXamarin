using CDCFoods.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCFoods.Dal
{
    public class TipoItemCardapioDal
    {
        private ObservableCollection<TipoItemCardapio> TiposItensCardapio = new ObservableCollection<TipoItemCardapio>();

        private static TipoItemCardapioDal EntregadorInstance = new TipoItemCardapioDal();

        private TipoItemCardapioDal()
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

        public void Remove(TipoItemCardapio item)
        {
            TiposItensCardapio.Remove(item);
        }

        public static TipoItemCardapioDal GetInstance()
        {
            return EntregadorInstance;
        }

        public ObservableCollection<TipoItemCardapio> GetAll()
        {
            return TiposItensCardapio;
        }

        public void Add(TipoItemCardapio item)
        {
            TiposItensCardapio.Add(item);
        }

    }
}
