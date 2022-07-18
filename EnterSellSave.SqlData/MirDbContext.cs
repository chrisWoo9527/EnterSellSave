using EnterSellSave.SqlData.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnterSellSave.SqlData
{
    public class MirDbContext : IdentityDbContext<User, Role, long>
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Menu> Menus { get; set; }

        public MirDbContext(DbContextOptions<MirDbContext> options) : base(options)
        {
             // 设置超时时间
             this.Database.SetCommandTimeout(30);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}