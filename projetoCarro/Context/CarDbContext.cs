using Microsoft.EntityFrameworkCore;
using projetoCarro.Models;

namespace projetoCarro.Context
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        {

        }

        public DbSet<Cars> cars { get; set; }


    }
}

