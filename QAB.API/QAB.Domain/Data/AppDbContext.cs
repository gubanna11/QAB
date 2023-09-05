using Microsoft.EntityFrameworkCore;
using QAB.Domain.Data.EntityConfiguration;
using QAB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAB.Domain.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        { }

        public DbSet<Case> Cases { get; set; }
        
        public DbSet<Comment> Comments { get; set; }

        public DbSet<CaseType> CaseTypes { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<TableForLikes> TablesForLikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // entity configurations
            modelBuilder.ApplyConfiguration(new CaseConfiguration());
            modelBuilder.ApplyConfiguration(new CaseTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
