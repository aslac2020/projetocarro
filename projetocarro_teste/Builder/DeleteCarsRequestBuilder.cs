using Bogus;
using projetoCarro.DTO.DeleteCars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetocarro_teste.Builder
{
    public class DeleteCarsRequestBuilder
    {
        private readonly Faker _faker = new Faker("pt_BR");
        private readonly DeleteCarsRequest _deleteCars;

        public DeleteCarsRequestBuilder(int id)
        {
            _deleteCars = new DeleteCarsRequest();
            _deleteCars.id = id;

        }

        public DeleteCarsRequest Build()
        {
            return _deleteCars;
        }
    }
}
