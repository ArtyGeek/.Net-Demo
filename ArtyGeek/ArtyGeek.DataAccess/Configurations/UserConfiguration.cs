using ArtyGeek.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.DataAccess.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.IsDeleted)
                .IsRequired();

            Property(x => x.Password)
                .IsRequired();

            Property(x => x.Salt)
                .IsRequired();

            Property(x => x.FirstName)
                .HasMaxLength(255)
                .IsOptional();

            Property(x => x.LastName)
                .HasMaxLength(255)
                .IsOptional();

            Property(x => x.Email)
                .HasMaxLength(255)
                .IsOptional();

            Property(x => x.Role)
                .IsRequired();

            Property(x => x.ImageId)
                .IsOptional();

            HasMany(x => x.Friends).
                WithOptional();
        }
    }
}
