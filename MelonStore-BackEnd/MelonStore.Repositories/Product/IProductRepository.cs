using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Repositories
{
    public interface IProductRepository<T>
        where T : class
    {
        IQueryable<T> All();
        ICollection<T> Get(List<Gender> gender, List<Category> category);
    }
}
