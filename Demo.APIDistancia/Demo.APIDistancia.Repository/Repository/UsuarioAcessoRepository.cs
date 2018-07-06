using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Repository.Repository.Generic;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using Demo.APIDistancia.Repository.Config;
using System.Linq;
using System;

namespace Demo.APIDistancia.Repository.Repository
{
    public class UsuarioAcessoRepository : RepositoryGeneric<UsuarioAcesso>, IUsuarioAcessoRepository
    {
        public UsuarioAcessoRepository(DemoContext context)
            : base(context)
        {

        }

        public UsuarioAcesso GetByUsuario(string usuarioAcessoId)
        {
            return Db.UsuarioAcesso.FirstOrDefault(x => x.UsuarioAcessoId == usuarioAcessoId);
        }
    }
}
