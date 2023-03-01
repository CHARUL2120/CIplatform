using CiPlatform.Entities.Data;
using CiPlatform.Entities.Models;
using CiPlatform.Entities.ViewModels;
using CiPlatform.Models;
using CiPlatform.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CiPlatform.Controllers
{
    public class HomeController : Controller
    {
        private readonly CiPlatformContext _ciPlatformContext;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailRepository _emailRepository;
        public HomeController(ILogger<HomeController> logger, IEmailRepository emailRepository, CiPlatformContext ciPlatformContext)
        {
            _logger = logger;
            _emailRepository = emailRepository;
            _ciPlatformContext = ciPlatformContext;
        }

        //loginDetails db = new loginDetails();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[AllowAnonymous]
        public IActionResult login()
        {
            return View();
        }



        public IActionResult Missions()
        {
            return View();
        }
        public IActionResult registration()
        {
            return View();
        }
        [HttpGet]
        public IActionResult forgetpassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult forgetpassword(ForgotPasswordViewModel model)
        {
            //string emailadd = user.Email;
            //byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            //byte[] key = Guid.NewGuid().ToByteArray();
            //string token = Convert.ToBase64String(time.Concat(key).ToArray());

            //_emailRepository.SendEmail("meetpanchal194@gmail.com", "password bhulgaya? Le karle reset", "https://localhost:44387/Home/resetpassword?token="   );



            string To = model.Email, UserID, Password, SMTPPort, Host;
            string emailadd = model.Email;
            byte[] time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(time.Concat(key).ToArray());
            if (token == null)
            {
                // If user does not exist or is not confirmed.
                return View("Index");
            }
            else
            {
                //Create URL with above token


                var lnkHref = "https://localhost:44387/Home/resetpassword?token=" + token + "&email=" + model.Email;
                //HTML Template for Send email
                string subject = "Your changed password";
                string body = "Reset your the Password Reset Link." + lnkHref;
                ////Get and set the AppSettings using configuration manager.
                //EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);
                ////Call send email methods.
                //EmailManager.SendEmail(UserID, subject, body, To, UserID, Password, SMTPPort, Host);
                _emailRepository.SendEmail(model.Email, subject, body);
            }
            //if (WebSecurity.UserExists(UserName))


            return View();
        }

        [HttpGet]
        public IActionResult resetpassword(string token, string email)
        {
            if (token != null)
            {
                ResetPasswordViewModel rs = new ResetPasswordViewModel();
                rs.Email = email;
                return View(rs);
            }
            return View();
        }

        [HttpPost]
        public IActionResult resetpassword(ResetPasswordViewModel model)
        {
            User userData = (User)_ciPlatformContext.Users.Where(x => x.Email == model.Email).FirstOrDefault();
            userData.Password = model.Password;

            _ciPlatformContext.Users.Update(userData);
            _ciPlatformContext.SaveChanges();
            return RedirectToAction("login", "Home");

        }


        public IActionResult error404()
        {
            return View();
        }
        public IActionResult VolunteerMission()
        {
            return View();
        }

        public IActionResult storyListing()
        {
            return View();
        }

        public IActionResult ShareStory()
        {
            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}