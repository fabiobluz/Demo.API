using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Repository.Repository.Generic;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using Demo.APIDistancia.Repository.Config;
using System.Linq;

namespace Demo.APIDistancia.Repository.Repository
{
    public class CalculoHistoricoLogRepository : RepositoryGeneric<CalculoHistoricoLog>, ICalculoHistoricoLogRepository
    {
        public CalculoHistoricoLogRepository(DemoContext context)
            : base(context)
        {

        }

        public void Adicionar(CalculoHistoricoLog calculoHistoricoLog)
        {
            Db.CalculoHistoricoLog.Add(calculoHistoricoLog);
            Db.SaveChanges();
        }
    }

}
