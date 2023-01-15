using Microsoft.EntityFrameworkCore;
using Repository.Data;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryContext _libraryContext;

        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }
        public IEnumerable<Book> GetAll()
        {
            return _libraryContext.Books.Include(b => b.genre).Include(b => b.author).ToList();
        }
        public Book Get(int id)
        {
            return (Book)_libraryContext.Books.Include(b => b.author).Include(b => b.genre).Where(b=> b.Id==id).First();
        }
        public Book GetById(int id)
        {
            return _libraryContext.Books.Where(b => b.Id == id).FirstOrDefault();
        }
    }
}
