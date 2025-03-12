
using _0_Framework.Application;
using ShopeManegement.Application.Contract.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopeManegement.Application.Contract.Product
{
    public class CreateProduct
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get;  set; }
        [Range(0,int.MaxValue,ErrorMessage = ValidationMessages.MaxLenght)]
        public double UnitPrice { get;  set; }
        public string Code { get;  set; }
        public string ShortDescription { get;  set; }
        public long CategoryId { get;  set; }
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        public List<SelectListProductCategory> Categories { get; set; }
    }
    



}
