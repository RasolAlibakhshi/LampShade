using _01_LampShadeQuery.Contratcts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryWhitProductsViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryWhitProductsViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            return View(_productCategoryQuery.GetProductCategoriesWhitProduct());
        }
    }
}
