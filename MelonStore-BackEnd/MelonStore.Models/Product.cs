using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public Gender Gender { get; set; }
        public Category Category { get; set; }
        public int? Count { get; set; }
        public decimal? Price { get; set; }
        public decimal BasePrice { get; set; }
        public Nullable<int> Image_Id { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<ProductStore> ProductStores { get; set; }
        public DateTime DateAdded { get; set; }

    }
}
