using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThePaintersPaletteProject.Models
{
    [Table("Video")]
    public class Video
    {
        [Key]
        public int VideoId { get; set; }
        [Required]
        public string? VideoName { get; set; }
        [Required]
        public string? Image { get; set; }
        public string? VideoDescription { get; set; }
        public int VideoCategoryId { get; set; }
        public VideoCategory VideoCategory { get; set; }

        [NotMapped]
        public string VideoCategoryName { get; set; }
    }
}