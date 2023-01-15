using SiteBibliothequeINSAT.Models;

namespace SiteBibliothequeINSAT.Data
{
    public interface IStudentRepository : IRepository<Student>
    {
        public Student getStudentWithCredentials (string email, string password);
    }
}
