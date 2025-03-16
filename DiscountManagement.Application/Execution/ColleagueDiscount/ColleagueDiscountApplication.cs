using _0_Framework.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Application.Contract.CustomerDiscount;
using ShopeManagement.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Execution.ColleagueDiscount
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IRepository<Domain.ColleagueDiscountAgg.ColleagueDiscount> _ColleagueReopsitory;
        
        public ColleagueDiscountApplication(IRepository<Domain.ColleagueDiscountAgg.ColleagueDiscount> _colleagueReopsitory)
        {
            _ColleagueReopsitory=_colleagueReopsitory;
        }

        public OpreationResult Define(DefineColleagueDiscount Command)
        {
            var result = new OpreationResult();
            if (_ColleagueReopsitory.Exite(x => x.ProductID == Command.ProductID && x.DicountRate==Command.DicountRate))
                return result.Failed(ApplicationMessages.DuplicatedRecord);
            _ColleagueReopsitory.Create(new Domain.ColleagueDiscountAgg.ColleagueDiscount(Command.ProductID, Command.DicountRate));
            _ColleagueReopsitory.SaveChange();
            return result.Success();
        }

        public OpreationResult Edite(EditColleagueDiscount Command)
        {
            var result = new OpreationResult();
            var data = _ColleagueReopsitory.Getby(x => x.ID == Command.ID);
            if (data==null)
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }
            if (_ColleagueReopsitory.Exite(x => x.ID != Command.ID && x.ProductID == Command.ProductID && x.DicountRate == Command.DicountRate))
                return result.Failed(ApplicationMessages.DuplicatedRecord);
            data.Edit(Command.ProductID,Command.DicountRate);
            _ColleagueReopsitory.SaveChange();
            return result.Success();
        }

        public EditColleagueDiscount Getdetails(long id)
        {
            var data = _ColleagueReopsitory.Getby(x => x.ID == id);
            return new EditColleagueDiscount
            {
                ID = data.ID,
                ProductID = data.ProductID,
                DicountRate = data.DicountRate
            };
        }

        public OpreationResult Remove(long id)
        {
            var result = new OpreationResult();
            var data = _ColleagueReopsitory.Getby(x => x.ID==id);
            if (data==null)
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }

            data.Remove();
            _ColleagueReopsitory.SaveChange();
            return result.Success();
        }

        public OpreationResult Restore(long id)
        {
            var result = new OpreationResult();
            var data = _ColleagueReopsitory.Getby(x => x.ID==id);
            if (data==null)
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }

            data.Restore();
            _ColleagueReopsitory.SaveChange();
            return result.Success();
        }

        public List<ColleagueDiscointViewModel> Search(ColleagueDiscountSearchModel Command)
        {
            var query = _ColleagueReopsitory.GetAll();
            if (Command.ProductID>0)
            {
                query = query.Where(x => x.ProductID == Command.ProductID).ToList();
            }
            return query.Select(x => new ColleagueDiscointViewModel
            {
                ProductID = x.ProductID,
                CrationDate = x.CreateDateTime.ToFarsi(),
                DicountRate = x.DicountRate,
                IsRemove = x.IsDeleted,
                ID = x.ID
            }).OrderByDescending(x=>x.ProductID).ToList();
        }
    }
}
