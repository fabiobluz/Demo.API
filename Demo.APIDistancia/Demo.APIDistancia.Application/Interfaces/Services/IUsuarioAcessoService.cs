using Demo.APIDistancia.Domain.Entities;
using System;

namespace Demo.APIDistancia.Application.Interfaces.Services
{
    public interface IUsuarioAcessoService : IDisposable
    {
        UsuarioAcesso GetByUsuario(string usuarioAcessoId);

    }
}
