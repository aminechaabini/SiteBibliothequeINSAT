using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBibliothequeINSAT.Models
{
    public class Loan
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime dateBorrowed { get; set; }
        public DateTime returnDate { get; set; }
        public Student student { get; set; }
        public Book book { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; internal set; }
        [ForeignKey("Book")]
        public int BooktId { get; internal set; }
    }
}
