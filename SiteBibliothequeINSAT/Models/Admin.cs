using System.ComponentModel.DataAnnotations;

namespace SiteBibliothequeINSAT.Models
{
    public class Admin
    {
        [Required]

        public int Id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
