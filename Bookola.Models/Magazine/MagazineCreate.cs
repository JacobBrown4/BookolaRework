using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Magazine
{
    public class MagazineCreate
    {
        public string Title { get; set; }
        public int Volume { get; set; }
       
        public DateTimeOffset IssueDate { get; set; }
        public MagazineGenre Genre { get; set; }
    }
}
