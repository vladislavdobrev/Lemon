using MelonStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MelonStore.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Password)
                .HasMaxLength(40);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.SessionKey).HasColumnName("SessionKey");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.Store_Id).HasColumnName("Store_Id");
        }
    }
}
