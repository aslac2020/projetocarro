using projetoCarro.Models;
using System.Collections.Generic;

namespace projetoCarro.Services
{
    public interface ICarService
    {
        bool AddCars(Cars carrs);
        List<Cars> GetListCars();
        Cars GetCarsById(int id);
        bool UpdateCars(Cars cars);
        bool DeleteCars(int id);

    }
}
