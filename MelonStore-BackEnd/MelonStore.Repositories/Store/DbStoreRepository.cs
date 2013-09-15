using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonStore.Models;
using System.Data.Entity;

namespace MelonStore.Repositories
{
    public class DbStoreRepository : IStoreRepository<Store>
    {
        public DbStoreRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Invalid database context! It cannot be null!");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<Store>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<Store> DbSet { get; set; }


        public IQueryable<Store> All()
        {
            IQueryable<Store> all = this.DbSet;

            return all;
        }
    }
}
