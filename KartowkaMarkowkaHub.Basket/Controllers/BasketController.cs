﻿using KartowkaMarkowkaHub.Basket.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KartowkaMarkowkaHub.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        //private readonly Guid _userId = Guid.Parse("6ebc929b-3785-49d9-9d46-b3b9f70b0bb5");

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        /// <summary>
        /// Получает все продукты из корзины для клиента
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {            
            string userIdText = User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
            Guid userId = Guid.Parse(userIdText);
            var result = await _basketService.Get(userId);
            return Ok(result);
        }

        /// <summary>
        /// Добавляет продукт в корзину
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Guid userId, Guid productId)
        {
            await _basketService.Create(productId, userId);
            return Created();
        }

        /// <summary>
        /// Удаляет продукт из корзины
        /// </summary>
        /// <param name="productId">id продукта</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid userId, Guid productId)
        {
            await _basketService.Remove(productId, userId);
            return Ok();
        }
    }
}