using Bogus;
using projetoCarro.DTO.ReturnCarById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetocarro_teste.Builder
{
    public class ReturnCarsIdRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly ReturnCarIdRequest _returnCars;

        public ReturnCarsIdRequestBuilder(int id)
        {
            _returnCars = new ReturnCarIdRequest();
            _returnCars.id = id;
        }

        public ReturnCarIdRequest Build()
        {
            return _returnCars;
        }
    }
}
