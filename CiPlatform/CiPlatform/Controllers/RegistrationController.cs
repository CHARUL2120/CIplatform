using CiPlatform.Entities.Data;
using CiPlatform.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace CiPlatform.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly CiPlatformContext _ciPlatformContext;
        //private readonly object userManager;
        //private readonly IEmailRepository _emailRepository;



        public RegistrationController(CiPlatformContext ciPlatformContext)
        {
            _ciPlatformContext = ciPlatformContext;
            //_emailRepository = emailRepository;
        }


        [HttpGet]
        public IActionResult registration()
        {

            return View();
        }

        [HttpPost]
        public IActionResult registration(User user)
        {
            try
            {
                /* CiPlatformContext ciPlatformContext = new CiPlatformContext();*/

                var userDetails = new User()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Password = user.Password,
                    CityId = 1,
                    CountryId = 1,
                    CreatedAt = DateTime.Now,
                };


                _ciPlatformContext.Users.Add(userDetails);
                _ciPlatformContext.SaveChanges();
                ViewBag.Status = 1;
                return RedirectToAction("login", "Home");

            }

            catch
            {
                ViewBag.Status = 0;
                return View();
            }

        }

        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(User user)
        {

            //CiPlatformContext _ciPlatformContext = new CiPlatformContext();
            User cuser = new();
            var temp = _ciPlatformContext.Users.Where(x => x.Email == user.Email.Trim() && x.Password == user.Password.Trim()).Select(x => new { x.Email, x.Password }).FirstOrDefault();
            if (temp != null)
            {
                ViewBag.Status = 1;
                return RedirectToAction("Missions", "Home");
            }


            else
            {
                ViewBag.Status = 0;
                return RedirectToAction("login", "Home");
            }


            //var cuser = _ciPlatformContext.GetUserEmail(user.Email);
            //if (cuser != null && user.Password.Equals(user.Password) && !ModelState.IsValid)
            //{
            //    return RedirectToAction("Missions", "Home");
            //}
            //else
            //{
            //    return View();
            //}
        }



    }
}
