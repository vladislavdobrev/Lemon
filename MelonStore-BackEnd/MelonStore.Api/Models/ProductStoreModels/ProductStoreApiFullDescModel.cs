using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelonStore.Api.Models.ProductStoreModels
{
    public class ProductStoreApiFullDescModel
    {
        public decimal Price { get; set; }
        public int Count { get; set; }
        public int ProductId { get; set; }
        public  ProductApiModel Product { get; set; }
        public DateTime? LastDateSold { get; set; }
        public int StoreId { get; set; }

    }
}