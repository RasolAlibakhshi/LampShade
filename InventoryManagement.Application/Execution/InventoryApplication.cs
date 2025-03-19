using _0_Framework.Application;
using InventoryManagement.Application.Contract;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastractuer.DTO;


namespace InventoryManagement.Application.Execution
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IRepositoryInventory<Inventory> _inventoryRepository;
        

        public InventoryApplication(IRepositoryInventory<Inventory> inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
            
        }

        public OpreationResult Create(CreateInventory command)
        {
            var opreation=new OpreationResult();
            if (_inventoryRepository.Exite(x=>x.ProductID==command.ProductID))
            {
                return opreation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            _inventoryRepository.Create(new Inventory(command.ProductID,command.UnitPrice));
            _inventoryRepository.SaveChange();
            return opreation.Success();
        }

        public OpreationResult Decrease(List<DecreaseInventory> command)
        {
            var opreation = new OpreationResult();
            

            foreach (var item in command)
            {
                _inventoryRepository.Getby(x => x.ID == item.InventoryId)
                    .Reduce(item.Count, item.OrderID, item.Description, item.OrderID);
            }
            _inventoryRepository.SaveChange();
            return opreation.Success();
        }

        public OpreationResult Decrease(DecreaseInventory command)
        {
            var opreation = new OpreationResult();
            var data = _inventoryRepository.Getby(x => x.ID==command.InventoryId);
            if (data==null)
            {
                return opreation.Failed(ApplicationMessages.RecordNotFound);
            }

            const long opratorId = 0;
            data.Reduce(command.Count, opratorId,command.Description,0);
            _inventoryRepository.SaveChange();
            return opreation.Success();
        }

        public OpreationResult Edit(EditInventory command)
        {
            var opreation=new OpreationResult();
            var data = _inventoryRepository.Getby(x => x.ID == command.ID);
            if (data == null)
            {
                return opreation.Failed(ApplicationMessages.RecordNotFound);
            }

            if (_inventoryRepository.Exite(x=>x.ID!=command.ID && command.ProductID==x.ProductID))
            {
                return opreation.Failed(ApplicationMessages.DuplicatedRecord);
            }
            data.Edit(command.ProductID,command.UnitPrice);
            _inventoryRepository.SaveChange();
            return opreation.Success();
        }

        public Inventory GetBy(long id)
        {
            return _inventoryRepository.Getby(x => x.ID == id);
        }

        public EditInventory GetDetails(long id)
        {
            var data= _inventoryRepository.Getby(x => x.ID == id);
            EditInventory editinventory = new EditInventory
            {
                ID = data.ID,
                ProductID = data.ProductID,
                UnitPrice = data.UnitPrice
            };

            return editinventory;
        }

        public OpreationResult Increase(InceaseInventory command)
        {
            var opreation = new OpreationResult();
            var data = _inventoryRepository.Getby(x => x.ID==command.InventoryID);
            if (data==null)
            {
                return opreation.Failed(ApplicationMessages.RecordNotFound);
            }

            const long opratorId = 0;
            data.InCrease(command.Count, opratorId, command.Description);
            _inventoryRepository.SaveChange();
            return opreation.Success();
        }

        public List<ViewModelInventory> Search(SearchModelInventory command)
        {
            var query = _inventoryRepository.GetAll();
            if (command.ProductID > 0)
            {
                query = query.Where(x => x.ProductID == command.ProductID).ToList();
            }

            if (!command.InStock)
            {
                query = query.Where(x => x.InStock == false).ToList();
            }

            return query.Select(x => new ViewModelInventory
            {
                ProductID = x.ProductID,
                ID = x.ID,
                InStock = x.InStock,
                CurrentCount = x.CalculateCurrentInventory(),
                UnitPrice = x.UnitPrice
            }).ToList();


        }
    }
}
