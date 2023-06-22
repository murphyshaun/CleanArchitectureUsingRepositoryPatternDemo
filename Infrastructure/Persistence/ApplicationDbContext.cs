using Application.Common.Interface;
using Domain.Common;
using Domain.Master;
using Domain.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Fields

        private readonly DateTime _currentDateTime;

        #endregion Fields

        #region Properties

        public DbSet<AppSetting> AppSettings { get; set; }
        public DbSet<Category> Categories { get; set; }

        #endregion Properties

        #region Constructor

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            _currentDateTime = DateTime.Now;
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<int> SaveChangesAsync()
        {
            foreach (var entity in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entity.State)
                {
                    case EntityState.Added:
                        {
                            entity.Entity.Author = 1; //Get Current UserID
                            entity.Entity.Created = _currentDateTime;
                            entity.Entity.Editor = 1; //Get Current UserID
                            entity.Entity.Modified = _currentDateTime;

                            break;
                        }

                    case EntityState.Modified:
                        {
                            entity.Entity.Editor = 1; //Get Current UserID
                            entity.Entity.Modified = _currentDateTime;
                            break;
                        }
                }
            }

            return base.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>A set for the given entity type</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        #endregion Methods
    }
}