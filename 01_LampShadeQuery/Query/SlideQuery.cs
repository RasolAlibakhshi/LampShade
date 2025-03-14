using _01_LampShadeQuery.Contratcts.Slide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopeManagement.Domain.SlideAgg;
using ShopeManagement.Infrastructure.DTO;

namespace _01_LampShadeQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly IRepository<Slide> _slideRepository;

        public SlideQuery(IRepository<Slide> slideRepository)
        {
            _slideRepository = slideRepository;
        }
        public List<SlideQueryModel> GetSlides()
        {
            return _slideRepository.GetAll().Where(x=>x.IsRemoved==false).OrderByDescending(x=>x.ID).Select(x => new SlideQueryModel
            {
                BtnText = x.BtnText,
                Heading = x.Heading,
                IsRemoved = x.IsRemoved,
                Link = x.Link,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Title = x.Title
            }).ToList();
        }
    }
}
