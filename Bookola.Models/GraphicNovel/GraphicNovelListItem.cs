using Bookola.Data;
using System;
using System.Collections.Generic;

namespace Bookola.Models.GraphicNovel
{
    public class GraphicNovelListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Volume { get; set; }
        public DateTimeOffset IssuedDate { get; set; }
        public string Genre { get; set; }
    }
}
