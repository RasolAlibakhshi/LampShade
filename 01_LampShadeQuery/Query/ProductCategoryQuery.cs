using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_LampShadeQuery.Contratcts.ProductCategory;
using ShopeManagement.Domain.ProductCategoryAgg;
using ShopeManagement.Infrastructure.DTO;

namespace _01_LampShadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly IRepository<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory> _productCategoryAggRepository;

        public ProductCategoryQuery(IRepository<ProductCategory> productCategoryAggRepository)
        {
            _productCategoryAggRepository = productCategoryAggRepository;
        }
        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _productCategoryAggRepository.GetAll().Where(x => x.IsDeleted == false).OrderByDescending(x=>x.ID)
                .Select(x => new ProductCategoryQueryModel
                {
                    Name = x.Name,
                    Picutre = x.Picutre,
                    Description = x.Description,
                    Slug = x.Slug,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ID = x.ID
                }).ToList();
        }
    }
}
