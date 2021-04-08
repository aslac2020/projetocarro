using projetoCarro.DTO.AddCars;
using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.Borders.Interfaces
{
    public interface IRepositoriesCars
    {
        //public void Add(Cars cars);
        public int Add(Cars cars);
    }
}
