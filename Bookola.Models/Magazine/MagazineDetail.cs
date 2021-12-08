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
    public class MagazineDetail
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Volume { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }
        [ForeignKey("GenreName"), Display(Name = "Genre")]
        public string GenreName { get; set; }

    }
}
