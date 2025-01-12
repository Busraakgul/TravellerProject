using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravellerProject.CQRS.Command.GuideCommands;
using TravellerProject.CQRS.Query.GuideQueries;

namespace TravellerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());  //bu sefer requestin çağrıldığı sınıf newlendi
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGuideQuery(int id)
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }


        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(MakeGuideCommand makeGuideCommand)
        {
            await _mediator.Send(makeGuideCommand);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateGuide(int id)
        {
            var values = await _mediator.Send(new GetGuideByIDQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuide(UpdateGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveGuide(int id)
        {
            await _mediator.Send(new RemoveGuideCommand(id));
            return RedirectToAction("Index");

        }

    }
}
