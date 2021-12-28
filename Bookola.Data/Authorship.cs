using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Data
{
    public class Authorship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [Required]
        public int MagazineId { get; set; }
        public virtual Magazine Magazine { get; set; }

    }
}
