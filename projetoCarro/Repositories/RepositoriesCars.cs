using Microsoft.EntityFrameworkCore;
using projetoCarro.Borders.Interfaces;
using projetoCarro.Context;
using projetoCarro.Models;
using System.Collections.Generic;
using System.Linq;

namespace projetoCarro.Repositories
{
    public class RepositoriesCars : IRepositoriesCars
    {
        private readonly CarDbContext _carDb;
        private readonly Cars _cars;

        public RepositoriesCars(CarDbContext cardb)
        {
            _carDb = cardb;
        }

        public int Add(Cars cars)
        {
            _carDb.cars.Add(cars);
            _carDb.SaveChanges();
            return cars.id;
        }

        public void Remove(int id)
        {
            var removeId = _carDb.cars.Where(x => x.id == id).FirstOrDefault();
            _carDb.cars.Remove(removeId);
            _carDb.SaveChanges();
        }

        public Cars GetById(int id)
        {
            foreach (Cars car in _carDb.cars)
            {
                if (car.id == id)
                {
                    return car;
                }
                else
                    continue;
            }

            return null;
        }

        public List<Cars> GetListCars()
        {
            return _carDb.cars.ToList();
        }

        public bool Update(Cars cars)
        {
            var local = _carDb.Set<Cars>().Local.Where(x => x.id == cars.id).FirstOrDefault();
            if (local !=null)
            {
                _carDb.Entry(local).State = EntityState.Detached;
            }
          
            _carDb.cars.Update(cars);
            _carDb.SaveChanges();
            return true;
        }
    }

}



