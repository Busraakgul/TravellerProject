using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using EntityLayer.Concrete;

namespace TravellerProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]

    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationService _destinationService;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId != null)
            {
                int appUserId = int.Parse(userId);
                var values = _commentService.TGetCommentsByUserWithDestination(appUserId);
                return View(values);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> MemberAddComment()
        {
            var user = await _userManager.GetUserAsync(User); // Giriş yapan kullanıcıyı al
            ViewBag.userID = user.Id; // Kullanıcı ID'sini View'a gönder

            // Destinations listesini ViewBag ile gönder
            ViewBag.Destinations = _destinationService.TGetList(); // Bu metod tüm destinasyonları döndürmeli
            return View();
        }

        [HttpPost]
        public IActionResult MemberAddComment(Comment p)
        {
            var user = _userManager.GetUserAsync(User).Result;

            if (p.DestinationID <= 0 || string.IsNullOrEmpty(p.CommentContent))
            {
                ModelState.AddModelError("", "All fields are required.");
                ViewBag.userID = user.Id;
                ViewBag.Destinations = _destinationService.TGetList();
                return View(p);
            }

            p.AppUserID = user.Id; // AppUserID'yi ata
            p.CommentDate = DateTime.Now;
            p.CommentState = true;

            _commentService.TAdd(p); // Yorum ekle
            return RedirectToAction("Index", "Comment");
        }




    }

}
