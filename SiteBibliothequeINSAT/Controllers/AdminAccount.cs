using Microsoft.AspNetCore.Mvc;

namespace SiteBibliothequeINSAT.Controllers
{
    public class AdminAccount : Controller
    {
        public IActionResult Books()
        {
            return View();
        }
    }
}
