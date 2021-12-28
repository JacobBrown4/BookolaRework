using Bookola.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookola.Models.GraphicNovel
{
    public class GraphicNovelCreate
    {
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
