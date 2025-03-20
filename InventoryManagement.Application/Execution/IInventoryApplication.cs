using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using InventoryManagement.Application.Contract;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application.Execution
{
    public interface IInventoryApplication
    {
        OpreationResult Create(CreateInventory command);
        OpreationResult Edit(EditInventory command);
        EditInventory GetDetails(long id);
        List<ViewModelInventory> Search(SearchModelInventory command);
        OpreationResult Increase(IncreaseInventory command);
        OpreationResult Decrease(List<DecreaseInventory> command);
        OpreationResult Decrease(DecreaseInventory command);
        Inventory GetBy(long id);
        List<InventoryOperationViewModel> GetOperationLog(long InventoryID);

    }
}
