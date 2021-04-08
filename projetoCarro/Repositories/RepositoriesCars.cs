using projetoCarro.Borders.Interfaces;
using projetoCarro.Context;
using projetoCarro.DTO.AddCars;
using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.Repositories
{
    public class RepositoriesCars : IRepositoriesCars
    {
        private readonly CarDbContext _carDb;

        public RepositoriesCars(CarDbContext cardb)
        {
            _carDb = cardb;
        }

        public int Add(Cars cars)
        {
            _carDb.cars.Add(cars);
            _carDb.SaveChanges();
            return cars._id;
        }
    }
}
