using Repository.Data;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly LibraryContext _libraryContext;

        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }
    }
}
