using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contratcts.ProductCategory
{
    public class ProductCategoryQueryModel
    {
        public long ID { get; set; }
        public string Name { get;  set; }
        public string Description { get; set; }
        public string Picutre { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
       
    }
}
