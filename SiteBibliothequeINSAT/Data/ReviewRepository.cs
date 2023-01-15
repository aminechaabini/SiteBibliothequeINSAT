using Microsoft.EntityFrameworkCore;
using Repository.Data;
using SiteBibliothequeINSAT.Models;
using System.Linq.Expressions;

namespace SiteBibliothequeINSAT.Data
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly LibraryContext _libraryContext;

        public ReviewRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }
        public IEnumerable<Review> FindIncludingStudentAndBook(Expression<Func<Review, bool>> predicate)
        {
            return _libraryContext.Reviews.Include(r => r.student).Include(r => r.book).Where(predicate).ToList();
        }
    }
}
