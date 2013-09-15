using MelonStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MelonStore.Data.Mapping
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Images");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Url).HasColumnName("Url");
        }
    }
}
