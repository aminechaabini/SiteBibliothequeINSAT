using Microsoft.AspNetCore.Mvc;
using SiteBibliothequeINSAT.Data;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Controllers
{
    public class Book : Controller
    {
        public IActionResult Index(int bookId , int studentId)
        {
            LibraryContext context = LibraryContext.Instantiate_LibraryContext();
            BookRepository repository = new BookRepository(context);
            Models.Book book = repository.Get(bookId);
            ViewData["studentId"] = studentId;
            return View(book);
        }
        public IActionResult BookaBook(int bookId, int studentId)
        {
            LibraryContext context = LibraryContext.Instantiate_LibraryContext();
            UnitOfWork u = new UnitOfWork(context);
            if ((u.Loan.GetNumberOfLoansOfAStudent(studentId) + u.Reservation.GetNumberOfReservationsOfStudent(studentId))>=3)
            {
                ViewBag.Message = "Vous avez excédé votre limite de reservations et d'emprunts!";
            }
            else if((u.Book.GetById(bookId).availableCopies 
                - u.Reservation.GetNumberOfReservationsOfABook(bookId) 
                - u.Loan.GetNumberOfLoansOfABook(bookId)) <= 0)
            {
                ViewBag.Message = "Livre indisponible pour le moment!";
            }
            else if(u.Loan.Find(l=> l.StudentId==studentId)!=null || u.Reservation.Find(r => r.StudentId == studentId) != null)
            {
                ViewBag.Message = "Vous avez deja réservé ou emprunté ce livre!";
            }
            else
            {
                Reservation r = new Reservation();
                r.StudentId=studentId;
                r.BooktId=bookId;
                r.book = u.Book.Get(bookId);
                r.student = u.Student.Get(studentId);
                u.Reservation.Add(r);
                u.complete();
                ViewBag.Message = "Resrvation éffectué avec succès!";
            }
            return Redirect("Book/Index/1");
        }
        public ActionResult Reviews(int id)
        {
            LibraryContext context = LibraryContext.Instantiate_LibraryContext();
            ReviewRepository repository = new ReviewRepository(context);
            List<Review> reviews = (List<Review>) repository.FindIncludingStudentAndBook(r => r.BooktId==id);
            return View(reviews);
        }
    }
}
