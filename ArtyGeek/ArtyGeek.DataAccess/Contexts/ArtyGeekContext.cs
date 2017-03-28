using ArtyGeek.DataAccess.Configurations;
using ArtyGeek.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.DataAccess.Contexts
{
    public class ArtyGeekContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public ArtyGeekContext()
            : base("ArtyGeek")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
