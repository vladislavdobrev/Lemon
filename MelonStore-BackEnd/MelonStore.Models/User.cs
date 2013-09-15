using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string SessionKey { get; set; }
        [MaxLength(40), MinLength(40)]
        public string Password { get; set; }
        public Nullable<int> Store_Id { get; set; }
        public virtual Store Store { get; set; }
    }
}
