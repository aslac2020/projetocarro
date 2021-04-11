using projetoCarro.Borders.Interfaces;
using projetoCarro.Context;
using projetoCarro.DTO.ReturnCarById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.UseCase
{
    public class ReturnCarsIdUseCase : IReturnCarsIdUseCase
    {
        private readonly IRepositoriesCars _repositoriesCars;

        public ReturnCarsIdUseCase(IRepositoriesCars repositoriesCars)
        {
            _repositoriesCars = repositoriesCars;
        }
        public ReturnCarIdResponse Execute(ReturnCarIdRequest request)
        {
            var response = new ReturnCarIdResponse();
            var getById = _repositoriesCars.GetById(request.id);

            try
            {
                if (request.id <= 0 || getById == null)
                {
                    response.msg = "Id não encontrado :(";
                    return response;
                }

                response.cars = _repositoriesCars.GetById(request.id);
                response.msg = "Carro encontrado com Sucesso ";
                return response;

            }
            catch (Exception)
            {

                response.msg = "Falha ao procurar o carro :( ";
                return response;
            }
        }
    }
}
