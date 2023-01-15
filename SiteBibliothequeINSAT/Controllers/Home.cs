using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteBibliothequeINSAT.Data;
using SiteBibliothequeINSAT.Models;
using System.Security.Claims;

namespace SiteBibliothequeINSAT.Controllers
{
    [Authorize]
    public class Home : Controller
    {
        public IActionResult Books()
        {
            LibraryContext context = LibraryContext.Instantiate_LibraryContext();
            BookRepository repository = new BookRepository(context);
            List<Models.Book> books = (List<Models.Book>) repository.GetAll();
            ViewData["studentId"] = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            return View(books);
        }
        public IActionResult Reservations()
        {

            LibraryContext context = LibraryContext.Instantiate_LibraryContext();
            ReservationRepository repository = new ReservationRepository(context);
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            List<Reservation> reservations = (List<Reservation>) repository.GetReservationsOfStudent(Convert.ToInt32(userId));
            return View(reservations);
        }
        public IActionResult Loans()
        {
            LibraryContext context = LibraryContext.Instantiate_LibraryContext();
            LoanRepository repository = new LoanRepository(context);
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            List<Loan> loans = (List<Loan>)repository.GetLoansOfStudent(Convert.ToInt32(userId));
            return View(loans);
        }
    }
}
