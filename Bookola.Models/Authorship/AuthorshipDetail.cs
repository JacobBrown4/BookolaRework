using Bookola.Models.Magazine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Authorship
{
    public class AuthorshipDetail
    {

        public int Id { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
        public MagazineDetail Magazine { get; set; }
    }
}
