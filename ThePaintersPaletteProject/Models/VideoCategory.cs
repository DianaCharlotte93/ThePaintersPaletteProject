using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThePaintersPaletteProject.Models
{
    [Table("VideoCategory")]
    public class VideoCategory
    {
        [Key]
        public int VideoCategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? VideoCategoryName { get; set; }
        public int DropDown { get; set; }
        public List<Video> Videos { get; set; }
    }
}