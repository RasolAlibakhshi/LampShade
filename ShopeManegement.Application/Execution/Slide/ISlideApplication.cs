using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Slide
{
    public interface ISlideApplication
    {
        OpreationResult Create(CreateSlide command);
        OpreationResult Edit(EditSlide command);
        OpreationResult Remove(long id);
        OpreationResult Restore(long id);
        EditSlide GetDetails(long id);
        List<SlideViewModel> GetList();
    }
}
