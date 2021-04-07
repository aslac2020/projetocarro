using Microsoft.EntityFrameworkCore;
using projetoCarro.Context;
using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.Services
{
    public class CarService : ICarService
    {
        private readonly CarDbContext _carDbContext;

        public CarService(CarDbContext carDb)
        {
            _carDbContext = carDb;
        }

        public bool AddCars(Cars cars)
        {
            _carDbContext.cars.Add(cars);
            _carDbContext.SaveChanges();
            return true;

        }

        public bool DeleteCars(int id)
        {
            var deleteCars = _carDbContext.cars.Where(x => x._id == id).FirstOrDefault();
            _carDbContext.cars.Remove(deleteCars);
            _carDbContext.SaveChanges();
            return true;
        }

        public Cars GetCarsById(int id)
        {
           return _carDbContext.cars.Where(x => x._id == id).FirstOrDefault();

        }

        public List<Cars> GetListCars()
        {
            return _carDbContext.cars.ToList();
        }

        public bool UpdateCars(Cars cars)
        {
            _carDbContext.cars.Attach(cars);
            _carDbContext.Entry(cars).State = EntityState.Modified;
            return true;
        }
    }
}
