using Microsoft.EntityFrameworkCore;
using JBragon.Common.Interfaces;

namespace JBragon.DataAccess.Context
{
    public class MainContext : DbContext
    {
        private readonly IUser _user;
        public MainContext(DbContextOptions<MainContext> options, IUser user)
            : base(options)
        {
            _user = user;
        }
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

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        //{
        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            //entry.Property("CreationDate").CurrentValue = DateTime.Now;
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            //entry.Property("CreationDate").IsModified = false;
        //        }
        //    }

        //    foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationUser") != null))
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            //entry.Property("CreationUser").CurrentValue = !string.IsNullOrEmpty(_user.GetUserName()) ? _user.GetUserName() : ""; 
        //        }

        //        if (entry.State == EntityState.Modified)
        //        {
        //            //entry.Property("CreationUser").IsModified = false;
        //        }
        //    }

        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
