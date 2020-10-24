using AlquilarMVP.API.Models;
using AlquilarMVP.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AlquilarMVP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _userService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User User)
        {
            _userService.Create(User);

            return CreatedAtRoute("GetUser", new { id = User.Id.ToString() }, User);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User UserIn)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.Update(id, UserIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var User = _userService.Get(id);

            if (User == null)
            {
                return NotFound();
            }

            _userService.Remove(User.Id);

            return NoContent();
        }

        [HttpPost("login")]
        public ActionResult<User> Login(User User)
        {
            var user = _userService.Get(User.Name, User.Pass);

            if (user == null)
            {
                return Unauthorized("Combinacion de usuario y contraseña no valido");
            }

            return Ok("Bienvenido");
        }



    }
}
