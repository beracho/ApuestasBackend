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
    public class TeamsController : Controller
    {
        private readonly DataContext _context;
        public TeamsController(DataContext context)
        {
            this._context = context;

        }
        // GET api/teams
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _context.Teams.ToListAsync();
            return Ok(teams);
        }

        // GET api/teams/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeams(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.id == id);
            return Ok(team);
        }

        // POST api/teams
        // [HttpPost]
        // public async Task<IActionResult> PostTeams(string team)
        // {
        //     await _context.Teams.LoadAsync(team);
        //     return Ok(team);
        // }

        // PUT api/teams/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string team)
        {
        }

        // DELETE api/teams/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
