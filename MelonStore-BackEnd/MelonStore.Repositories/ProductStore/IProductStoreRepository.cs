using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Repositories
{
    public interface IProductStoreRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T Get(int storeId, int productId);

        T Add(T item);

        ICollection<Product> Get(List<Gender> genders, List<Category> categories, int storeId);

        void Update(int storeId, int productId, T item);
    }
}
