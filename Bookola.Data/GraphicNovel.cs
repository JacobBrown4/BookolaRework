using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bookola.Data
{
    public enum GraphicNovelGenre { Manga, SuperHeroStories, NonSuperHeroStories, PersonalNarratives, NonFiction}
    public class GraphicNovel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string Title { get; set; }
        public int Volume { get; set; }
        [Required]
        public long Isbn { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{YYYY-MM-DD}")]
        public DateTimeOffset IssuedDate { get; set; }
        [System.Text.Json.Serialization.JsonConverter(typeof(JsonStringEnumConverter))]
        public GraphicNovelGenre Genre { get; set; }
        [ForeignKey(nameof(Writer))]
        public int WriterId { get; set; }
        public virtual Author Writer { get; set; }
        [ForeignKey(nameof(Artist))]
        public int ArtistId { get; set; }
        public virtual Author Artist { get; set; }
    }
}
