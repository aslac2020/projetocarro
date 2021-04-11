using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.DTO.ReturnListCars
{
    public class ReturnListCarsResponse
    {
        public List<Cars> cars { get; set; }
        public string msg { get; set; }
    }
}
