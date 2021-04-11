using projetoCarro.Borders.Adapter;
using projetoCarro.Borders.Interfaces;
using projetoCarro.DTO.DeleteCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.UseCase
{
  
    public class DeleteCarsUseCase : IDeleteCarsUseCase
    {
        private readonly IRepositoriesCars _repositoriesCars;

        public DeleteCarsUseCase(IRepositoriesCars repositoriesCars)
        {
            _repositoriesCars = repositoriesCars;

        }

        public DeleteCarsResponse Execute(DeleteCarsRequest request)
        {
            var response = new DeleteCarsResponse();
            var getById = _repositoriesCars.GetById(request.id);

            try
            {
                if (request.id <= 0 || getById == null)
                {
                    response.msg = "Não encontrado o id :( ";
                    return response;
                }

                _repositoriesCars.Remove(request.id);
                response.msg = "Deletado com Sucesso";
                return response;

            }
            catch (Exception)
            {

                response.msg = "Falha ao deletar o carro :(";
                return response;
            }
        }
    }
}
