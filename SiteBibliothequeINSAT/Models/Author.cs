using System.ComponentModel.DataAnnotations;

namespace SiteBibliothequeINSAT.Models
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public ICollection<Book> books { get; set; }

    }
}
