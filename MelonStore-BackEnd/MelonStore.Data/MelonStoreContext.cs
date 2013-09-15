using MelonStore.Data.Mapping;
using MelonStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace MelonStore.Data
{
    public class MelonStoreContext : DbContext
    {
        public MelonStoreContext() : base("MelonStoreDb")
        {
        }

        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductStore> ProductStores { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ImageMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductStoreMap());
            modelBuilder.Configurations.Add(new StoreMap());
            modelBuilder.Configurations.Add(new UserMap());

            modelBuilder.Entity<User>().HasOptional(t => t.Store).WithRequired(t => t.User);
        }
    }
}