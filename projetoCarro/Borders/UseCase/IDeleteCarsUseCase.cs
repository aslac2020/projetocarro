using projetoCarro.DTO.DeleteCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.UseCase
{
    public interface IDeleteCarsUseCase
    {
        DeleteCarsResponse Execute(DeleteCarsRequest request);
    }
}
