using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MelonStore.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<ProductStore> ProductStores { get; set; }
        public int? User_Id { get; set; }
        public virtual User User { get; set; }
    }
}
