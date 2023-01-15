using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        public IEnumerable<Reservation> GetReservationsOfStudent(int id);
        public int GetNumberOfReservationsOfABook(int id);
        public int GetNumberOfReservationsOfStudent(int id);
    }
}
