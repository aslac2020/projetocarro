using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projetoCarro.DTO.AddCars;
using projetoCarro.Models;
using projetoCarro.Services;
using projetoCarro.UserCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarService _cars;
        private readonly IAddCarsUseCase _addCarsUseCase;

        public CarController(ILogger<CarController> logger, ICarService cars, IAddCarsUseCase addCarsUseCase)
        {
            _logger = logger;
            _cars = cars;
            _addCarsUseCase = addCarsUseCase;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_cars.GetListCars());
        }

        [HttpGet("{id}")]
        public IActionResult GetCarsById(int id)
        {
            return Ok(_cars.GetCarsById(id));
        }

        [HttpPost]
        public IActionResult AddGetCars([FromBody] AddCarsRequest cars)
        {
            return Ok(_addCarsUseCase.Execute(cars));
        }

        [HttpPut]
        public IActionResult CarUpdate([FromBody] Cars cars)
        {
            return Ok(_cars.UpdateCars(cars));
        }


        [HttpDelete("{id}")]
        public IActionResult CarDelete(int id)
        {
            return Ok(_cars.DeleteCars(id));
        }
    }
}
