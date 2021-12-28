
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Bookola.Models
{
    public class AuthorCreate
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
