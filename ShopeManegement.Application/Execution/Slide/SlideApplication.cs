using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Application;
using ShopeManagement.Infrastructure.DTO;
using ShopManagement.Application.Contracts.Slide;

namespace ShopeManegement.Application.Execution.Slide
{
    public class SlideApplication : ISlideApplication
    {
        private readonly IRepository<ShopeManagement.Domain.SlideAgg.Slide> _slideRepository;

        public SlideApplication(IRepository<ShopeManagement.Domain.SlideAgg.Slide> slideRepository)
        {
            _slideRepository = slideRepository;
        }
        public OpreationResult Create(CreateSlide command)
        {
            var operation = new OpreationResult();

            var pictureName = command.Picture;

            var slide = new ShopeManagement.Domain.SlideAgg.Slide(pictureName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);

            _slideRepository.Create(slide);
            _slideRepository.SaveChange();
            return operation.Success();
        }

        public OpreationResult Edit(EditSlide command)
        {
            var operation = new OpreationResult();
            var slide = _slideRepository.Getby(x=>x.ID==command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var pictureName = command.Picture;

            slide.Edit(pictureName, command.PictureAlt, command.PictureTitle,
                command.Heading, command.Title, command.Text, command.Link, command.BtnText);
            _slideRepository.SaveChange();
            return operation.Success();
        }

        public EditSlide GetDetails(long id)
        {
            var slide=_slideRepository.Getby(x => x.ID == id);
            var data = new EditSlide
            {
                Picture = slide.Picture,
                PictureAlt = slide.PictureAlt,
                PictureTitle = slide.PictureTitle,
                Heading = slide.Heading,
                Title = slide.Title,
                Text = slide.Text,
                Link = slide.Link,
                BtnText = slide.BtnText,
                Id = slide.ID
            };
            return data;
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetAll().Select(x => new SlideViewModel
            {
                Picture = x.Picture,
                CreationDate = x.CreateDateTime.ToFarsi(),
                Id = x.ID,
                Heading = x.Heading,
                Title = x.Title,
                IsRemoved = x.IsRemoved
            }).OrderByDescending(x=>x.Id).ToList();
        }

        public OpreationResult Remove(long id)
        {
            var operation = new OpreationResult();
            var slide = _slideRepository.Getby(x=>x.ID==id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Remove();
            _slideRepository.SaveChange();
            return operation.Success();
        }

        public OpreationResult Restore(long id)
        {
            var operation = new OpreationResult();
            var slide = _slideRepository.Getby(x => x.ID==id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            slide.Restore();
            _slideRepository.SaveChange();
            return operation.Success();
        }
    }
}
