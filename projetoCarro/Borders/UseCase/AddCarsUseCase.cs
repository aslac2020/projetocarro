using projetoCarro.DTO.AddCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.UserCase
{
    public interface IAddCarsUseCase
    {
        AddCarsResponse Execute(AddCarsRequest request);
    }
}
