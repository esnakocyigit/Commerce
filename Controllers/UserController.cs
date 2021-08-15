using System;
using Commerce.Entity;
using Commerce.Services;
using Commerce.VMs;
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


        [HttpGet("detail/{id}")] // User/detail/1
        public IActionResult Detail(int id) //* HttpGet istekleriDefault olarak [FromQuery] olarak çalışr
        {
            var user = _userService.Detail(id);
            return Ok(user);
        }

        [HttpGet("withparameter")] //* Get "action"ları 1'den fazla ise url unique olmalı.
        public IActionResult DetailWithBody([FromBody] UserDetailRequestVM request) //*[FromBody] isteklerinde model gerekiyore
        {
            var user = _userService.Detail(request.Id);
            return Ok(user);
        }

        // [HttpGet("withparameter")]
        // public IActionResult Detail([FromBody] UserDetailRequestVM request)
        // {
        //     var user = _userService.Detail(request.Id);
        //     return Ok(user);
        // }

        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if(user.Id <= 0)
                throw new System.Exception("Geçersiz Id ürün güncellenemedi");
            if (string.IsNullOrEmpty(user.Name))
                throw new Exception("İsim zorunlu");
            if(user.Name.Length > 20)
                throw new System.Exception("İsim karakter uzunluğu 20 karakteri geçemez");
            if(user.Surname.Length > 20)
                throw new System.Exception("Soyisim karakter uzunluğu 20 karakteri geçemez");
            
            _userService.Update(user);
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
                throw new Exception("Geçersiz Id");
            _userService.Delete(id);
            return Ok();
        }
    }
}