﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeManegement.Application.Contract.ProductCategory
{
    public class CreateProductCategory
    {
        public string Name { get;  set; }
        public string Description {  get; set; }
        public string Picutre { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get;  set; }
        
    }
}
