using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseBackend.API.Data;
using BaseBackend.API.Dtos;
using BaseBackend.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaseBackend.API.Controllers
{
    [Route("api/[controller]")]
    public class BetsController : Controller
    {
        private readonly IBetRepository _repo;

        public BetsController(IBetRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("newbet")]
        public async Task<IActionResult> NewBet([FromBody]BetRegisterDto betRegisterDto)
        {
            Console.WriteLine(betRegisterDto.Username);
            betRegisterDto.Username = betRegisterDto.Username.ToLower();

            var betToCreate = new Bet
            {
                TeamId = betRegisterDto.TeamId
            };
            var createUser = await _repo.NewBet(betToCreate, betRegisterDto.Username);

            return StatusCode(201);
        }

        [HttpDelete("cancelbet")]
        public async Task<IActionResult> CancelBet([FromBody]BetRegisterDto betRegisterDto)
        {
            betRegisterDto.Username = betRegisterDto.Username.ToLower();

            var betToCreate = new Bet
            {
                TeamId = betRegisterDto.TeamId
            };
            var createUser = await _repo.CancelBet(betToCreate, betRegisterDto.Username);

            return StatusCode(201);
        }
    }
}