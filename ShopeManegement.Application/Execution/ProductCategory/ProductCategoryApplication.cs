using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using ShopeManagement.Infrastructure.DTO;
using ShopeManegement.Application.Contract.ProductCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopeManegement.Application.Execution.ProductCategory
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IRepository<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory> _productCategoryAggRepository;

        public ProductCategoryApplication(IRepository<ShopeManagement.Domain.ProductCategoryAgg.ProductCategory> productCategoryAggRepository)
        {
            _productCategoryAggRepository = productCategoryAggRepository;
        }
        public OpreationResult Create(CreateProductCategory Command)
        {
            var opreationResault = new OpreationResult();
            if (_productCategoryAggRepository.Exite(x => x.Name==Command.Name))
            {
                return opreationResault.Failed("نام رکورد تکراری است.");
            }
            else
            {
                _productCategoryAggRepository.Create(new ShopeManagement.Domain.ProductCategoryAgg
                    .ProductCategory(Command.Name, Command.Description, Command.Picutre, Command.PictureAlt, Command.PictureTitle, Command.Slug.Slugify(), Command.Keywords, Command.MetaDescription));
                _productCategoryAggRepository.SaveChange();
                return opreationResault.Success();
            }

        }

        public OpreationResult Edite(EditeProductCategory Command)
        {
            var data = _productCategoryAggRepository.Getby(x => x.ID == Command.ID);
            var opreationResault = new OpreationResult();
            if (data == null)
            {
                return opreationResault.Failed("رکورد با اطلاعات در خواست شده یافت نشد.");
            }


            if (_productCategoryAggRepository.Exite(x => x.Name == Command.Name && x.ID != Command.ID))
            {

                return opreationResault.Failed("نام رکورد تکراری است.");
            }

            data.Edite(Command.Name, Command.Description, Command.Picutre, Command.PictureAlt, Command.PictureTitle, Command.Slug.Slugify(), Command.Keywords, Command.MetaDescription);
            _productCategoryAggRepository.SaveChange();
            return opreationResault.Success();



        }

        public ShopeManagement.Domain.ProductCategoryAgg.ProductCategory Getdetails(long id)
        {
            return _productCategoryAggRepository.Getby(x => x.ID == id);
        }

        public OpreationResult Remove(long id)
        {
            var data = _productCategoryAggRepository.Getby(x => x.ID == id);
            var opreationResault = new OpreationResult();
            if (data == null)
            {
                return opreationResault.Failed("رکورد با اطلاعات در خواست شده یافت نشد.");
            }
            data.Remove();
            _productCategoryAggRepository.SaveChange();
            return opreationResault.Success();
        }

        public OpreationResult Restore(long id)
        {
            var data = _productCategoryAggRepository.Getby(x => x.ID == id);
            var opreationResault = new OpreationResult();
            if (data == null)
            {
                return opreationResault.Failed("رکورد با اطلاعات در خواست شده یافت نشد.");
            }
            data.Restore();
            _productCategoryAggRepository.SaveChange();
            return opreationResault.Success();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel Command)
        {
            var data= _productCategoryAggRepository.GetAll().Select(x =>
                new ProductCategoryViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Picutre = x.Picutre,
                    CreationDate = x.CreateDateTime.ToString()
                }).ToList();
            if (!string.IsNullOrWhiteSpace(Command.Name))
            {
                data = data.Where(x => x.Name == Command.Name).ToList();
            }
            return data.OrderByDescending(x=>x.ID).ToList();
        }
    }
}
