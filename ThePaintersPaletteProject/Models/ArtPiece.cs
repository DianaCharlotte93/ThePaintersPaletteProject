using Humanizer.Localisation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThePaintersPaletteProject.Models
{
    [Table("ArtPiece")]
    public class ArtPiece
    {
        [Key]
        public int ArtId { get; set; }
        [Required]
        [MaxLength(140)]
        public string? ArtTitle { get; set; }
        [Required]
        [MaxLength(250)]
        public string? ArtDescription { get; set; }
        [Required]
        public double Price { get; set; }
        public string? Image { get; set; }
        public int Rating { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
        public List<CartDetail> CartDetail { get; set; }

        [NotMapped]
        public string CategoryName { get; set; }

    }
}