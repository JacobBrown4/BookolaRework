using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Authorship
{
    public class AuthorshipEdit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int MagazineId { get; set; }
    }
}
