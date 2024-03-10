using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThePaintersPaletteProject.Models
{
    [Table("CartDetail")]
    public class CartDetail
    {
        [Key]
        public int CartDetailId { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int ArtId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public ArtPiece ArtPiece { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}