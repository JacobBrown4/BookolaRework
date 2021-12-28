using System.ComponentModel.DataAnnotations;


namespace Bookola.Models
{
    public class AuthorEdit
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last")]
        public string LastName { get; set; }
    }
}
