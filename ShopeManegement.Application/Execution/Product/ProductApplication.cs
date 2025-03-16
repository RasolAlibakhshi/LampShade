using _0_Framework.Application;
using ShopeManagement.Infrastructure.DTO;
using ShopeManegement.Application.Contract.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ShopeManegement.Application.Execution.Product
{
    public class ProductApplication : IProductApplication
    {
        private readonly IRepository<ShopeManagement.Domain.ProductAgg.Product> _ProductApplication;
        public ProductApplication(IRepository<ShopeManagement.Domain.ProductAgg.Product> _productApplication)
        {
            _ProductApplication = _productApplication;
        }
        public OpreationResult Create(CreateProduct Command)
        {
            var opreation = new OpreationResult();
            if (Command == null)
            {
                return opreation.Failed(ApplicationMessages.InputNull);
            }
            else
            {
                if (_ProductApplication.Exite(x => x.Name == Command.Name))
                {
                    return opreation.Failed(ApplicationMessages.DuplicatedRecord);
                }
                else
                {
                    _ProductApplication.Create(new ShopeManagement.Domain.ProductAgg.Product(Command.CategoryId, Command.Name, Command.UnitPrice
                        , Command.Code, Command.ShortDescription, Command.Description
                        , Command.Picture, Command.PictureAlt, Command.PictureTitle, Command.Slug.Slugify()
                        , Command.Keywords, Command.MetaDescription));
                    _ProductApplication.SaveChange();
                    return opreation.Success();
                }
            }
        }

        public OpreationResult Edite(EditeProduct Command)
        {
            var opreation = new OpreationResult();
            if (Command == null)
            {
                return opreation.Failed(ApplicationMessages.InputNull);
            }
            else
            {
                if (_ProductApplication.Exite(x => x.ID == Command.ID))
                {
                    if (_ProductApplication.Exite(x => x.Name==Command.Name && x.ID!=Command.ID))
                    {
                        return opreation.Failed(ApplicationMessages.DuplicatedRecord);
                    }
                    else
                    {
                        _ProductApplication.Getby(x => x.ID == Command.ID).Edite(Command.CategoryId, Command.Name, Command.UnitPrice
                        , Command.Code, Command.ShortDescription, Command.Description
                        , Command.Picture, Command.PictureAlt, Command.PictureTitle, Command.Slug.Slugify()
                        , Command.Keywords, Command.MetaDescription);
                        _ProductApplication.SaveChange();
                        return opreation.Success();
                    }
                }
                else
                {
                    return opreation.Failed(ApplicationMessages.RecordNotFound);
                }
            }
        }

        public ShopeManagement.Domain.ProductAgg.Product Getdetails(long id)
        {
            return _ProductApplication.Getby(x => x.ID==id);
        }

        public OpreationResult Instock(long id)
        {
            var opreation = new OpreationResult();
            if (_ProductApplication.Exite(x => x.ID == id))
            {
                _ProductApplication.Getby(x => x.ID == id).Instuck();
                _ProductApplication.SaveChange();
                return opreation.Success();
            }
            else
            {
                return opreation.Failed(ApplicationMessages.RecordNotFound);
            }
        }

        public OpreationResult NotInstock(long id)
        {
            var opreation = new OpreationResult();
            if (_ProductApplication.Exite(x => x.ID == id))
            {
                _ProductApplication.Getby(x => x.ID == id).NotInstuck();
                _ProductApplication.SaveChange();
                return opreation.Success();
            }
            else
            {
                return opreation.Failed(ApplicationMessages.RecordNotFound);
            }
        }

        public OpreationResult Remove(long id)
        {
            var opreation = new OpreationResult();
            if (_ProductApplication.Exite(x => x.ID == id))
            {
                _ProductApplication.Getby(x => x.ID == id).Remove();
                _ProductApplication.SaveChange();
                return opreation.Success();
            }
            else
            {
                return opreation.Failed(ApplicationMessages.RecordNotFound);
            }
        }

        public OpreationResult Restore(long id)
        {
            var opreation = new OpreationResult();
            if (_ProductApplication.Exite(x => x.ID == id))
            {
                _ProductApplication.Getby(x => x.ID == id).Instuck();
                _ProductApplication.SaveChange();
                return opreation.Success();
            }
            else
            {
                return opreation.Failed(ApplicationMessages.RecordNotFound);
            }
        }

        public List<ProductViewModel> Search(ProductSearchModel Command)
        {
            var query = _ProductApplication.GetAll();

            if (!string.IsNullOrWhiteSpace(Command.Name))
            {
                query = (List<ShopeManagement.Domain.ProductAgg.Product>)query.Where(x => x.Name.ToLower().Contains(Command.Name.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(Command.Code))
            {
                query = (List<ShopeManagement.Domain.ProductAgg.Product>)query.Where(x => x.Code.ToLower().Contains(Command.Code.ToLower()));
            }

            if (Command.CategoryId > 0)
            {
                query = (List<ShopeManagement.Domain.ProductAgg.Product>)query.Where(x => x.CategoryId == Command.CategoryId);
            }

            return query.Select(x => new ProductViewModel
            {
                ID = x.ID,
                Name = x.Name,
                Code = x.Code,
                UnitPrice = x.UnitPrice,
                CategoryName = x.Category?.Name ?? "",
                CategoryId = x.CategoryId,
                CreationDate=x.CreateDateTime.ToFarsi(),
                Picture=x.Picture
            }).OrderByDescending(x => x.ID).ToList();
        }

    }
}
