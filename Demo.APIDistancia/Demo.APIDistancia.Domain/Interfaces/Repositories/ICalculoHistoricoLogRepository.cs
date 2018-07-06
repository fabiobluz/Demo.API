using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Domain.Interfaces.Repositories.Generic;
using System;

namespace Demo.APIDistancia.Domain.Interfaces.Repositories
{
    public interface ICalculoHistoricoLogRepository : IRepositoryGeneric<CalculoHistoricoLog>, IDisposable
    {
        void Adicionar(CalculoHistoricoLog calculoHistoricoLog);
    }
}
