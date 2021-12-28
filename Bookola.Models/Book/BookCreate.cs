﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookola.Data;

namespace Bookola.Models
{
    public class BookCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public long Isbn { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public BookGenre Genre { get; set; }
    }
}
