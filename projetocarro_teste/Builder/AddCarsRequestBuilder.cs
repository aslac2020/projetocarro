using Bogus;
using projetoCarro.DTO.AddCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetocarro_teste.Builder
{
    public class AddCarsRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly AddCarsRequest _addCars;
        public AddCarsRequestBuilder()
        {
            _addCars = new AddCarsRequest();
            _addCars.Model = _faker.Random.String(10);
            _addCars.Brands = _faker.Random.String(10);
        }

        public AddCarsRequestBuilder withModelLength(int leght)
        {
            _addCars.Model = _faker.Random.String(leght);
            return this;
        }

        public AddCarsRequest Build()
        {
            return _addCars;
        }
    }
}
