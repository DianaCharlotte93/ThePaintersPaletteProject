using ThePaintersPaletteProject.Models;

namespace ThePaintersPaletteProject.Repositories
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Category>> Categories();
        Task<IEnumerable<ArtPiece>> GetArtPiece(string sTerm = "", int categoryid = 0);

        Task<IEnumerable<VideoCategory>> VideoCategories();
        Task<IEnumerable<Video>> GetVideos(string sTerm = "", int videoCategoryId = 0);
    }
}
