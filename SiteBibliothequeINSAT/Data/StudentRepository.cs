using Repository.Data;
using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly LibraryContext _libraryContext;

        public StudentRepository(LibraryContext libraryContext) : base(libraryContext)
        {
            this._libraryContext = libraryContext;
        }
        public Student getStudentWithCredentials(string email, string password)
        {
            var s =  _libraryContext.Students.Where(s => s.email == email & s.password == password).SingleOrDefault();
            return (Student)s;
        }
    }
}
