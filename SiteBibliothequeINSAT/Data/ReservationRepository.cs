using Microsoft.EntityFrameworkCore;
using Repository.Data;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly LibraryContext _libraryContext;

        public ReservationRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }
        public IEnumerable<Reservation> GetAll()
        {
            return _libraryContext.Reservations.Include(r => r.book).Include(r => r.student).ToList();
        }
        public IEnumerable<Reservation> GetReservationsOfStudent(int id)
        {
           return  _libraryContext.Reservations.Include(r => r.book).ThenInclude(b => b.author).Where(r => r.student.Id == id).ToList();
        }
        public int GetNumberOfReservationsOfABook(int id)
        {
            return _libraryContext.Reservations.Include(r => r.book).Where(r => r.book.Id == id).DefaultIfEmpty().Count();
        }
        public int GetNumberOfReservationsOfStudent(int id)
        {
            return _libraryContext.Reservations.Include(r => r.student).Where(r => r.student.Id == id).DefaultIfEmpty().Count();
        }
    }
}
