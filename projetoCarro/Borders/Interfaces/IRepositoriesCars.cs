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
        public int Add(Cars cars);
        public bool Update(Cars cars);
        public void Remove(int id);
        public Cars GetById(int id);
        public List<Cars> GetListCars();
    }
}
