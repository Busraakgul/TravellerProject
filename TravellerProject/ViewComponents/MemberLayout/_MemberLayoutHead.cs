﻿using Microsoft.AspNetCore.Mvc;

namespace TravellerProject.ViewComponents.MemberLayout
{
    public class _MemberLayoutHead: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
