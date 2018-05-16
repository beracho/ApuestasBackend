using BaseBackend.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Team> Teams { get; set; }
        public DbSet<User> Users { get; set; }
    }
}