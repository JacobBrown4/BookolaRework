using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Authorship
{
    public class AuthorshipListItem
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public int MagazineId { get; set; }
        public string MagazineTitle { get; set; }
    }
}
