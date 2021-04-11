using projetoCarro.Borders.Adapter;
using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.AddCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.UserCase
{
    public class AddCarsUseCase : IAddCarsUseCase
    {
        private readonly IRepositoriesCars _repositoriesCars;
        private readonly IAddCarsAdapter _addCarsAdapter;

        public AddCarsUseCase(IRepositoriesCars repositoriesCars, IAddCarsAdapter addCarsAdapter)
        {
            _repositoriesCars = repositoriesCars;
            _addCarsAdapter = addCarsAdapter;

        }

        public AddCarsResponse Execute(AddCarsRequest request)
        {
            var response = new AddCarsResponse();

            try
            {
                if (request.Model.Length < 1)
                {
                    response.msg = "Erro ao adicionar o carro";
                    return response;
                }
               
                var addCar = _addCarsAdapter.converterRequestCars(request);
                _repositoriesCars.Add(addCar);
                response.msg = "Adicionado com Sucesso";
                response.id = addCar.id;
                return response;

            }
            catch (Exception)
            {

                response.msg = "Erro ao adicionar o carro";
                return response;
            }
            
        }
    }
}
