using _0_Framework.Application;
using ShopeManegement.Application.Contract.Product;
using ShopeManegement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeManegement.Application.Execution.Product
{
    public interface IProductApplication
    {
        OpreationResult Create(CreateProduct Command);
        OpreationResult Edite(EditeProduct Command);
        ShopeManagement.Domain.ProductAgg.Product Getdetails(long id);
        List<ProductViewModel> Search(ProductSearchModel Command);
        OpreationResult Remove(long id);
        OpreationResult Restore(long id);
        OpreationResult Instock(long id);
        OpreationResult NotInstock(long id);
    }
}
