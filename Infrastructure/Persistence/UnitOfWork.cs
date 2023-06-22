using Application.Common.Interface;
using Domain.Master;
using Domain.Product;
using Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private readonly ApplicationDbContext _context;
        private bool _disposed = false;
        private IRepository<Category> _categoryRepository;
        private IRepository<AppSetting> _appSettingRepository;
        private IDbContextTransaction dbContextTransaction;

        #endregion Fields

        #region Properties

        public IRepository<AppSetting> AppSettingRepository
        {
            get
            {
                if (_appSettingRepository == null)
                    _appSettingRepository = new EfRepository<AppSetting>(_context);
                return _appSettingRepository;
            }
        }

        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new EfRepository<Category>(_context);
                return _categoryRepository;
            }
        }

        #endregion Properties

        #region Constructor

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Constructor

        #region Methods

        public void BeginTransaction()
        {
            dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (dbContextTransaction != null)
                dbContextTransaction.Commit();
        }

        public void RollbackTransaction()
        {
            if (dbContextTransaction != null)
                dbContextTransaction.Rollback();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Methods
    }
}