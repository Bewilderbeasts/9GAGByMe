using FunnyImages.Commands;
using FunnyImages.Commands.User;
using FunnyImages.Domain;
using FunnyImages.Repositories;
using FunnyImages.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FunnyImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ICommandDispatcher commandDispatcher
        ) : base(commandDispatcher)
        {
            _userService = userService;
        }
       

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllAsync();

            return Json(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{email}")]
        public async Task<IActionResult> Get(string email)
        {
            var user = await _userService.GetAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            await DispatchAsync(command);

            return Created($"users/{command.Email}", null);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user )
        {
            ///
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //
        }

        
    }
}
