
using System.Linq.Expressions;

using _0_Framework;
using ShopeManagement.Infrastructure.DTO;

namespace DiscountManagement.Infrastructure.DTO
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : EntitiyBase
    {
        private readonly DiscountManagementContext _context;

        public Repository(DiscountManagementContext context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool Exite(Expression<Func<TEntity, bool>> Flter)
        {
            return _context.Set<TEntity>().Any(Flter);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity Getby(Expression<Func<TEntity, bool>> Filter)
        {
            return _context.Set<TEntity>().FirstOrDefault(Filter);
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
