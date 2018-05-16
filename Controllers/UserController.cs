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
    public class UsersController : Controller
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            this._context = context;

        }
        // GET api/users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

        // GET api/users/beracho
        [HttpGet("{username}")]
        public async Task<IActionResult> GetUsers(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);
            return Ok(user);
        }
    }
}