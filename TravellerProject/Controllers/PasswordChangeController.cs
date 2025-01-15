using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravellerProject.Models;

namespace TravellerProject.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found");
                    return View();
                }

                string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
                {
                    userId = user.Id,
                    token = passwordResetToken
                }, HttpContext.Request.Scheme);

                MimeMessage mimeMessage = new MimeMessage();
<<<<<<< HEAD
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "SenderMail");
=======
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "aaaaa@gmail.com");
>>>>>>> 7e0c4defcda8d4f59bff7ad85a995e551f726ad1
                mimeMessage.From.Add(mailboxAddressFrom);

                MailboxAddress mailAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
                mimeMessage.To.Add(mailAddressTo);

                var bodyBuilder = new BodyBuilder
                {
                    TextBody = passwordResetTokenLink
                };
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Password Change Confirmation";

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
<<<<<<< HEAD
                    smtpClient.Authenticate("SenderMail", "aaaaaaaaaaaaaa");
=======
                    smtpClient.Authenticate("aaaaa@gmail.com", "aaaaaa");
>>>>>>> 7e0c4defcda8d4f59bff7ad85a995e551f726ad1
                    smtpClient.Send(mimeMessage);
                    smtpClient.Disconnect(true);

                }

                ViewBag.Message = "Password reset link has been sent to your email.";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "An error occurred: " + ex.Message;
            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userid, string token)
        {
            TempData["userid"] = userid;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"] ;
            if(userid == null || token == null)
            {
                //hata mesadı
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }


    }
}

