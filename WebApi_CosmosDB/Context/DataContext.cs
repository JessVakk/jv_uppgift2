using Microsoft.EntityFrameworkCore;
using WebApi_CosmosDB.Models;

namespace WebApi_CosmosDB.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductModel> ProductCatalog { get; set; }
        public object Products { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>().ToContainer("ProductCatalog").HasPartitionKey(x => x.PartitionKey);
        }
    }
}
