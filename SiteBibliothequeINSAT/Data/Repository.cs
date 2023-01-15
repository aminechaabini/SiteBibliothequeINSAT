using Microsoft.EntityFrameworkCore;
using SiteBibliothequeINSAT.Data;
using System.Linq.Expressions;

namespace Repository.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly LibraryContext _libraryContext;

        public Repository(LibraryContext libraryContext)
        {
            this._libraryContext = libraryContext;
        }
        public bool Add(TEntity entity)
        {
            try
            {
                _libraryContext.Set<TEntity>().Add(entity);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _libraryContext.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _libraryContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _libraryContext.Set<TEntity>().ToList();
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                _libraryContext.Set<TEntity>().Remove(entity);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
