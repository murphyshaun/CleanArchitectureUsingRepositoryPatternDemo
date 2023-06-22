using System.Linq.Expressions;

namespace Application.Common.Interface
{
    public interface IRepository<T> where T : class
    {
        #region Properties

        /// <summary>
        /// Gets a table.
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        #endregion Properties

        #region Methods

        void Add(T entity);

        void Update(T entity);

        Task<bool> Delete(object id);

        Task<bool> Delete(T entity);

        Task<bool> Delete(Expression<Func<T, bool>> where);

        Task<T> Get(object id);

        Task<T> Get(Expression<Func<T, bool>> where);

        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        IEnumerable<T> GetAll();

        Task<int> Count(Expression<Func<T, bool>> where);

        Task<int> Count();

        #endregion Methods
    }
}