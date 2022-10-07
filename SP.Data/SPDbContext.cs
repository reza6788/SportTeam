using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SP.Common.Enums;
using SP.Common.Utilities;
using SP.Data.Configurations;
using SP.Data.Entities;

namespace SP.Data
{
    public class SPDbContext : DbContext
    {
        public SPDbContext()
        {
        }

        public SPDbContext(DbContextOptions<SPDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PersonConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<PersonEntity> Persons { get; set; }
        public DbSet<PersonContactInfoEntity> PersonContactInfos { get; set; }
        public DbSet<PersonContributionEntity> PersonContributions { get; set; }
        public DbSet<SettingEntity> Settings { get; set; }
    }
}
