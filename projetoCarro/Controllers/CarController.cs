using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.AddCars;
using projetoCarro.DTO.DeleteCars;
using projetoCarro.DTO.ReturnCarById;
using projetoCarro.DTO.UpdateCars;
using projetoCarro.Models;
using projetoCarro.UseCase;
using projetoCarro.UserCase;

namespace projetoCarro.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly IRepositoriesCars _repositoriesCars;
        private readonly IAddCarsUseCase _addCarsUseCase;
        private readonly IDeleteCarsUseCase _deleteCarsUseCase;
        private readonly IReturnCarsIdUseCase _returnCarsIdUseCase;
        private readonly IReturnListCarsUseCase _returnListCarsUseCase;
        private readonly IUpdateCarsUseCase _updateCarsUseCase;

        public CarController(ILogger<CarController> logger, 
            IAddCarsUseCase addCarsUseCase, IReturnCarsIdUseCase returnCarsIdUse,
            IDeleteCarsUseCase deleteCarsUseCase, IReturnListCarsUseCase returnListCarsUseCase, IUpdateCarsUseCase updateCarsUseCase)
        {
            _logger = logger;
            _addCarsUseCase = addCarsUseCase;
            _returnCarsIdUseCase = returnCarsIdUse;
            _deleteCarsUseCase = deleteCarsUseCase;
            _returnListCarsUseCase = returnListCarsUseCase;
            _updateCarsUseCase = updateCarsUseCase;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_returnListCarsUseCase.Execute());
        }

        [HttpGet("{id}")]
        public IActionResult GetCarsById(int id)
        {
            if ( id <=0 )
            {
                return BadRequest("Id não encontrado :(");
            }

            var request = new ReturnCarIdRequest();
            request.id = id;
            return Ok(_returnCarsIdUseCase.Execute(request));
        }

        [HttpPost]
        public IActionResult AddGetCars([FromBody] AddCarsRequest cars)
        {
            return Ok(_addCarsUseCase.Execute(cars));
        }

        [HttpPut("{id}")]
        public IActionResult CarUpdate([FromBody] UpdateCarsRequest cars, int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id não encontrado :(");
            }

            return Ok(_updateCarsUseCase.Execute(cars, id));
        }


        [HttpDelete("{id}")]
        public IActionResult CarDelete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id não encontrado :(");
            }

            var request = new DeleteCarsRequest();
            request.id = id;
            return Ok(_deleteCarsUseCase.Execute(request));
        }
    }
}
