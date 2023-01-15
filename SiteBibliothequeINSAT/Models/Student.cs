using System.ComponentModel.DataAnnotations;

namespace SiteBibliothequeINSAT.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int cardID { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password  { get; set; }
        public ICollection<Review> reviews { get; set; }
        public ICollection<Reservation> reservations { get; set; }
        public ICollection<Loan> loans { get; set; }


    }
}
