using _0_Framework.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopeManagement.Domain.ProductAgg;
using ShopeManagement.Infrastructure.DTO;

namespace DiscountManagement.Application.Execution.CustomerDiscount
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly IRepository<DiscountManagement.Domain.CustomerDiscountAgg.CustomerDiscount> _customerDiscountAggRepository;


        public CustomerDiscountApplication(IRepository<Domain.CustomerDiscountAgg.CustomerDiscount> customerDiscountAggRepository)
        {
            _customerDiscountAggRepository = customerDiscountAggRepository;

        }
        public OpreationResult Create(DefineCustomerDiscount Command)
        {
            var result = new OpreationResult();
            if (_customerDiscountAggRepository.Exite(x => x.ProductID == Command.ProductID && x.DiscountRate==Command.DiscountRate))
                return result.Failed(ApplicationMessages.DuplicatedRecord);
            _customerDiscountAggRepository.Create(new Domain.CustomerDiscountAgg
                .CustomerDiscount(Command.ProductID, Command.DiscountRate, Command.StartDate.ToGeorgianDateTime(), Command.EndDate.ToGeorgianDateTime(), Command.Reason));
            _customerDiscountAggRepository.SaveChange();
            return result.Success();
        }

        public OpreationResult Edite(EditeCustomerDiscount Command)
        {
            var result = new OpreationResult();
            var data = _customerDiscountAggRepository.Getby(x => x.ID == Command.ID);
            if (data==null)
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }
            if (_customerDiscountAggRepository.Exite(x =>
                    x.ID != Command.ID && x.ProductID == Command.ProductID && x.DiscountRate == Command.DiscountRate))
                return result.Failed(ApplicationMessages.DuplicatedRecord);
            data.Edite(Command.ProductID, Command.DiscountRate, Command.StartDate.ToGeorgianDateTime(), Command.EndDate.ToGeorgianDateTime(), Command.Reason);
            _customerDiscountAggRepository.SaveChange();
            return result.Success();
        }

        public EditeCustomerDiscount Getdetails(long id)
        {
            var data = _customerDiscountAggRepository.Getby(x => x.ID == id);
            return new EditeCustomerDiscount
            {
                ID = data.ID,
                StartDate = data.StartDate.ToFarsi(),
                EndDate = data.EndDate.ToFarsi(),
                DiscountRate = data.DiscountRate,
                Reason = data.Reason,
                ProductID = data.ProductID
            };
        }

        public OpreationResult Remove(long id)
        {
            var result = new OpreationResult();
            var data = _customerDiscountAggRepository.Getby(x => x.ID==id);
            if (data==null)
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }

            data.Remove();
            _customerDiscountAggRepository.SaveChange();
            return result.Success();


        }

        public OpreationResult Restore(long id)
        {
            var result = new OpreationResult();
            var data = _customerDiscountAggRepository.Getby(x => x.ID==id);
            if (data==null)
            {
                return result.Failed(ApplicationMessages.RecordNotFound);
            }

            data.Restore();
            _customerDiscountAggRepository.SaveChange();
            return result.Success();
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel Command)
        {
            var query = _customerDiscountAggRepository.GetAll();
            if (Command.ProductID>0)
            {
                query = query.Where(x => x.ProductID == Command.ProductID).ToList();
            }

            if (Equals(!string.IsNullOrWhiteSpace(Command.StartDate)))
            {

                query = query.Where(x => x.StartDate >=Command.StartDate.ToGeorgianDateTime()).ToList();
            }
            if (Equals(!string.IsNullOrWhiteSpace(Command.EndDate)))
            {

                query = query.Where(x => x.EndDate <=Command.EndDate.ToGeorgianDateTime()).ToList();
            }

            return query.OrderByDescending(x => x.ID).Select(x => new CustomerDiscountViewModel
            {
                StartDate = x.StartDate.ToFarsi(),
                EndDate = x.EndDate.ToFarsi(),
                DiscountRate = x.DiscountRate,
                ProductID = x.ProductID,
                Reason = x.Reason,

            }).ToList();
        }
    }
}
