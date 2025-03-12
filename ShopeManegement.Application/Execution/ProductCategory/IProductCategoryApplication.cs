using _0_Framework.Application;
using ShopeManegement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeManegement.Application.Execution.ProductCategory
{
    public interface IProductCategoryApplication
    {
        OpreationResult Create(CreateProductCategory Command);
        OpreationResult Edite (EditeProductCategory Command);
        ShopeManagement.Domain.ProductCategoryAgg.ProductCategory Getdetails(long id);
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel Command);
        OpreationResult Remove(long id);
        OpreationResult Restore(long id);
        List<SelectListProductCategory> selectList();
   }
}
