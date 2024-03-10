using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThePaintersPaletteProject.Data;
using ThePaintersPaletteProject.Models;

namespace ThePaintersPaletteProject.Controllers
{
    [Authorize]
    public class CartDetailsController : Controller
    {
        private readonly ICartRepository _cartRepo;

        public CartDetailsController(ICartRepository cartRepo)
        {
            _cartRepo = cartRepo;
        }
        public async Task<IActionResult> AddItem(int ArtId, int qty = 1, int redirect = 0)
        {
            var cartCount = await _cartRepo.AddItem(ArtId, qty);
            if (redirect == 0)
                return Ok(cartCount);
            return RedirectToAction("GetUserCart");
        }

        public async Task<IActionResult> RemoveItem(int artId)
        {
            var cartCount = await _cartRepo.RemoveItem(artId);
            return RedirectToAction("GetUserCart");
        }
        public async Task<IActionResult> GetUserCart()
        {
            var cart = await _cartRepo.GetUserCart();
            return View(cart);
        }

        public async Task<IActionResult> GetTotalItemInCart()
        {
            int cartItem = await _cartRepo.GetCartItemCount();
            return Ok(cartItem);
        }

        public async Task<IActionResult> Checkout()
        {
            bool isCheckedOut = await _cartRepo.DoCheckout();
            if (!isCheckedOut)
                throw new Exception("Something happened on server side");
            return RedirectToAction("Index", "Home");
        }

    }
}