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
    [Authorize]
    [Authorize(Roles = "Admin,Reader")]
    public class QueueController(IQueueRepository queueRepository, IMapper mapper) : ControllerBase
    {
       [HttpGet]
       public async Task <IActionResult> GetAllQueuesAsync()
        {
            var QueuesDomain = await queueRepository.GetAllAsync();

            if (QueuesDomain == null)
            {
                return NotFound();
            }
            var queuesDto = mapper.Map<List<QueueDto>>(QueuesDomain);

            return (Ok(new
            {
                message = "Queues retrieved successfully",
                data = queuesDto
            }));

        }
        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin,Reader")]
        public async Task<IActionResult> GetQueueByIdAsync([FromRoute] Guid id)
        {
            var queueDomain = await queueRepository.GetByIdAsync(id);
            if (queueDomain == null)
            {
                return NotFound();
            }
            var queueDto = mapper.Map<QueueDto>(queueDomain);
            return Ok(new
            {
                message = "Queue retrieved successfully",
                data = queueDto
            });
        }  
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddQueueAsync([FromBody] AddQueueRequestDto addQueueRequestDto)
        {
            var queueDomain = mapper.Map<Queue>(addQueueRequestDto);
            queueDomain = await queueRepository.CreateAsync(queueDomain);
            var queueDto = mapper.Map<QueueDto>(queueDomain);
            return Ok(new
            {
                message = "Queue created successfully",
                data = queueDto
            });
        }
        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> UpdateQueueAsync([FromRoute] Guid id, [FromBody] UpdateQueueRequestDto updateQueueRequestDto)
        {
            var queueDomain = mapper.Map<Queue>(updateQueueRequestDto);
            queueDomain = await queueRepository.UpdateAsync(id, queueDomain);
            if (queueDomain == null)
            {
                return NotFound();
            }
            var queueDto = mapper.Map<QueueDto>(queueDomain);
            return Ok(new
            {
                message = "Queue updated successfully",
                data = queueDto
            });
        }
        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteQueueAsync([FromRoute] Guid id)
        {
            var queueDomain = await queueRepository.DeleteAsync(id);
            if (queueDomain == null)
            {
                return NotFound();
            }
            var queueDto = mapper.Map<QueueDto>(queueDomain);
            return Ok(new
            {
                message = "Queue deleted successfully",
                data = queueDto
            });
        }
    }
}
