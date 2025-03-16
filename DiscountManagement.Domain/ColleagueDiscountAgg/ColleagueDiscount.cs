using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount:EntitiyBase
    {
        public long ProductID { get; private set; }
        public int DicountRate { get; private set; }

        public ColleagueDiscount()
        {
            
        }

        public ColleagueDiscount(long productId, int dicountRate)
        {
            ProductID = productId;
            DicountRate = dicountRate;
            CreateDateTime=DateTime.Now;
            IsDeleted=false;
        }

        public void Edit(long productId, int dicountRate)
        {
            ProductID = productId;
            DicountRate = dicountRate;
        }

        public void Remove()
        {
            IsDeleted=true;
        }
        public void Restore()
        {
            IsDeleted=false;
        }
    }
}
