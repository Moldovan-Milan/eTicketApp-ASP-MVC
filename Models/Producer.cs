using eTicketApp.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTicketApp.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        [Required(ErrorMessage = "Profile Picture is required!")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Biography is required!")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie>? Movies { get; set; }
    }
}
