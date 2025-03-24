using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using _01_LampShadeQuery.Contratcts.Product;
using _01_LampShadeQuery.Contratcts.ProductCategory;
using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastractuer;
using Microsoft.EntityFrameworkCore;
using ShopeManagement.Domain.ProductAgg;
using ShopeManagement.Domain.ProductCategoryAgg;
using ShopeManagement.Infrastructure;
using ShopeManagement.Infrastructure.DTO;

namespace _01_LampShadeQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopeManagagementContext _productCategoryAggRepository;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountManagementContext _DiscountContext;

        public ProductCategoryQuery(ShopeManagagementContext productCategoryAggRepository, InventoryContext inventoryContext, DiscountManagementContext discountContext)
        {
            _productCategoryAggRepository = productCategoryAggRepository;
            _inventoryContext = inventoryContext;
            _DiscountContext = discountContext;
        }
        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _productCategoryAggRepository.ProductCategories.Where(x => x.IsDeleted == false).OrderByDescending(x => x.ID)
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

        public List<ProductCategoryQueryModel> GetProductCategoriesWhitProduct()
        {
            var discount = _DiscountContext.CustomerDiscount.Where(x=>x.EndDate>DateTime.Now).Select(x => new { x.ProductID, x.DiscountRate });
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ID, x.ProductID, x.UnitPrice }).ToList();
            var category = _productCategoryAggRepository.ProductCategories.Include(x => x.products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQueryModel
                {
                    ID = x.ID,
                    Description = x.Description,
                    Name = x.Name,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Picutre = x.Picutre,
                    Slug = x.Slug,
                    Products = MapProducts(x.products)
                }).ToList();
            foreach (var item in category)
            {
                foreach (var product in item.Products)
                {

                    var inventoryinfo = inventory.FirstOrDefault(x => x.ProductID == product.ID);
                    if (inventoryinfo != null)
                    {
                        double price = inventoryinfo.UnitPrice;
                       
                            product.Price = price.ToMoney();
                            var discou = discount.FirstOrDefault(x => x.ProductID == product.ID);
                            if (discou!=null)
                            {
                                product.DiscountRate = discou.DiscountRate;
                                product.HasDiscount = discou.DiscountRate > 0;
                                if (product.HasDiscount)
                                {
                                    product.PriceWithDiscount = (price - Math.Round(price * product.DiscountRate) / 100).ToMoney();
                                }
                            }

                        
                    }
                    



                }
            }

            return category;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> xProducts)
        {
            return xProducts.Select(x => new ProductQueryModel
            {
                ID = x.ID,
                Slug = x.Slug,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PictureURL = x.Picture,
                CategoryName = x.Category.Name,

            }).OrderByDescending(x => x.ID).ToList();
        }
    }
}
