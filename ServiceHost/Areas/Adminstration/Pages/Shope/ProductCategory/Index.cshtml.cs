using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopeManegement.Application.Contract.ProductCategory;
using ShopeManegement.Application.Execution.ProductCategory;

namespace ServiceHost.Pages.Shope.ProductCategory
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication _ProductCategoryApplication;
        public IndexModel(IProductCategoryApplication _productCategoryApplication)
        {
            _ProductCategoryApplication = _productCategoryApplication;
        }
        public ProductCategorySearchModel SearchModel { get; set; }
        public List<ProductCategoryViewModel> ProductCategories {  get; set; }
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories= _ProductCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory command)
        {
            var result = _ProductCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id) 
        {
            ShopeManagement.Domain.ProductCategoryAgg.ProductCategory data = _ProductCategoryApplication.Getdetails(id);
            return Partial("./Edit", data);
        }
        public JsonResult OnPostEdit(EditeProductCategory command) 
        {
            return new JsonResult( _ProductCategoryApplication.Edite(command));
        }
    }
}
