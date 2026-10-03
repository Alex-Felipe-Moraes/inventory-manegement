using Microsoft.EntityFrameworkCore;
using InventoyAPI.Models;

namespace InventoyAPI.Data
{
    public class InventoryContext : DbContext {
        
        public InventoryContext(DbContextOptions<InventoryContext> options)
            :base(options){}

        public DbSet<Item> items {get; set;}

    }
}