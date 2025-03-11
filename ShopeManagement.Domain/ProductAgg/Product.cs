using _0_Framework;
using ShopeManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopeManagement.Domain.ProductAgg
{
    public class Product:EntitiyBase
    {
        public string Name { get; private set; }
        
        public double UnitPrice { get; private set; }
        public string Code { get; private set; }
        public bool IsInstock { get; private set; }
        public string ShortDescription { get; private set; }
        public long CategoryId { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }

        public ProductCategory Category { get; private set; }


        public Product()
        {
            
        }
        public Product(long categoryid,string name,double unitPrice,string code
            ,string shortdescription,string description,string picture,string pictureAlt
            ,string pictureTitle,string slug,string keywords,string metadescription)
        {
            CategoryId = categoryid;
            Name = name;
            UnitPrice = unitPrice;
            Code = code;
            ShortDescription = shortdescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metadescription;
            IsInstock = true;
            CreateDateTime = CreateDateTime;
            IsDeleted = false;
        }
        public void Edite(long categoryid, string name, double unitPrice, string code
            , string shortdescription, string description, string picture, string pictureAlt
            , string pictureTitle, string slug, string keywords, string metadescription) 
        {
            CategoryId = categoryid;
            Name = name;
            UnitPrice = unitPrice;
            Code = code;
            ShortDescription = shortdescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metadescription;
        }
        public void Instuck() 
        {
            IsInstock=true;
        }
        public void NotInstuck()
        {
            IsInstock = false;
        }
        public void Remove()
        {
            IsDeleted=true;
        }
        public void Restore() 
        {
            IsDeleted = false;
        }

    }
}
