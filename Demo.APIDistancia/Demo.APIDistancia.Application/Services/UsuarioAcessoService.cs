using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Domain.Interfaces.Repositories;
using Demo.APIDistancia.Application.Interfaces.Services;
using System.Threading.Tasks;
using System;

namespace Demo.APIDistancia.Application.Services
{
    public class UsuarioAcessoService : IUsuarioAcessoService
    {
        private readonly IUsuarioAcessoRepository _iUsuarioAcessoRepository;

        public UsuarioAcessoService(IUsuarioAcessoRepository iUsuarioAcessoRepository)
        {
            _iUsuarioAcessoRepository = iUsuarioAcessoRepository;
        }

        public UsuarioAcesso GetByUsuario(string usuarioAcessoId)
        {
            return _iUsuarioAcessoRepository.GetByUsuario(usuarioAcessoId);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
