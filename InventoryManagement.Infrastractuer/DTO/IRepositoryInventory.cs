using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework;
using ShopeManagement.Infrastructure.DTO;

namespace InventoryManagement.Infrastractuer.DTO
{
    public interface IRepositoryInventory<TEntity>:IRepository<TEntity> where TEntity : EntitiyBase
    {

    }
}
