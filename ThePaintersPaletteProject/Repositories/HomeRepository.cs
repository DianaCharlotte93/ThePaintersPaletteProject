using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ThePaintersPaletteProject.Data;
using ThePaintersPaletteProject.Models;

namespace ThePaintersPaletteProject.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Category>> Categories()
        {
            return await _db.Categories.ToListAsync();
        }
        public async Task<IEnumerable<ArtPiece>> GetArtPiece(string sTerm = "", int categoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<ArtPiece> artPieces = await (from artPiece in _db.ArtPieces
                                                     where artPiece.CategoryId == categoryId
                                                     select artPiece

                                                    ).ToListAsync();

            return artPieces;
        }

        public async Task<IEnumerable<VideoCategory>> VideoCategories()
        {
            return await _db.VideoCategories.ToListAsync();
        }
        public async Task<IEnumerable<Video>> GetVideos(string sTerm = "", int videoCategoryId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Video> videos = await (from video in _db.Videos
                                                where video.VideoCategoryId == videoCategoryId
                                                select video
                                                ).ToListAsync();

            return videos;

        }
    }
}
