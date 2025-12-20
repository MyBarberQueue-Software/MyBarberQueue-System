using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyBarberQueue_Web.API.Model.Domain;
using MyBarberQueue_Web.API.Models.Dtos;
using MyBarberQueue_Web.API.Repository;

namespace MyBarberQueue_Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController(ITicketRepository ticketRepository, IMapper mapper) : ControllerBase
    {
        private readonly ITicketRepository ticketRepository = ticketRepository;
        private readonly IMapper mapper = mapper;


        [HttpGet]
        public async Task<IActionResult> GetAllTicketsAsync()
        {
            var ticketsDomain = await ticketRepository.GetAllAsync();
            if (ticketsDomain == null)
            {
                return NotFound();
            }
            var ticketsDto = mapper.Map<List<TicketDto>>(ticketsDomain);
            return Ok(new
            {
                message = "Tickets retrieved successfully",
                data = ticketsDto
            });

        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetTicketByIdAsync([FromRoute] Guid id)
        {
            var ticketDomain = await ticketRepository.GetByIdAsync(id);
            if (ticketDomain == null)
            {
                return NotFound();
            }
            var ticketDto = mapper.Map<TicketDto>(ticketDomain);
            return Ok(new
            {
                message = "Ticket retrieved successfully",
                data = ticketDto
            });

        }
        
        [HttpPost]
        public async Task<IActionResult> AddTicketAsync([FromBody] AddTicketRequestDto addTicketRequestDto)
        {
            var ticketDomain = mapper.Map<Ticket>(addTicketRequestDto);
            ticketDomain = await ticketRepository.CreateAsync(ticketDomain);
            var ticketDto = mapper.Map<TicketDto>(ticketDomain);
            return Ok(new
            {
                message = "Ticket created successfully",
                data = ticketDto
            });
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateTicketAsync([FromRoute] Guid id, [FromBody] UpdateTicketRequestDto updateTicketRequestDto)
        {
            var ticketDomain = mapper.Map<Ticket>(updateTicketRequestDto);
            ticketDomain = await ticketRepository.UpdateAsync(id, ticketDomain);
            if (ticketDomain == null)
            {
                return NotFound();
            }
            var ticketDto = mapper.Map<TicketDto>(ticketDomain);
            return Ok(new
            {
                message = "Ticket updated successfully",
                data = ticketDto
            });
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteTicketAsync([FromRoute] Guid id)
        {
            var ticketDomain = await ticketRepository.DeleteAsync(id);
            if (ticketDomain == null)
            {
                return NotFound();
            }
            var ticketDto = mapper.Map<TicketDto>(ticketDomain);
            return Ok(new
            {
                message = "Ticket deleted successfully",
                data = ticketDto
            });
        }

    }
}
