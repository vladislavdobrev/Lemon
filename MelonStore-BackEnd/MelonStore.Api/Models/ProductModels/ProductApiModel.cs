using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelonStore.Api.Models.ProductStoreModels
{
    public class ProductApiModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}