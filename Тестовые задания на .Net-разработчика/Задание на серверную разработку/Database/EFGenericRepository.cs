using Database;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Service;
using System.Linq.Expressions;

namespace Repository
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DatabaseContext _context;
        DbSet<TEntity> _dbSet;

        public EFGenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(string toInclude = "")
        {
            return _dbSet.AsNoTracking().ToList();
        }

        /// <summary>
        /// Include expression
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            IIncludableQueryable<TEntity, object> query = null;

            if (includes.Length > 0)
            {
                query = _dbSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? _dbSet : (IQueryable<TEntity>)query.AsEnumerable();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }
        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _context.SaveChanges();
        }
    }
}