using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManagement.Application.Contract.ColleagueDiscount;

namespace DiscountManagement.Application.Execution.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        OpreationResult Define(DefineColleagueDiscount Command);
        OpreationResult Edite(EditColleagueDiscount Command);
        EditColleagueDiscount Getdetails(long id);
        List<ColleagueDiscointViewModel> Search(ColleagueDiscountSearchModel Command);
        OpreationResult Remove(long id);
        OpreationResult Restore(long id);
    }
}
