using _0_Framework.Application;
using InventoryManagement.Application.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Infrastractuer;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application.Execution
{
    public class InventoryApplication : IInventoryApplication
    {
        

        
        public OpreationResult Create(CreateInventory command)
        {
            throw new NotImplementedException();
        }

        public OpreationResult Decrease(List<DecreaseInventory> command)
        {
            throw new NotImplementedException();
        }

        public OpreationResult Edit(EditInventory command)
        {
            throw new NotImplementedException();
        }

        public Inventory GetBy(long id)
        {
            throw new NotImplementedException();
        }

        public EditInventory GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public OpreationResult Increase(InceaseInventory command)
        {
            throw new NotImplementedException();
        }

        public List<ViewModelInventory> Search(SearchModelInventory command)
        {
            throw new NotImplementedException();
        }
    }
}
