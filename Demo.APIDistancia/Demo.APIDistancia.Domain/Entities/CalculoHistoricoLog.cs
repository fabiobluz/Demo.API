using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.APIDistancia.Domain.Entities
{
    public class CalculoHistoricoLog
    {
        public int CalculoHistoricoLogId { get; set; }
        public int AmigoId { get; set; }
        public double LatitudeRef { get; set; }
        public double LongitudeRef { get; set; }
        public double LatitudeAmigo { get; set; }
        public double LongitudeAmigo { get; set; }
        public double Distancia { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
