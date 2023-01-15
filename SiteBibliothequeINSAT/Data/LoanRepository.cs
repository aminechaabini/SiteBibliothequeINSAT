using Microsoft.EntityFrameworkCore;
using Repository.Data;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public class LoanRepository : Repository<Loan>, ILoanRepository
    {
        private readonly LibraryContext _libraryContext;

        public LoanRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }
        public IEnumerable<Loan> GetLoansOfStudent(int id)
        {
            return _libraryContext.Loans.Include(r => r.book).ThenInclude(b => b.author).Where(r => r.student.Id == id).ToList();
        }
        public int GetNumberOfLoansOfABook(int id)
        {
            return _libraryContext.Loans.Include(l => l.book).Where(l => l.book.Id == id).DefaultIfEmpty().Count();
        }
        public int GetNumberOfLoansOfAStudent(int id)
        {
            return _libraryContext.Loans.Include(l => l.student).Where(l => l.student.Id == id).DefaultIfEmpty().Count();
        }
    }
}
