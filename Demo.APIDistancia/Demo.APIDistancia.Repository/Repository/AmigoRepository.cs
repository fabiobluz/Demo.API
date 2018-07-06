using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using Demo.APIDistancia.Repository.Config;
using Demo.APIDistancia.Repository.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.APIDistancia.Repository.Repository
{
    public class AmigoRepository : RepositoryGeneric<Amigo>, IAmigoRepository, IDisposable
    {

        public AmigoRepository(DemoContext context)
            : base(context)
        {

        }

        public List<Amigo> ObterTodos()
        {
            return Db.Amigo.ToList();
        }
    }
}
