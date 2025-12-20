using AutoMapper;
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

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetDeviceById([FromRoute] Guid id)
        {
            var deviceDomain = await deviceRepository.GetByIdAsync(id);
            if (deviceDomain == null)
            {
                return NotFound(new
                {
                    message = "Device not found"
                });
            }
            var deviceDto = mapper.Map<DeviceDto>(deviceDomain);
            return Ok(new
            {
                message = "Device retrived successfully",
                data = deviceDto
            });
        }   

        [HttpPost]
        public async Task<IActionResult> AddDevice([FromBody] AddDeviceRequestDto addDeviceRequestDto)
        {
            var deviceDomain = mapper.Map<Device>(addDeviceRequestDto);
            deviceDomain = await deviceRepository.CreateAsync(deviceDomain);
            var deviceDto = mapper.Map<DeviceDto>(deviceDomain);
            return Ok(new
            {
                message = "Device added successfully",
                data = deviceDto
            });
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDevice([FromRoute] Guid id, [FromBody] UpdateDeviceRequestDto updateDeviceRequestDto)
        {
            var deviceDomain = mapper.Map<Device>(updateDeviceRequestDto);
            deviceDomain = await deviceRepository.UpdateAsync(id, deviceDomain);
            if (deviceDomain == null)
            {
                return NotFound(new
                {
                    message = "Device not found"
                });
            }
            var deviceDto = mapper.Map<DeviceDto>(deviceDomain);
            return Ok(new
            {
                message = "Device updated successfully",
                data = deviceDto
            });
        }

        public async Task<IActionResult> DeleteDevice([FromRoute] Guid id)
        {
            var deviceDomain = await deviceRepository.DeleteAsync(id);
            if (deviceDomain == null)
            {
                return NotFound(new
                {
                    message = "Device not found"
                });
            }
            var deviceDto = mapper.Map<DeviceDto>(deviceDomain);
            return Ok(new
            {
                message = "Device deleted successfully",
                data = deviceDto
            });
        }
    }
}
