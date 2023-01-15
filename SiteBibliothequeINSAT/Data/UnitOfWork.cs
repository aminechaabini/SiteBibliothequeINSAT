namespace SiteBibliothequeINSAT.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _libraryContext;
        public IStudentRepository Student { get; private set; }
        public IBookRepository Book { get; private set; }
        public IGenreRepository Genre { get; private set; }
        public IReviewRepository Review { get; private set; }
        public ILoanRepository Loan { get; private set; }
        public IReservationRepository Reservation { get; private set; }
        public IAuthorRepository Author { get; private set; }

        public UnitOfWork(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
            Student = new StudentRepository(libraryContext);
            Book = new BookRepository(libraryContext);
            Genre = new GenreRepository(libraryContext);
            Review = new ReviewRepository(libraryContext);
            Loan = new LoanRepository(libraryContext);
            Reservation =new ReservationRepository(libraryContext);
            Author = new AuthorRepository(libraryContext);
    }

        public bool complete()
        {
            try
            {
                int result= _libraryContext.SaveChanges();
                if (result > 0) return true;  
                return false;
            }
            catch(Exception e)
            { throw e; }
        }
        public void dispose()
        {
            _libraryContext.Dispose();
        }
    }
}
