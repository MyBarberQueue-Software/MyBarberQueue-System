using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBarberQueue_Web.API.Data;
using MyBarberQueue_Web.API.Models.Dtos;
using MyBarberQueue_Web.API.Repository;

namespace MyBarberQueue_Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController(AppDbContext dbContext, IDeviceRepository deviceRepository, IMapper mapper) : ControllerBase
    {
        private readonly AppDbContext dbContext = dbContext;
        private readonly IDeviceRepository deviceRepository = deviceRepository;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllDevice()
        {
            var devicesDomain = await deviceRepository.GetAllAsync();

            var deviceDto = mapper.Map<List<DeviceDto>>(devicesDomain);

            return Ok(new {
                    message = "Devices retrived successfully",
                    data = deviceDto
            });
        }


        



    }
}
