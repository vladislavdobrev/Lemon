using MelonStore.Data;
using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TempClient
{
    class Program
    {
        public static void Main(string[] args)
        {
            MelonStoreContext context = new MelonStoreContext();
            context.Products.Add(new Product() 
            {  
                Name = "test",
            });
        }
    }
}
