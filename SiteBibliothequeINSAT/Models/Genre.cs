using System.ComponentModel.DataAnnotations;

namespace SiteBibliothequeINSAT.Models
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Book> books { get; set; } 
    }
}
