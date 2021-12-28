﻿using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models
{
    public class BookEdit
    {
        [Required]
        public int Id { get; set; }
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
