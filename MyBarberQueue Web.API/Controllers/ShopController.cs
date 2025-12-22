using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    
    public class ShopController(AppDbContext dbContext, IShopRepository shopRepository, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext dbContext = dbContext;
        private readonly IShopRepository shopRepository = shopRepository;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        [Authorize(Roles = "Admin,Roles")]
        public async Task<IActionResult> GetAllShop()
        {
           var shopsDomain = await shopRepository.GetAllAsync();

           var shopDto = mapper.Map<List<ShopDto>>(shopsDomain);

            return Ok(new
            {
                message = "Shops retrieved successfully",
                data = shopDto
            });
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin,Reader")]
        public async Task<IActionResult> GetShopById([FromRoute] Guid id)
        {
            var shopDomain = await shopRepository.GetByIdAsync(id);

            if (shopDomain == null)
            {
                return NotFound();
            }
            var shopDto = mapper.Map<ShopDto>(shopDomain);

            return Ok(new
            {
                message = "Shop retrieved successfully",
                data = shopDto
            });

        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddShop([FromBody] AddShopRequestDto addShopRequestDto)
        {
            var shopDomain = mapper.Map<Shop>(addShopRequestDto);

            shopDomain = await shopRepository.CreateAsync(shopDomain);

            var shopDto = mapper.Map<ShopDto>(shopDomain);

            return CreatedAtAction(nameof(GetShopById), new { id = shopDto.Id }, new
            {
                message = "Shop added successfully",
                data = shopDto
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateShop([FromRoute] Guid id, [FromBody] UpdateShopRequestDto updateShopRequestDto)
        {
            var shopDomain = mapper.Map<Shop>(updateShopRequestDto);

            shopDomain = await shopRepository.UpdateAsync(id, shopDomain);

            if (shopDomain == null)
            {
                return NotFound();
            }
            var shopDto = mapper.Map<ShopDto>(shopDomain);
            return Ok(new
            {
                message = "Shop updated successfully",
                data = shopDto
            });

        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteShop([FromRoute] Guid id)
        {
            var shopDomain = await shopRepository.DeleteAsync(id);
            if (shopDomain == null)
            {
                return NotFound();
            }
            var shopDto = mapper.Map<ShopDto>(shopDomain);
            return Ok(new
            {
                message = "Shop deleted successfully",
                data = shopDto
            });
        }
    }
}
