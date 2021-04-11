using projetoCarro.DTO.UpdateCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.UseCase
{
    public interface IUpdateCarsUseCase
    {
        UpdateCarsResponse Execute(UpdateCarsRequest request, int id);
    }
}
