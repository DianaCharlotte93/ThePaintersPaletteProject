using Microsoft.AspNetCore.Mvc;
using ThePaintersPaletteProject.Models;
using ThePaintersPaletteProject.Models.DTO;
using ThePaintersPaletteProject.Repositories;
using System.Diagnostics;



namespace ThePaintersPaletteProject.Controllers
{
    public class VideosPageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public VideosPageController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sterm = "", int videoCategoryId = 0)
        {
            IEnumerable<Video> videos = await _homeRepository.GetVideos(sterm, videoCategoryId);
            IEnumerable<VideoCategory> videoCategories = await _homeRepository.VideoCategories();
            VideoDisplayModel VideoModel = new VideoDisplayModel
            {
                Videos = videos,
                VideoCategories = videoCategories,
                STerm = sterm,
                VideoCategoryId = videoCategoryId
            };
            return View(VideoModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}