using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public interface IBookRepository : IRepository<Book>
    {
        public Book GetById(int id);
    }
}
