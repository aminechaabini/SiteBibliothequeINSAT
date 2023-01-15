using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteBibliothequeINSAT.Models
{
    public class Review
    {
        [Required]
        public int Id { get; set; }
        public string text { get; set; }
        public DateTime CreatedDate { get; set; }
        public Book book { get; set; }
        public Student student { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; internal set; }
        [ForeignKey("Book")]
        public int BooktId { get; internal set; }
    }
}
