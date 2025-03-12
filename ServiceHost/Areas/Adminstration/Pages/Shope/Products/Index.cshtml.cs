using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopeManegement.Application.Contract.Product;
using ShopeManegement.Application.Contract.ProductCategory;
using ShopeManegement.Application.Execution.Product;
using ShopeManegement.Application.Execution.ProductCategory;

namespace ServiceHost.Pages.Shope.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _ProductApplication;
        public readonly IProductCategoryApplication _ProductCategoryApplication;
        public IndexModel(IProductApplication _productApplication, IProductCategoryApplication _productCategoryApplication)
        {
            _ProductApplication = _productApplication;
            _ProductCategoryApplication= _productCategoryApplication;
        }
        public ProductSearchModel SearchModel { get; set; }
        public List<ProductViewModel> Products {  get; set; }
        public SelectList SelectList { get; set; }
        public void OnGet(ProductSearchModel searchModel)
        {
            SelectList=new SelectList(_ProductCategoryApplication.selectList(),"ID","Name");
            
            Products = _ProductApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var data = new CreateProduct();
            data.Categories = _ProductCategoryApplication.selectList();
            return Partial("./Create", data);
        }

        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _ProductApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id) 
        {
            ShopeManagement.Domain.ProductAgg.Product data = _ProductApplication.Getdetails(id);
            return Partial("./Edit", data);
        }
        public JsonResult OnPostEdit(EditeProduct command) 
        {
            return new JsonResult( _ProductApplication.Edite(command));
        }
    }
}
