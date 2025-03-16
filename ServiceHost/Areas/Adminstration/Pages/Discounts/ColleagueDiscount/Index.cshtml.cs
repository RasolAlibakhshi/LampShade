using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Application.Execution.ColleagueDiscount;
using DiscountManagement.Application.Execution.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopeManegement.Application.Contract.Product;
using ShopeManegement.Application.Execution.Product;


namespace ServiceHost.Pages.Discounts.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _ProductApplication;
        private readonly IColleagueDiscountApplication _Colleaguediscount;

        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleaguediscount)
        {
            _ProductApplication = productApplication;
            _Colleaguediscount = colleaguediscount;
        }
        public CustomerDiscountSearchModel SearchModel { get; set; }
        public List<ColleagueDiscointViewModel> Colleagediscount { get; set; }
        public List<ProductViewModel> SelectList { get; set; }
        public void OnGet(ColleagueDiscountSearchModel searchModel)
        {
            SelectList = _ProductApplication.Search(new ProductSearchModel());
            List<ColleagueDiscointViewModel> data = _Colleaguediscount.Search(searchModel);
             data.ForEach(x => x.ProductName=_ProductApplication.Getdetails(x.ProductID).Name);
             Colleagediscount = data;
        }
        public IActionResult OnGetCreate()
        {

            var data = new DefineColleagueDiscount();
            data.Products = _ProductApplication.Search(new ProductSearchModel())
                .Select(x => new ProductView { ID = x.ID, Name = x.Name }).ToList();
            return Partial("./Create", data);
        }

        public JsonResult OnPostCreate(DefineColleagueDiscount command)
        {
            var result = _Colleaguediscount.Define(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var data = _Colleaguediscount.Getdetails(id);
            data.Products=_ProductApplication.Search(new ProductSearchModel()).Select(x => new ProductView { ID = x.ID, Name = x.Name }).ToList();
            return Partial("./Edit", data);
        }
        public JsonResult OnPostEdit(EditColleagueDiscount command)
        {
            return new JsonResult(_Colleaguediscount.Edite(command));
        }

        public IActionResult OnGetRemove(long id)
        {
            _Colleaguediscount.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _Colleaguediscount.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
