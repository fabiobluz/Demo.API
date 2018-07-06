using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.APIDistancia.Domain.Entities
{
   public  class Amigo
    {
        public int AmigoId { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
