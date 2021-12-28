using Bookola.Data;

namespace Bookola.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorListItem Author { get; set; }
        public long Isbn { get; set; }
        public string Genre { get; set; }
    }
}
