namespace SiteBibliothequeINSAT.Data
{
    public interface IUnitOfWork
    {
        public IStudentRepository Student { get; }
        public IBookRepository Book { get; }
        public IGenreRepository Genre { get; }
        public IReviewRepository Review { get; }
        public ILoanRepository Loan { get; }
        public IReservationRepository Reservation { get; }
        public IAuthorRepository Author { get; }

        public bool complete();
    }
}
