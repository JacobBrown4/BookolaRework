using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookola.Models.GraphicNovel
{
    public class GraphicNovelEdit
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public long Isbn { get; set; }
        [Required]
        public int Volume { get; set; }
        [Required]
        public DateTimeOffset IssuedDate { get; set; }
        [Required]
        public GraphicNovelGenre Genre { get; set; }
        [Required]
        public int WriterId { get; set; }
        [Required]
        public int ArtistId { get; set; }
    }
}
