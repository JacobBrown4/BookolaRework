
using System.ComponentModel.DataAnnotations;


namespace Bookola.Models
{
    public class AuthorListItem
    {
        public int AuthorId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
