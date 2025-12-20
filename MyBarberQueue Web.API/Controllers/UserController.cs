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
    public class UserController(IUserRepository IUserRepository, IMapper mapper) : ControllerBase
    {
        private readonly IUserRepository iUserRepository = IUserRepository;
        private readonly IMapper mapper = mapper;

        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            var usersDomain = await iUserRepository.GetAllAsync();
            if (usersDomain == null)
            {
                return NotFound();
            }
            var usersDto = mapper.Map<List<UserDto>>(usersDomain);
            return Ok(new
            {
                message = "Users retrieved successfully",
                data = usersDto
            });
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUserByIdAsync([FromRoute] Guid id)
        {
            var userDomain = await iUserRepository.GetByIdAsync(id);
            if (userDomain == null)
            {
                return NotFound();
            }
            var userDto = mapper.Map<UserDto>(userDomain);
            return Ok(new
            {
                message = "User retrieved successfully",
                data = userDto
            }); 
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserRequestDto addUserRequestDto)
        {
            var userDomain = mapper.Map<User>(addUserRequestDto);
            userDomain = await iUserRepository.CreateAsync(userDomain);
            var userDto = mapper.Map<UserDto>(userDomain);
            return Ok(new
            {
                message = "User created successfully",
                data = userDto
            });
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] UpdateUserRequestDto updateUserRequestDto)
        {
            var userDomain = mapper.Map<User>(updateUserRequestDto);
            userDomain = await iUserRepository.UpdateAsync(id, userDomain);
            if (userDomain == null)
            {
                return NotFound();
            }
            var userDto = mapper.Map<UserDto>(userDomain);
            return Ok(new
            {
                message = "User updated successfully",
                data = userDto
            });
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id)
        {
            var userDomain = await iUserRepository.DeleteAsync(id);
            if (userDomain == null)
            {
                return NotFound();
            }
            var userDto = mapper.Map<UserDto>(userDomain);
            return Ok(new
            {
                message = "User deleted successfully",
                data = userDto
            });
        }

    }
}
