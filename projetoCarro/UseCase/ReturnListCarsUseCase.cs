using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.ReturnListCars;
using System;

namespace projetoCarro.UseCase
{
    public class ReturnListCarsUseCase : IReturnListCarsUseCase
    {
        private readonly IRepositoriesCars _repositoriesCars;

        public ReturnListCarsUseCase(IRepositoriesCars repositoriesCars)
        {
            _repositoriesCars = repositoriesCars;
        }

        public ReturnListCarsResponse Execute()
        {
            var response = new ReturnListCarsResponse();
 
            try
            {
                var getList = _repositoriesCars.GetListCars();

                if (getList.Count <= 0)
                {
                    response.msg = "Nenhuma lista para ser mostrada :(";
                    return response;
                }

                response.cars =  _repositoriesCars.GetListCars();
                response.msg = "Lista de Carro encontrado com Sucesso";
                return response;

            }
            catch (Exception)
            {

                response.msg = "Problema ao carregar a lista :(";
                return response;
            }
        }
    }
}
