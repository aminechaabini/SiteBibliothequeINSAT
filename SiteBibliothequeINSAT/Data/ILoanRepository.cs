using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public interface ILoanRepository : IRepository<Loan>
    {
        public IEnumerable<Loan> GetLoansOfStudent(int id);
        public int GetNumberOfLoansOfABook(int id);
        public int GetNumberOfLoansOfAStudent(int id);
    }
}
