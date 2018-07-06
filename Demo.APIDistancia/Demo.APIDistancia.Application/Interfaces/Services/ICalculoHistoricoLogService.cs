using Demo.APIDistancia.Domain.Entities;
using System;

namespace Demo.APIDistancia.Application.Interfaces.Services
{
    public interface ICalculoHistoricoLogService : IDisposable
    {

        void Adicionar(CalculoHistoricoLog calculoHistoricoLog);
    }
}
