using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using ThePaintersPaletteProject.Data;
using ThePaintersPaletteProject.Models;

namespace ThePaintersPaletteProject.Controllers.Admin
{
    public class VideoCategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoCategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.VideoCategories.ToListAsync());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoCategory = await _context.VideoCategories
                .FirstOrDefaultAsync(m => m.VideoCategoryId == id);
            if (videoCategory == null)
            {
                return NotFound();
            }

            return View(videoCategory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,VideoCategoryName,DropDown")] VideoCategory videoCategory)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(videoCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoCategory);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoCategory = await _context.Categories.FindAsync(id);
            if (videoCategory == null)
            {
                return NotFound();
            }
            return View(videoCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,VideoCategoryName,DropDown")] VideoCategory videoCategory)
        {
            if (id != videoCategory.VideoCategoryId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(videoCategory.VideoCategoryId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(videoCategory);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoCategory = await _context.VideoCategories
                .FirstOrDefaultAsync(m => m.VideoCategoryId == id);
            if (videoCategory == null)
            {
                return NotFound();
            }

            return View(videoCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoCategory = await _context.VideoCategories.FindAsync(id);
            if (videoCategory != null)
            {
                _context.VideoCategories.Remove(videoCategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.VideoCategories.Any(e => e.VideoCategoryId == id);
        }

    }
}
