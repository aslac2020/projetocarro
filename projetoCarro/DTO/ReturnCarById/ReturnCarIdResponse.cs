using projetoCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projetoCarro.DTO.ReturnCarById
{
    public class ReturnCarIdResponse
    {
        public Cars cars { get; set; }
        public string msg { get; set; }
    }
}
