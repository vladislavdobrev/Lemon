using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Models
{
    public class Image
    {
        public int Id { get; set;}
        public string Url { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
