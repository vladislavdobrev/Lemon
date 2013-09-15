using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelonStore.Api.Models.ProductStoreModels
{
    public class ProductStoreApiSellBuyModel
    {
        public decimal Price { get; set; }
        public int Count { get; set; }
        public DateTime? DateSold { get; set; }
    }
}