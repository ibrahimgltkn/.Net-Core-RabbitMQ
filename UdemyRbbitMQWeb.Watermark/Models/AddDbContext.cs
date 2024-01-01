using Microsoft.EntityFrameworkCore;

namespace UdemyRbbitMQWeb.Watermark.Models
{
    public class AddDbContext:DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
