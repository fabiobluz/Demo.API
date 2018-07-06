using Demo.APIDistancia.Application.Interfaces.Services;
using Demo.APIDistancia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using Demo.APIDistancia.Application.DTO;

namespace Demo.APIDistancia.Application.Services
{
    public class AmigoService : IAmigoService
    {
        private readonly IAmigoRepository _iAmigoRepository;
        private readonly ICalculoHistoricoLogService _iCalculoHistoricoLogService;

        public AmigoService(IAmigoRepository iAmigoRepository, ICalculoHistoricoLogService iCalculoHistoricoLogService)
        {
            _iAmigoRepository = iAmigoRepository;
            _iCalculoHistoricoLogService = iCalculoHistoricoLogService;
        }

        public List<AmigoDTO> ObterTodos(Amigo self)
        {
            var dados = _iAmigoRepository.ObterTodos().Where(x=> x.AmigoId != self.AmigoId).Select(x => AmigoDTO.ObterAmigoDTO(self, x, _iCalculoHistoricoLogService)).ToList();
            dados = dados.Count > 3 ? dados.OrderBy(x => x.Distancia).Take(3).ToList() : dados;
            return dados;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        
    }
}
