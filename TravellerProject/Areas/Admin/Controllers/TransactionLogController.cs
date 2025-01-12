using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Abstract.AbstractUoW;
using Microsoft.AspNetCore.Authorization;
using EntityLayer.Concrete; // TransactionLogService interface'i burada bulunmalı

namespace TravellerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class TransactionLogController : Controller
    {
        private readonly ITransactionLogService _transactionLogService;

        public TransactionLogController(ITransactionLogService transactionLogService)
        {
            _transactionLogService = transactionLogService;
        }

        public IActionResult Index()
        {
            return View();
        }

       //[HttpGet]
       // public IActionResult TransactionHistory(int accountId)
       // {
       //     // AccountId ile işlem geçmişini al
       //     var transactionLogs = _transactionLogService.TGetLogsByAccountId(accountId);

       //     // View'a model olarak transactionLogs gönder
       //     return View(transactionLogs);
       // }


        [HttpGet]
        public IActionResult TransactionHistory(int accountId)
        {
            if (accountId == 0)
            {
                TempData["ErrorMessage"] = "Invalid account ID.";
                return View(new List<TransactionLog>());
            }

            var transactionLogs = _transactionLogService.TGetLogsByAccountId(accountId);
            return View(transactionLogs);
        }

    }
}
