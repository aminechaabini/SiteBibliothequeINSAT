using AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SiteBibliothequeINSAT.Data;
using SiteBibliothequeINSAT.Models;
using System.Security.Claims;

namespace SiteBibliothequeINSAT.Controllers
{
    public class StudentAccount : Controller
    {
        [HttpGet]
        public IActionResult Login() {
            if (User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Books");
            }
            Student student = new Student();
            return View(student);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(Models.Student s)
        {
            LibraryContext context = LibraryContext.Instantiate_LibraryContext();
            UnitOfWork u = new UnitOfWork(context);
            var result = u.Student.getStudentWithCredentials(s.email, s.password);
            if (result == null) return View();
            else
            {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, s.Id.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, "Users"));
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
                return RedirectToAction("Books", "Home");
            }
        }
        [Authorize]
        public  IActionResult  Logout()
            {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login", "StudentAccount");
            }
        }
    }
