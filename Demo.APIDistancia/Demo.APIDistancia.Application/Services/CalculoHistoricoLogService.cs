using Demo.APIDistancia.Application.Interfaces.Services;
using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.APIDistancia.Application.Services
{
    public class CalculoHistoricoLogService : ICalculoHistoricoLogService
    {
        private readonly ICalculoHistoricoLogRepository _iCalculoHistoricoLogRepository;

        public CalculoHistoricoLogService(ICalculoHistoricoLogRepository iCalculoHistoricoLogRepository)
        {
            _iCalculoHistoricoLogRepository = iCalculoHistoricoLogRepository;
        }

        public void Adicionar(CalculoHistoricoLog calculoHistoricoLog)
        {
            _iCalculoHistoricoLogRepository.Adicionar(calculoHistoricoLog);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
