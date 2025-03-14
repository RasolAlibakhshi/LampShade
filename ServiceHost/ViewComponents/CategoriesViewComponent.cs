using _01_LampShadeQuery.Contratcts.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _categoryQuery;

        public CategoriesViewComponent(IProductCategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            return View(_categoryQuery.GetProductCategories());
        }
    }
}
