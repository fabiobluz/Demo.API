using Demo.APIDistancia.Domain.Entities;
using Demo.APIDistancia.Application.Interfaces.Services;
using Demo.APIDistancia.Domain.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Demo.APIDistancia.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly IUsuarioAcessoService _usuarioAcessoService;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfig _tokenConfig;

        public LoginController(IUsuarioAcessoService usuarioAcessoService, SigningConfigurations signingConfigurations, TokenConfig tokenConfig)
        {
            _usuarioAcessoService = usuarioAcessoService;
            _signingConfigurations = signingConfigurations;
            _tokenConfig = tokenConfig;

        }


        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]UsuarioAcesso usuario)
        {
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.UsuarioAcessoId))
            {
                var usuarioBase = _usuarioAcessoService.GetByUsuario(usuario.UsuarioAcessoId);
                credenciaisValidas = (usuarioBase != null &&
                    usuario.UsuarioAcessoId == usuarioBase.UsuarioAcessoId &&
                    usuario.ChaveAcesso == usuarioBase.ChaveAcesso);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.UsuarioAcessoId, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.UsuarioAcessoId)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(_tokenConfig.Segundos);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfig.Emissor,
                    Audience = _tokenConfig.Audiencia,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}