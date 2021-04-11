using projetoCarro.Borders.Adapter;
using projetoCarro.DTO.UpdateCars;
using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.Adapter
{
    public class UpdateCarsAdapter : IUpdateCarsAdapter
    {
        public Cars converterRequestCars(UpdateCarsRequest request)
        {
            var newCars = new Cars();
            newCars.Model = request.Model;
            newCars.Cor = request.Cor;
            newCars.Year = request.Year;
            newCars.Brands = request.Brands;
            newCars.NumberDoors = request.NumberDoors;
            newCars.TypeRate = request.TypeRate;

            return newCars;
        }
    }
}
