namespace ThePaintersPaletteProject.Models.DTO
{
    public class ArtPieceDisplayModel
    {
        public IEnumerable<ArtPiece> ArtPiece { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public string STerm { get; set; } = "";
        public int CategoryId { get; set; } = 0;
    }
}