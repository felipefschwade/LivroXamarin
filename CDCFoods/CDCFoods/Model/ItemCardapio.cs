using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDCFoods.Model
{
    public class ItemCardapio
    {
        [PrimaryKey, AutoIncrement]
        public long? Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public byte[] Foto { get; set; }
        [ForeignKey(typeof(TipoItemCardapio))]
        public long? TipoItemCardapioId { get; set; }
        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public TipoItemCardapio TipoItemCardapio { get; set; }
        public override bool Equals(object obj)
        {
            ItemCardapio itemCardapio = obj as ItemCardapio;
            if (itemCardapio == null)
            {
                return false;
            }
            return (Id.Equals(itemCardapio.Id));
        }
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
