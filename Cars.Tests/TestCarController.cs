using System.Collections.Generic;
using System.Threading.Tasks;
using Cars.Controllers;
using Cars.Domain.Entities;
using Cars.Domain.Enums;
using Cars.Domain.Models;
using Cars.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Cars.Tests
{
    public class TestCarController
    {
        [Fact]
        public async Task GetALlCars_ShouldReturnAllCars()
        {
            var mock = new Mock<IService<Car, CarModel>>();
            mock.Setup(p => p.GetAllAsync()).ReturnsAsync(new List<CarModel>
            {
                new()
                {
                    Id = 1,
                    Make = MakeEnum.Skoda,
                    Model = "Octavia",
                    PlateNumber = "AA123BB"
                },
                new()
                {
                    Id = 2,
                    Make = MakeEnum.Skoda,
                    Model = "Fabia",
                    PlateNumber = "CC123BB"
                },
                new()
                {
                    Id = 3,
                    Make = MakeEnum.Skoda,
                    Model = "Kodiaq",
                    PlateNumber = "DD123BB"
                }
            });
            var controller = new CarController(mock.Object);

            var actionResult = await controller.GetAllCars();

            var okResult = Assert.IsType<OkObjectResult>(actionResult).Value;
            var result = Assert.IsAssignableFrom<ICollection<CarModel>>(okResult);
            Assert.Equal(3, result.Count);
            Assert.True(true);
        }
    }
}