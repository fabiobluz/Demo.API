using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Domain.Interfaces.Repositories.Generic;
using System;
using System.Collections.Generic;

namespace Demo.APIDistancia.Domain.Interfaces.Repositories
{
    public interface IAmigoRepository : IRepositoryGeneric<Amigo>,  IDisposable
    {
        List<Amigo> ObterTodos();
        
    }
}
