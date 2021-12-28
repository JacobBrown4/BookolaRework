using Bookola.Data;
using Bookola.Models.GraphicNovel;
using Bookola.Models.Magazine;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Models
{
    public class AuthorDetail
    {
        public int AuthorId { get; set; }
        [Display(Name = "Author")]
        public string FullName
        {
            get => LastName + ", " + FirstName;
            set { }
        }
        [Display(Name = "First")]
        public string FirstName { get; set; }
        [Display(Name = "Last")]
        public string LastName { get; set; }
        public List<BookListItem> Books { get; set; }
        public List<MagazineListItem> Magazines { get; set; }
        public List<GraphicNovelListItem> GraphicNovelsWritten { get; set; }
        public List<GraphicNovelListItem> GraphicNovelsDrawn { get; set; }
    }
}
