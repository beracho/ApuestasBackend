using System.Threading.Tasks;
using BaseBackend.API.Data;
using BaseBackend.API.Dtos;
using BaseBackend.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaseBackend.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _repo;

        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserForRegisterDto userForRegisterDto)
        {
            // validate request
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExists(userForRegisterDto.Username))
                return BadRequest("Username is already taken");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };
            var createUser = await _repo.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpPost("completeregister")]
        public async Task<IActionResult> CompleteRegister([FromBody]UserForUpdateDto userForUpdateDto)
        {
            // validate request
            userForUpdateDto.Username = userForUpdateDto.Username.ToLower();

            if (!await _repo.UserExists(userForUpdateDto.Username))
                return BadRequest("Username nonexistent");

            var userToCreate = new User
            {
                Username = userForUpdateDto.Username,
                Company = userForUpdateDto.Company,
                Telephone = userForUpdateDto.Telephone,
                LastName = userForUpdateDto.LastName,
                FirstName = userForUpdateDto.FirstName,
                Address = userForUpdateDto.Address,
                AboutMe = userForUpdateDto.AboutMe
            };
            var createUser = await _repo.CompleteRegister(userToCreate, userForUpdateDto.Password);

            return StatusCode(201);
        }
    }
}