using System.Linq.Expressions;

namespace Service
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Create item
        /// </summary>
        /// <param name="item"></param>
        void Create(TEntity item);

        /// <summary>
        /// Find Item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity FindById(int id);

        /// <summary>
        /// Get item
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> Get(string toInclude = "");
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);

        /// <summary>
        /// Remove item
        /// </summary>
        /// <param name="item"></param>
        void Remove(TEntity item);

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="item"></param>
        void Update(TEntity item);

        /// <summary>
        /// Include
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    }
}