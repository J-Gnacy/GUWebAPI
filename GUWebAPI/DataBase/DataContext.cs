using GUWebAPI.Entities;
using Microsoft.EntityFrameworkCore;


namespace GUWebAPI.DataBase
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

    }
}
