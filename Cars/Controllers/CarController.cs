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
    [SwaggerTag("Methods for working with Cars (CRUD)")]
    public class CarController : ControllerBase
    {
        private readonly IService<Car, CarModel> _carService;

        public CarController(IService<Car, CarModel> carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("/car")]
        [SwaggerOperation("GetAllCars")]
        [SwaggerResponse(200, "Successful", typeof(CarModel))]
        [SwaggerResponse(400, "Bad request", typeof(ErrorResponseModel))]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                var result = await _carService.GetAllAsync();
                return Ok(result);
            }
            catch (Exception e)
            {
                return this.CreateErrorResponse("Failed get all cars.", e);
            }
        }

        [HttpPost]
        [Route("/car")]
        [SwaggerOperation("CreateCar")]
        [SwaggerResponse(200, "Successful", typeof(CarModel))]
        [SwaggerResponse(400, "Bad request", typeof(ErrorResponseModel))]
        public async Task<IActionResult> CreateCar([FromBody] [Required] CarModel body)
        {
            try
            {
                var result = await _carService.CreateAsync(body);
                return Ok(result);
            }
            catch (Exception e)
            {
                return this.CreateErrorResponse("Failed to create a new car.", e);
            }
        }

        [HttpPut]
        [Route("/car")]
        [SwaggerOperation("UpdateCar")]
        [SwaggerResponse(200, "Successful", typeof(CarModel))]
        [SwaggerResponse(400, "Bad request", typeof(ErrorResponseModel))]
        public async Task<IActionResult> UpdateCar([FromBody] [Required] CarModel body)
        {
            try
            {
                var result = await _carService.UpdateAsync(body);
                return Ok(result);
            }
            catch (Exception e)
            {
                return this.CreateErrorResponse("Failed to update the car.", e);
            }
        }

        [HttpDelete]
        [Route("/car/{carId}")]
        [SwaggerOperation("DeleteCar")]
        [SwaggerResponse(200, "Successful", typeof(CarModel))]
        [SwaggerResponse(400, "Bad request", typeof(ErrorResponseModel))]
        public async Task<IActionResult> DeleteCar([FromRoute] [Required] long carId)
        {
            try
            {
                await _carService.DeleteAsync(carId);
                return Ok();
            }
            catch (Exception e)
            {
                return this.CreateErrorResponse("Failed to delete the car.", e);
            }
        }
    }
}