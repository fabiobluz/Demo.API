using Demo.APIDistancia.Application.Interfaces.Services;
using Demo.APIDistancia.Domain.Entities;
using System;

namespace Demo.APIDistancia.Application.DTO
{
    public class AmigoDTO
    {
        public int AmigoId { get; set; }
        public string Nome { get; set; }
        public double Distancia { get; set; }

        public static AmigoDTO ObterAmigoDTO(Amigo self, Amigo amigo, ICalculoHistoricoLogService iCalculoHistoricoLogService)
        {
            double distanciaCalc = Math.Sqrt((Math.Pow((amigo.Latitude - self.Latitude), 2) + Math.Pow((amigo.Longitude - self.Longitude), 2)));

            AmigoDTO  amigoDTO =  new AmigoDTO
            {
                AmigoId =  amigo.AmigoId,
                Nome = amigo.Nome,
                Distancia = distanciaCalc
            };

            iCalculoHistoricoLogService.Adicionar(
                new CalculoHistoricoLog
                {
                    AmigoId = amigo.AmigoId,
                    LatitudeRef = self.Latitude,
                    LongitudeRef = self.Longitude,
                    LatitudeAmigo = amigo.Latitude,
                    LongitudeAmigo = amigo.Longitude,
                    Distancia = distanciaCalc,
                    DataCriacao = DateTime.Now
                });
            return amigoDTO;
        }

        
    }
}
