using SiteBibliothequeINSAT.Models;
using System.Linq.Expressions;

namespace SiteBibliothequeINSAT.Data
{
    public interface IReviewRepository : IRepository<Review>
    {
        public IEnumerable<Review> FindIncludingStudentAndBook(Expression<Func<Review, bool>> predicate);
    }
}
