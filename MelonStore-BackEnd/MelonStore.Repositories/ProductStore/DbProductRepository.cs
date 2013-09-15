using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MelonStore.Repositories
{
    public class DbProductStoreRepository : IProductStoreRepository<ProductStore>
    {
        public DbProductStoreRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Invalid database context! It cannot be null!");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<ProductStore>();
        }

        protected DbContext Context { get; set; }

        protected DbSet<ProductStore> DbSet { get; set; }

        public IQueryable<ProductStore> All()
        {
            var allProducts = this.DbSet;

            return allProducts;
        }

        public IQueryable<ProductStore> Get(int storeId)
        {
            IQueryable<ProductStore> all = this.All();

            IQueryable<ProductStore> productStore = (from current in all
                                                     where current.Store_Id == storeId
                                                     select current);
            return productStore;
        }

        public ProductStore Get(int productId, int storeId)
        {
            IQueryable<ProductStore> all = this.All();

            ProductStore productStore = (from current in all
                                         where current.Product_Id == productId &&
                                         current.Store_Id == storeId
                                         select current).FirstOrDefault();
            return productStore;

        }

        public ICollection<Product> Get(List<Gender> genders, List<Category> categories, int storeId)
        {
            IQueryable<Product> all = from curr in this.Get(storeId)
                                      select curr.Product;

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

        public ProductStore Add(ProductStore item)
        {
            this.DbSet.Add(item);
            this.Context.SaveChanges();

            return null;
        }

        public void Update(int productId, int storeId, ProductStore item)
        {
            ProductStore fromDb = this.Get(productId, storeId);
            fromDb.Price = item.Price;
            fromDb.Count = fromDb.Count + item.Count;

            this.Context.Entry(fromDb).State = System.Data.EntityState.Modified;

            this.Context.SaveChanges();
        }
    }
}