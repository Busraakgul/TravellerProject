using BusinessLayer.Abstract.AbstractUoW;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TravellerProject.Areas.Admin.Models;

namespace TravellerProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AccountViewModel());
        }


        //[HttpPost]
        //public IActionResult Index(AccountViewModel account)
        //{
        //    var valueSender = _accountService.TGetByID(account.SenderID);
        //    var valueReceiver = _accountService.TGetByID(account.ReceiverID);

        //    //inputtan senderid, receiverid, amount alınacak
        //    valueSender.Balance -= account.Amount;
        //    valueReceiver.Balance += account.Amount;

        //    //Her iki hesabı bir yerde tutmak için list kullanıldı
        //    List<Account> modifiedAccounts = new List<Account>()
        //    {
        //        valueSender,valueReceiver
        //    };
        //    _accountService.TMultiUpdate(modifiedAccounts);

        //    return View();
        //}
        
        [HttpPost]
        public IActionResult Index(AccountViewModel account)
        {
            var valueSender = _accountService.TGetByID(account.SenderID);
            var valueReceiver = _accountService.TGetByID(account.ReceiverID);

            if (valueSender == null || valueReceiver == null)
            {
                ModelState.AddModelError("", "Invalid sender or receiver.");
                return View(account); // Model'i geri gönderiyoruz
            }

            if (valueSender.Balance < account.Amount)
            {
                ModelState.AddModelError("", "Insufficient balance.");
                return View(account);
            }

            try
            {
                valueSender.Balance -= account.Amount;
                valueReceiver.Balance += account.Amount;

                var transactionLogs = new List<TransactionLog>
        {
            new TransactionLog
            {
                AccountID = account.SenderID,
                Amount = -account.Amount,
                TransactionType = "Debit",
                Date = DateTime.Now
            },
            new TransactionLog
            {
                AccountID = account.ReceiverID,
                Amount = account.Amount,
                TransactionType = "Credit",
                Date = DateTime.Now
            }
        };

                _accountService.ProcessTransaction(new List<Account> { valueSender, valueReceiver }, transactionLogs);
                TempData["SuccessMessage"] = "Transaction successful.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Transaction failed: {ex.Message}";
            }

            return View(account); // Güncellenen model ile view döndürülüyor
        }
    }
}
