using MelonStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MelonStore.Data.Mapping
{
    public class ProductStoreMap : EntityTypeConfiguration<ProductStore>
    {
        public ProductStoreMap()
        {
            // Primary Key
            this.HasKey(t => new { t.Product_Id, t.Store_Id });

            // Properties
            this.Property(t => t.Product_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Store_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("ProductStores");
            this.Property(t => t.Product_Id).HasColumnName("Product_Id");
            this.Property(t => t.Store_Id).HasColumnName("Store_Id");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.Count).HasColumnName("Count");
            this.Property(t => t.LastDateSold).HasColumnName("LastDateSold");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductStores)
                .HasForeignKey(d => d.Product_Id);
            this.HasRequired(t => t.Store)
                .WithMany(t => t.ProductStores)
                .HasForeignKey(d => d.Store_Id);

        }
    }
}
