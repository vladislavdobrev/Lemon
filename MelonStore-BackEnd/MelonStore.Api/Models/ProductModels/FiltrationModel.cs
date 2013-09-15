using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelonStore.Api.Models.ProductModels
{
    public class FiltrationModel
    {
        public string[] Categories { get; set; }
        public string[] Genders { get; set; }
    }
}