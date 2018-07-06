using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.APIDistancia.Domain.Interfaces.Repositories.Generic
{
    public interface IRepositoryGeneric<TEntity> : IDisposable where TEntity : class
    {
        TEntity GetById(int id);

    }
}
