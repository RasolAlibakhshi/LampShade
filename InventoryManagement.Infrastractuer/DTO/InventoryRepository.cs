using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework;
using InventoryManagement.Domain.InventoryAgg;
using ShopeManagement.Infrastructure.DTO;

namespace InventoryManagement.Infrastractuer.DTO
{
    public class InventoryRepository<TEntity> : IRepositoryInventory<TEntity> where TEntity : EntitiyBase
    {
        private readonly InventoryContext _context;

        public InventoryRepository(InventoryContext context)
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
