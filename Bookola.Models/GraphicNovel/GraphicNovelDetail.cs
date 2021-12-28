using Bookola.Data;
using System;
using System.Collections.Generic;
namespace Bookola.Models.GraphicNovel
{
    public class GraphicNovelDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Volume { get; set; }
        public long Isbn { get; set; }
        public DateTimeOffset IssuedDate { get; set; }
        public string Genre { get; set; }
        public AuthorListItem Writer { get; set; }
        public AuthorListItem Artist { get; set; }
    }
}
