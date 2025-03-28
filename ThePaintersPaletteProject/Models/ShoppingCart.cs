﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThePaintersPaletteProject.Models
{
    [Table("ShoppingCart")]
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        [Required]
        public string UserId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public ICollection<CartDetail> CartDetails { get; set; }

    }
}
