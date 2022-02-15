using System.Linq;

namespace Git.Data.Common
{
    public interface IDbRepository
    {
        void Add<T>(T entity) where T : class;

        IQueryable<T> All<T>() where T : class;

        int SaveChanges();
    }
}
