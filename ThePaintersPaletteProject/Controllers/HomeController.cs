using Microsoft.AspNetCore.Mvc;
using ThePaintersPaletteProject.Models;
using ThePaintersPaletteProject.Models.DTO;
using ThePaintersPaletteProject.Repositories;
using System.Diagnostics;

namespace ThePaintersPaletteProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;
        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public IActionResult Index()
        { 
            return View();
        }

        public async Task<IActionResult> ArtCatalogue(string sterm = "", int categoryId = 0)
        {
            IEnumerable<ArtPiece> artPiece = await _homeRepository.GetArtPiece(sterm, categoryId);
            IEnumerable<Category> categories = await _homeRepository.Categories();
            ArtPieceDisplayModel artPieceModel = new ArtPieceDisplayModel
            {
                ArtPiece = artPiece,
                Categories = categories,
                STerm = sterm,
                CategoryId = categoryId
            };
            return View(artPieceModel);
        }
        public IActionResult Homepage()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

