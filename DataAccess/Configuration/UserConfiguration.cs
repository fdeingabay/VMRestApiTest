using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<Entities.User>
    {
        public UserConfiguration()
        {
            Property(p => p.Apellido).IsRequired().HasMaxLength(50);

            Property(p => p.Nombre).IsRequired().HasMaxLength(50);

            Property(p => p.Email).IsRequired().HasMaxLength(50);

            Property(p => p.Password).IsRequired().HasMaxLength(20);
        }
    }
}
