using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.Models
{
    public class Cars
    {
        [Key]
        public int _id { get; set; }
        public string Model { get; set; }
        public string Cor { get; set; }
        public int Year { get; set; }
        public string Brands { get; set; }
        public int NumberDoors { get; set; }
        public string TypeRate { get; set; }
    }
}
