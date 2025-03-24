using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_LampShadeQuery.Contratcts.Product
{
    public class ProductQueryModel
    {
        public long ID { get; set; }
        public string PictureURL { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string PriceWithDiscount { get; set; }
        public int DiscountRate { get; set; }
        public string CategoryName { get; set; }
        public string Slug { get; set; }
        public bool HasDiscount { get; set; }
    }
}
