using CDCFoods.Infra;
using CDCFoods.Model;
using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace CDCFoods.Dal
{
    public class TipoItemCardapioDal
    {
        private ObservableCollection<TipoItemCardapio> TiposItensCardapio = new ObservableCollection<TipoItemCardapio>();
        private SQLiteConnection conn;

        public TipoItemCardapioDal()
        {
            conn = DependencyService.Get<IDatabaseConnection>().GetConnection();
            conn.CreateTable<TipoItemCardapio>();
        }

        public IEnumerable<TipoItemCardapio> GetAll()
        {
            return conn.Table<TipoItemCardapio>().OrderBy(i => i.Nome).ToList();
        }

        public TipoItemCardapio GetItemById(long id)
        {
            return conn.Table<TipoItemCardapio>().FirstOrDefault(t => t.Id == id);
        }
        public void DeleteById(long? id)
        {
            conn.Delete<TipoItemCardapio>(id);
        }
        public void Add(TipoItemCardapio tipoItemCardapio)
        {
            conn.Insert(tipoItemCardapio);
        }
        public void Update(TipoItemCardapio tipoItemCardapio)
        {
            conn.Update(tipoItemCardapio);
        }
    }
}
