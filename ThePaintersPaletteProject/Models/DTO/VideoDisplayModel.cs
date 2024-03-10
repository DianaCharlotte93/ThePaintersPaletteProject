namespace ThePaintersPaletteProject.Models.DTO
{
    public class VideoDisplayModel
    {
        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<VideoCategory> VideoCategories { get; set; }
        public string STerm { get; set; } = "";
        public int VideoCategoryId { get; set; } = 0;
    }
}

