using Microsoft.EntityFrameworkCore;

namespace JBragon.DataAccess.Context
{
    public class MainContext : DbContext
    {
        public MainContext(DbContextOptions<MainContext> options)
            : base(options)
        {
        }

        public MainContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainContext).Assembly);
            base.OnModelCreating(modelBuilder);

            foreach (var item in DataAccessDataConfigurations.Instance.Configurations())
            {
                modelBuilder.ApplyConfiguration(item);
            }
        }
    }
}
