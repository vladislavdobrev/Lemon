using System;
using System.Collections.Generic;

namespace MelonStore.Models
{
    public partial class ProductStore
    {
        public int Product_Id { get; set; }
        public int Store_Id { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
        public DateTime? LastDateSold { get; set; }
    }
}
