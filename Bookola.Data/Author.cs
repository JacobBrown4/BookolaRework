using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Data
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName()
        {
            return LastName + ", " + FirstName;
        }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual List<Authorship> Authorships { get; set; }
        public virtual List<Book> Books { get; set; }
        public virtual List<GraphicNovel> WrittenGraphicNovels { get; set; }
        public virtual List<GraphicNovel> DrawnGraphicNovels { get; set; }
    }
}
