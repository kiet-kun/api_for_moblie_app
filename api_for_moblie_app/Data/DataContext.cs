using Microsoft.EntityFrameworkCore;

namespace api_for_moblie_app.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
    }
}
