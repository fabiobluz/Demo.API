using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Demo.APIDistancia.Domain.Interfaces.Repositories.Generic;
using Demo.APIDistancia.Repository.Config;


namespace Demo.APIDistancia.Repository.Repository.Generic
{
    public class RepositoryGeneric<TEntity> : IDisposable, IRepositoryGeneric<TEntity>  where TEntity : class
    {

        protected readonly DemoContext Db;
        protected readonly DbSet<TEntity> DbSet;


        public RepositoryGeneric(DemoContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }
    }
}
