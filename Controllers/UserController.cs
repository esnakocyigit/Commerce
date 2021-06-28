using System;
using Commerce.Entity;
using Commerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService; 
        public UserController(UserService userService)
        {
            _userService = userService; //dipendes injekşın hığğğvvv
        }

        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetList();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if(string.IsNullOrEmpty(user.Name))
                throw new Exception("İsim zorunlu");

            _userService.Add(user);
            return Ok(user);
        }
    }
}