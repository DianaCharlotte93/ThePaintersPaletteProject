using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThePaintersPaletteProject.Clients;
using ThePaintersPaletteProject.Data;
using ThePaintersPaletteProject.Models;

namespace ThePaintersPaletteProject.Controllers
{
    public class PaypalController : Controller
    {
        private readonly PaypalClient _paypalClient;
        private readonly ICartRepository _cartRepo;
        private readonly ShoppingCart _shoppingcart;

        public PaypalController(PaypalClient paypalClient, CartDetail cartDetail, ICartRepository cartRepo, ShoppingCart shoppingcart)
        {
            this._paypalClient = paypalClient;
            this._cartRepo = cartRepo;
            this._shoppingcart = shoppingcart;
        }

        public IActionResult Index()
        {
            // ViewBag.ClientId is used to get the Paypal Checkout javascript SDK
            ViewBag.ClientId = _paypalClient.ClientId;

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            try
            {
                var totalAmount = _cartRepo.GetTotalAmount();
                var price = totalAmount.ToString("F2"); // Format the price
                //var price = "100.00";
                var currency = "USD";
                var reference = "INV001";

                var response = await _paypalClient.CreateOrder(price, currency, reference);

                return Ok(response);

            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _paypalClient.CaptureOrder(orderId);

                var reference = response.purchase_units[0].reference_id;

                return Ok(response);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
