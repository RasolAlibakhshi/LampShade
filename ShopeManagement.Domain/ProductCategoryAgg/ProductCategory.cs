using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework;

namespace ShopeManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory:EntitiyBase
    {
        public string Name { get; private set; }
        public string Description { get; set; }
        public string Picutre { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public List<ProductAgg.Product> products { get; private set; }
        public ProductCategory()
        {
            products=new List<ProductAgg.Product>();
        }

        public ProductCategory(string name, string description, string picutre, string pictureAlt, string pictureTitle,string slug,string keywords,string metaDescription)
        {
            Name = name;
            Description = description;
            Picutre = picutre;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void Edite(string name, string description, string picutre, string pictureAlt, string pictureTitle, string slug, string keywords, string metaDescription)
        {
            Name = name;
            Description = description;
            Picutre = picutre;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Restore()
        {
            IsDeleted = false;
        }
    }
}
