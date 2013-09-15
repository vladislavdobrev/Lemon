using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Repositories
{
    public interface IStoreRepository<T>
        where T : class
    {
        IQueryable<T> All();
    }
}
