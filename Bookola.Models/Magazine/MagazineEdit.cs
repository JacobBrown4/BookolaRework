﻿using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.Magazine
{
    public class MagazineEdit
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Volume { get; set; }
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}")]
        public DateTime IssueDate { get; set; }
        public int GenreId { get; set; }
    }
}