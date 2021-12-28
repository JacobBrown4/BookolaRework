using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Book
{
    public class BookAndAuthorCreate
    {

        [Required]
        public string Title { get; set; }
        [Required]
        public long Isbn { get; set; }
        [Required]
        public BookGenre Genre { get; set; }
        [Required]
        public string AuthorFirstName { get; set; }
        [Required]
        public string AuthorLastName { get; set; }
    }
}
