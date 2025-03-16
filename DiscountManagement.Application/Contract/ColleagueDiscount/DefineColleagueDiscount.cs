using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.CustomerDiscount;

namespace DiscountManagement.Application.Contract.ColleagueDiscount
{
    public class DefineColleagueDiscount
    {
        public long ProductID { get; set; }
        public int DicountRate { get; set; }
        public string CrationDate { get; set; }
        public List<ProductView> Products { get; set; }
    }
}
