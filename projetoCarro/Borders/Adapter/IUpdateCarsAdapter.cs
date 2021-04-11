using projetoCarro.DTO.UpdateCars;
using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.Borders.Adapter
{
    public interface IUpdateCarsAdapter 
    {
        public Cars converterRequestCars(UpdateCarsRequest request);
    }
}
