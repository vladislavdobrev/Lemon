using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MelonStore.Repositories
{
    public class DbProductRepository : IProductRepository<Product>
    {
        public DbProductRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Invalid database context! It cannot be null!");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<Product>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<Product> DbSet { get; set; }


        public IQueryable<Product> All()
        {
            IQueryable<Product> all = this.DbSet;

            return all;
        }

        public ICollection<Product> Get(List<Gender> genders, List<Category> categories)
        {
            IQueryable<Product> all = this.All();


            ICollection<Product> filteredByGender = new HashSet<Product>();

            foreach (var gender in genders)
            {
                foreach (var product in all)
                {
                    if (product.Gender == gender)
                    {
                        filteredByGender.Add(product);
                    }
                }
            }

            ICollection<Product> filteredByCategoryAndGender = new HashSet<Product>();

            foreach (var category in categories)
            {
                foreach (var product in filteredByGender)
                {
                    if (product.Category == category)
                    {
                        filteredByCategoryAndGender.Add(product);
                    }
                }
            }

            return filteredByCategoryAndGender;
        }
    }
}
