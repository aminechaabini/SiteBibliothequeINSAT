using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBibliothequeINSAT.Models
{
    public class Reservation
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DateTime cancellingDate { get; set; }

        public Student student { get; set; }
        public Book book { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; internal set; }
        [ForeignKey("Book")]
        public int BooktId { get; internal set; }
    }
}
