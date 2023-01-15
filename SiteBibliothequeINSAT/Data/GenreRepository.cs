using Repository.Data;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly LibraryContext _libraryContext;

        public GenreRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }
    }
}
