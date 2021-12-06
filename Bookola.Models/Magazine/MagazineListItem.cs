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
    public class MagazineListItem
    {
        [Key]
        public int Id { get; set; }

        public int Countrycode { get; set; }
        public int ReadingLevel { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public DateTime IssueDate { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}