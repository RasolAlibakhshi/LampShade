using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Application.Execution.ColleagueDiscount;
using DiscountManagement.Application.Execution.CustomerDiscount;
using InventoryManagement.Application.Contract;
using InventoryManagement.Application.Execution;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopeManegement.Application.Contract.Product;
using ShopeManegement.Application.Execution.Product;
using ProductView = InventoryManagement.Application.Contract.ProductView;


namespace ServiceHost.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _ProductApplication;
        private readonly IInventoryApplication _InventoryApplication;

        public IndexModel(IProductApplication productApplication, IInventoryApplication inventoryContext)
        {
            _ProductApplication = productApplication;
            _InventoryApplication = inventoryContext;
        }
        [TempData]
        public string Message { set; get; }
        public SearchModelInventory SearchModel { get; set; }
        public List<ViewModelInventory> Inventory { get; set; }
        public List<ProductViewModel> SelectList { get; set; }

        public void OnGet(SearchModelInventory searchModel)
        {
            SelectList = _ProductApplication.Search(new ProductSearchModel());
            List<ViewModelInventory> data = _InventoryApplication.Search(searchModel);
             data.ForEach(x => x.ProductName=_ProductApplication.Getdetails(x.ProductID).Name);
             Inventory = data;
        }
        public IActionResult OnGetCreate()
        {

            var data = new CreateInventory();
            data.Products = _ProductApplication.Search(new ProductSearchModel())
                .Select(x => new ProductView { ID = x.ID, Name = x.Name }).ToList();
            return Partial("./Create", data);
        }

        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _InventoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var data = _InventoryApplication.GetDetails(id);
            data.Products=_ProductApplication.Search(new ProductSearchModel()).Select(x => new ProductView { ID = x.ID, Name = x.Name }).ToList();
            return Partial("./Edit", data);
        }
        public JsonResult OnPostEdit(EditInventory command)
        {
            return new JsonResult(_InventoryApplication.Edit(command));
        }

        public IActionResult OnGetIncrease(long id)
        {

            return Partial("./Increase", new IncreaseInventory
            {
                InventoryID = _InventoryApplication.GetBy(id).ID
            });
        }
        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _InventoryApplication.Increase(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetReduce(long id)
        {

            return Partial("./Reduce", new DecreaseInventory
            {
                InventoryId = _InventoryApplication.GetBy(id).ID
            });
        }
        public JsonResult OnPostReduce(DecreaseInventory command)
        {
            var result = _InventoryApplication.Decrease(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetLog(long id)
        {
            return Partial("./OperationLog", _InventoryApplication.GetOperationLog(id));
        }


    }
}
