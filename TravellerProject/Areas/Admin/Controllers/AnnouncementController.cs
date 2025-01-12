using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravellerProject.Areas.Admin.Models;

namespace TravellerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            //Bu uzun kod aşağıdaki mapper ile tek satırda tamamlanıyor
            //List<Announcement> announcements = _announcementService.TGetList();
            //List<AnnouncementListViewModel> model = new List<AnnouncementListViewModel>();
            //foreach(var item in announcements)
            //{
            //    AnnouncementListViewModel announcementListViewModel = new AnnouncementListViewModel();
            //    announcementListViewModel.ID = item.AnnouncementID;
            //    announcementListViewModel.Title = item.Title;
            //    announcementListViewModel.Content = item.Content;

            //    model.Add(announcementListViewModel);

            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetList());
            return View(values);

        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            //ekleme işlemi gerçekleştirme
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementService.TGetByID(id);
            _announcementService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetByID(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO announcementUpdate)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement()
                {
                    AnnouncementID = announcementUpdate.AnnouncementID,
                    Content = announcementUpdate.Content,
                    Title = announcementUpdate.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");
            }
            return View(announcementUpdate);
        }

        public IActionResult DetailsAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementDetailDTO>(_announcementService.TGetByID(id));
            return View(values);
        }

    }
}
