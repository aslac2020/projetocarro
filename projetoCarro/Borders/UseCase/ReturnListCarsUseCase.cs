using projetoCarro.DTO.ReturnListCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.UseCase
{
    public interface IReturnListCarsUseCase
    {
        ReturnListCarsResponse Execute(ReturnListCarsRequest request);
    }
}
