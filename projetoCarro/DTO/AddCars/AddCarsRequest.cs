using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.DTO.AddCars
{
    public class AddCarsRequest
    {
        public string Model { get; set; }
        public string Cor { get; set; }
        public int Year { get; set; }
        public string Brands { get; set; }
        public int NumberDoors { get; set; }
        public string TypeRate { get; set; }
    }
}
