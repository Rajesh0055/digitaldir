using Microsoft.EntityFrameworkCore;

namespace apiNetcoreDemo.Data.Entity
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<Cack> Cake { get; set; }
        public DbSet<ServiceMaster> ServiceMaster { get; set; }

        public DbSet<UserMaster> UserMaster { get; set; }

        public DbSet<CategoryMaster> CategoryMaster { get; set; }

    }
}
