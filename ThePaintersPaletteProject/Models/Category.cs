﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ThePaintersPaletteProject.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string? CategoryName { get; set; }
        public int DropDown { get; set; }
        public List<ArtPiece> ArtPiece { get; set; }
    }
}