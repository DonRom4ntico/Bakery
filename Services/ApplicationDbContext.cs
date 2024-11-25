using CarlBakerzShop.Models;
using Microsoft.EntityFrameworkCore;

namespace CarlBakerzShop.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
