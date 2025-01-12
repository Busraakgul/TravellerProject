using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.Controllers
{
    public class AdminController : Controller
    {
        //[Area("Admin")]
        //[Route("Admin/[controller]/[action]/{id?}")]
        //[AllowAnonymous]
        public PartialViewResult PartialHeader()
        {
            return PartialView();
        }


        public PartialViewResult PartialAppBrandDemo()
        {
            return PartialView();
        }

        public PartialViewResult PartialSideBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}
