using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Cars.Domain.Entities;
using Cars.Domain.Models;
using Cars.Migrations;
using Cars.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cars.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [SwaggerTag("Methods for working with Users (CRUD)")]
    public class UserController : ControllerBase
    {
        private readonly IService<User, UserModel> _userService;

        public UserController(IService<User, UserModel> userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/user")]
        [SwaggerOperation("CreateUser")]
        [SwaggerResponse(200, "Successful", typeof(UserModel))]
        [SwaggerResponse(400, "Bad request", typeof(ErrorResponseModel))]
        public async Task<IActionResult> CreateUser([FromBody] [Required] UserModel body)
        {
            try
            {
                var result = await _userService.CreateAsync(body);
                return Ok(result);
            }
            catch (Exception e)
            {
                return this.CreateErrorResponse("Failed to create a new user.", e);
            }
        }
    }
}