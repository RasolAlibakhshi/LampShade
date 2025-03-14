using _01_LampShadeQuery.Contratcts.Slide;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly ISlideQuery _query;

        public SliderViewComponent(ISlideQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            return View(_query.GetSlides());
        }
    }
}
