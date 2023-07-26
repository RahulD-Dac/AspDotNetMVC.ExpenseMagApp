using Microsoft.AspNetCore.Mvc;
using ExpenseMangementApp.DataLayer;
using ExpenseMangementApp.Models;

namespace ExpenseMangementApp.Controllers
{
    public class UserProfileController : Controller
    {
        public readonly DBContextExpMgt _context;

        public UserProfileController(DBContextExpMgt context)
        {
            _context = context;
        }

        public IActionResult Login( string EmailAddress, String Password)
        {
            ViewBag.LoginStatus = "";

            if (ModelState.IsValid)
            {
                var userCheck = _context.UserProfile.FirstOrDefault
                    (a=> a.EmailAddress == EmailAddress && a.Password == Password);

                if (userCheck==null)
                {
                    ViewBag.LoginStatus = "Invalid login User Not Found";
                  }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            
            return View();
        }



        public IActionResult Registration(UserProfile userDetails)
        {
             if (ModelState.IsValid)
            {
                _context.UserProfile.Add(userDetails);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }

            return View();
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
