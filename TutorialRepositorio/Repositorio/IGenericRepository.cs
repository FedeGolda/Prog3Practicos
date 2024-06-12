using System.Linq.Expressions;

namespace TutorialRepositorio.Repositorio
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        IEnumerable<TEntity> GetAllWithIncludes(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetByIdWithIncludes(int id, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
