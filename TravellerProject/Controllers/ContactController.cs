using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.ContactDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        //ContactUsManager contactUsManager = new ContactUsManager(new EFContactUsDal());
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactController(IContactUsService contactUsService, IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(SendMessageDTO sendMessageDTO)
        {
            //ekleme işlemi gerçekleştirme
            if (ModelState.IsValid)
            {
                _contactUsService.TAdd(new ContactUs()
                {
                    MessageBody = sendMessageDTO.MessageBody,
                    Mail= sendMessageDTO.Mail,
                    MessageStatus = true,
                    Name = sendMessageDTO.Name,
                    Subject = sendMessageDTO.Subject,
                    MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Default");
            }
            return View(sendMessageDTO);
        }
    }
}
