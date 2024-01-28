using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMarket_DataLayer.Entities;

namespace WebMarket_DataLayer.Context
{
    public class WebMarketContext : DbContext
    {
        public WebMarketContext(DbContextOptions<WebMarketContext> options) : base(options)
        {

        }

        #region Products

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Brand> brands { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Product>().Property(p => p.SubCategoryId).IsRequired(false);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            base.OnModelCreating(modelBuilder);
        }

    }
}
