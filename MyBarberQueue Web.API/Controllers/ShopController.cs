using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Model.Domain;
using MyBarberQueue_Web.API.Models.Dtos;
using MyBarberQueue_Web.API.Repository;

namespace MyBarberQueue_Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly AppDbContext dbContext;
        private readonly IShopRepository shopRepository;

        public ShopController(AppDbContext dbContext, IShopRepository shopRepository)
        {
            this.dbContext = dbContext;
            this.shopRepository = shopRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShop()
        {
            var shopsDomain = await shopRepository.GetAllAsync();

            var shopDto = new List<ShopDto>();

            foreach (var shop in shopsDomain)
            {
                shopDto.Add(new ShopDto
                {
                    Id = shop.Id,
                    Name = shop.Name,
                    PhoneNumber = shop.PhoneNumber,
                    Address = shop.Address,
                    City = shop.City,
                    IsActive = shop.IsActive
                });
            }


            return Ok(new
            {
                message = "Shops retrieved successfully",
                data = shopDto
            });
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetShopById([FromRoute] Guid id)
        {
            var shopDomain = await shopRepository.GetByIdAsync(id);

            if (shopDomain == null)
            {
                return NotFound();
            }
            var shopDto = new ShopDto
            {
                Id = shopDomain.Id,
                Name = shopDomain.Name,
                PhoneNumber = shopDomain.PhoneNumber,
                Address = shopDomain.Address,
                City = shopDomain.City,
                IsActive = shopDomain.IsActive
            };
            return Ok(new
            {
                message = "Shop retrieved successfully",
                data = shopDto
            });

        }

        [HttpPost]
        public async Task<IActionResult> AddShop([FromBody] AddShopRequestDto addShopRequestDto)
        {
            var shopDomain = new Shop
            {
                Id = Guid.NewGuid(),
                Name = addShopRequestDto.Name,
                PhoneNumber = addShopRequestDto.PhoneNumber,
                Address = addShopRequestDto.Address,
                City = addShopRequestDto.City,
                IsActive = addShopRequestDto.IsActive
            };

            shopDomain = await shopRepository.CreateAsync(shopDomain);

            var shopDto = new ShopDto
            {
                Id = shopDomain.Id,
                Name = shopDomain.Name,
                PhoneNumber = shopDomain.PhoneNumber,
                Address = shopDomain.Address,
                City = shopDomain.City,
                IsActive = shopDomain.IsActive
            };
            return CreatedAtAction(nameof(GetShopById), new { id = shopDto.Id }, new
            {
                message = "Shop added successfully",
                data = shopDto
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateShop([FromRoute] Guid id, [FromBody] UpdateShopRequestDto updateShopRequestDto)
        {
            var shopDomain = new Shop
            {
                Name = updateShopRequestDto.Name,
                PhoneNumber = updateShopRequestDto.PhoneNumber,
                Address = updateShopRequestDto.Address,
                City = updateShopRequestDto.City,
                IsActive = updateShopRequestDto.IsActive
            };
            shopDomain = await shopRepository.UpdateAsync(id, shopDomain);

            if (shopDomain == null)
            {
                return NotFound();
            }
            var shopDto = new ShopDto
            {
                Id = shopDomain.Id,
                Name = shopDomain.Name,
                PhoneNumber = shopDomain.PhoneNumber,
                Address = shopDomain.Address,
                City = shopDomain.City,
                IsActive = shopDomain.IsActive
            };
            return Ok(new
            {
                message = "Shop updated successfully",
                data = shopDto
            });

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteShop([FromRoute] Guid id)
        {
            var shopDomain = await shopRepository.DeleteAsync(id);
            if (shopDomain == null)
            {
                return NotFound();
            }
            var shopDto = new ShopDto
            {
                Id = shopDomain.Id,
                Name = shopDomain.Name,
                PhoneNumber = shopDomain.PhoneNumber,
                Address = shopDomain.Address,
                City = shopDomain.City,
                IsActive = shopDomain.IsActive
            };
            return Ok(new
            {
                message = "Shop deleted successfully",
                data = shopDto
            });
        }
    }
}