using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Application.Execution.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopeManegement.Application.Contract.Product;
using ShopeManegement.Application.Execution.Product;


namespace ServiceHost.Pages.Discounts.CustomerDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _ProductApplication;
        private readonly ICustomerDiscountApplication _Customerdiscount;

        public IndexModel(IProductApplication productApplication, ICustomerDiscountApplication customerdiscount)
        {
            _ProductApplication = productApplication;
            _Customerdiscount = customerdiscount;
        }
        public CustomerDiscountSearchModel SearchModel { get; set; }
        public List<CustomerDiscountViewModel> Customerdiscount { get; set; }
        public List<ProductViewModel> SelectList { get; set; }
        public void OnGet(CustomerDiscountSearchModel searchModel)
        {
            SelectList = _ProductApplication.Search(new ProductSearchModel());
            var data = _Customerdiscount.Search(searchModel);
            data.ForEach(x => x.ProductName=_ProductApplication.Getdetails(x.ProductID).Name);
            Customerdiscount = data;
        }
        public IActionResult OnGetCreate()
        {

            var data = new DefineCustomerDiscount();
            data.ProductViews = _ProductApplication.Search(new ProductSearchModel())
                .Select(x => new ProductView { ID = x.ID, Name = x.Name }).ToList();
            return Partial("./Create", data);
        }

        public JsonResult OnPostCreate(DefineCustomerDiscount command)
        {
            var result = _Customerdiscount.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var data = _Customerdiscount.Getdetails(id);
            data.ProductViews=_ProductApplication.Search(new ProductSearchModel()).Select(x => new ProductView { ID = x.ID, Name = x.Name }).ToList();
            return Partial("./Edit", data);
        }
        public JsonResult OnPostEdit(EditeCustomerDiscount command)
        {
            return new JsonResult(_Customerdiscount.Edite(command));
        }
    }
}
