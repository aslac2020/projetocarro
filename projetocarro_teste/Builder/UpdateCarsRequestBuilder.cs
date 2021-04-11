using Bogus;
using projetoCarro.DTO.UpdateCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetocarro_teste.Builder
{
    public class UpdateCarsRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly UpdateCarsRequest _updateCars;
        public UpdateCarsRequestBuilder(int id)
        {
            _updateCars = new UpdateCarsRequest();
            _updateCars.id = id;
            _updateCars.Model = _faker.Random.String(10);
            _updateCars.Cor = _faker.Random.String(5);
            _updateCars.Brands = _faker.Random.String(10);
            _updateCars.Year = _faker.Random.Int(4);
            _updateCars.NumberDoors = _faker.Random.Int(1);
            _updateCars.TypeRate = _faker.Random.String(10);
        }

        public UpdateCarsRequest Build()
        {
            return _updateCars;
        }
    }
}
