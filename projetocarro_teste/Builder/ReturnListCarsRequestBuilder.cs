using Bogus;
using projetoCarro.DTO.ReturnListCars;
using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetocarro_teste.Builder
{
   public class ReturnListCarsRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly ReturnListCarsResponse _returnListCars;
        private readonly ReturnListCarsRequest _returnList;
        public ReturnListCarsRequestBuilder()
        {
            _returnList = new ReturnListCarsRequest();
            _returnList.Model = _faker.Random.String(10);
            _returnList.Cor = _faker.Random.String(10);
            _returnList.Brands = _faker.Random.String(10);
            _returnList.Year = _faker.Random.Int(4);
            _returnList.NumberDoors = _faker.Random.Int(4);
            _returnList.TypeRate = _faker.Random.String(8);

        }

        public ReturnListCarsRequest Build()
        {
            return _returnList;
        }
    }
}
