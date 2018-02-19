using CDCFoods.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCFoods.Dal
{
    public class EntregadorDal
    {
        private ObservableCollection<Entregador> Entregadores = new ObservableCollection<Entregador>();

        private static EntregadorDal EntregadorInstance = new EntregadorDal();

        private EntregadorDal()
        {
            Entregadores.Add(new Entregador() { Id = 1, Nome = "Brauzio", Telefone = "Asdrugio" });
            Entregadores.Add(new Entregador() { Id = 2, Nome = "Entencius", Telefone = "Gesfredio" });
            Entregadores.Add(new Entregador() { Id = 3, Nome = "Bernardo", Telefone = "Rafael" });
            Entregadores.Add(new Entregador() { Id = 4, Nome = "Juca", Telefone = "Pedro" });
            Entregadores.Add(new Entregador() { Id = 5, Nome = "dasdsadas", Telefone = "ghhgnb" });
            Entregadores.Add(new Entregador() { Id = 6, Nome = "tw4tfvdb", Telefone = "kljkljju" });
            Entregadores.Add(new Entregador() { Id = 7, Nome = "fsdsdffsdsdfa", Telefone = "xvgsjkv" });
            Entregadores.Add(new Entregador() { Id = 8, Nome = "lçkfgbjkfgiop", Telefone = "faspiodgiopgioof" });
            Entregadores.Add(new Entregador() { Id = 9, Nome = "lçasfklçvkl", Telefone = "asdpdasklçsdaklç" });
            Entregadores.Add(new Entregador() { Id = 10, Nome = "KLDklsda", Telefone = "dasjlçdsaioio" });
        }

        public static EntregadorDal GetInstance()
        {
            return EntregadorInstance;
        }

        public ObservableCollection<Entregador> GetAll()
        {
            return Entregadores;
        }

        public void AddEntregador(Entregador item)
        {
            Entregadores.Add(item);
        }

    }
}
