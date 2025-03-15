
using _0_Framework;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount:EntitiyBase
    {
        public long ProductID { get; private set; }
        public int DiscountRate { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set;}
        public string Reason { get; private set; }

        public CustomerDiscount()
        {
            
        }

        public CustomerDiscount(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductID = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
            CreateDateTime=DateTime.Now;
            IsDeleted = false;
        }

        public void Edite(long productId, int discountRate, DateTime startDate, DateTime endDate, string reason)
        {
            ProductID = productId;
            DiscountRate = discountRate;
            StartDate = startDate;
            EndDate = endDate;
            Reason = reason;
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
