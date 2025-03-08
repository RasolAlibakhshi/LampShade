using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _0_Framework;

namespace ShopeManagement.Infrastructure.DTO
{
    public interface IRepository<TEntity>:IDisposable where TEntity : EntitiyBase
    {
        void Create(TEntity entity);
        TEntity Getby(Expression<Func<TEntity, bool>> Filter);
        List<TEntity> GetAll();
        
        void SaveChange();
        bool Exite(Expression<Func<TEntity,bool>>Flter);
    }
}
