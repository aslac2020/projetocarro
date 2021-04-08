using projetoCarro.DTO.AddCars;
using projetoCarro.Models;

namespace projetoCarro.Borders.Adapter
{
    public interface IAddCarsAdapter
    {
        public Cars converterRequestCars(AddCarsRequest request);
    }
}
