using CDCFoods.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCFoods.Dal
{
    public class GarcomDal
    {
        private ObservableCollection<Garcom> Garcons = new ObservableCollection<Garcom>();

        private static GarcomDal GarcomInstance = new GarcomDal();

        private GarcomDal()
        {
            Garcons.Add(new Garcom() { Id = 1, Nome = "Brauzio", Telefone = "Asdrugio" });
            Garcons.Add(new Garcom() { Id = 2, Nome = "Entencius", Telefone = "Gesfredio" });
            Garcons.Add(new Garcom() { Id = 3, Nome = "Bernardo", Telefone = "Rafael" });
            Garcons.Add(new Garcom() { Id = 4, Nome = "Juca", Telefone = "Pedro" });
            Garcons.Add(new Garcom() { Id = 5, Nome = "dasdsadas", Telefone = "ghhgnb" });
            Garcons.Add(new Garcom() { Id = 6, Nome = "tw4tfvdb", Telefone = "kljkljju" });
            Garcons.Add(new Garcom() { Id = 7, Nome = "fsdsdffsdsdfa", Telefone = "xvgsjkv" });
            Garcons.Add(new Garcom() { Id = 8, Nome = "lçkfgbjkfgiop", Telefone = "faspiodgiopgioof" });
            Garcons.Add(new Garcom() { Id = 9, Nome = "lçasfklçvkl", Telefone = "asdpdasklçsdaklç" });
            Garcons.Add(new Garcom() { Id = 10, Nome = "KLDklsda", Telefone = "dasjlçdsaioio" });
        }

        public static GarcomDal GetInstance()
        {
            return GarcomInstance;
        }

        public ObservableCollection<Garcom> GetAll() => Garcons;

        public void AddEntregador(Garcom item)
        {
            Garcons.Add(item);
        }

    }
}
