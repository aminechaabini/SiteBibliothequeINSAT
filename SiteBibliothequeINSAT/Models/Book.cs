using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBibliothequeINSAT.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int ISBN { get; set; }
        public string publicationDate { get; set; }
        public string addedDate { get; set; }
        [Required]
        public int availableCopies { get; set; }  
        public Author author { get; set; }
        public Genre genre { get; set; }
        public ICollection<Review> reviews { get; set; }
        public ICollection<Reservation> reservations { get; set; }  
        public ICollection<Loan> loans { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; internal set; }
        [ForeignKey("Genre")]
        public int GenreId { get; internal set; }
    }
}
