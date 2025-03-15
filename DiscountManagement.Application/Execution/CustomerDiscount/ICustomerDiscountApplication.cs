using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.CustomerDiscount;

namespace DiscountManagement.Application.Execution.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        OpreationResult Create(DefineCustomerDiscount Command);
        OpreationResult Edite(EditeCustomerDiscount Command);
        EditeCustomerDiscount Getdetails(long id);
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel Command);
        OpreationResult Remove(long id);
        OpreationResult Restore(long id);
    }
}
