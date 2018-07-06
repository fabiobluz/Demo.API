using Demo.APIDistancia.Application.DTO;
using Demo.APIDistancia.Application.Interfaces.Services;
using Demo.APIDistancia.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.APIDistancia.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AmigosPertoController : Controller
    {
        private readonly IAmigoService _amigoService;

        public AmigosPertoController(IAmigoService amigoService)
        {
            _amigoService = amigoService;
        }

        [Authorize("Bearer")]
        [HttpGet("LocalizaAmigos/{amigoId}/{latitude}/{longitude}")]
        public object LocalizaAmigos(int amigoId, double latitude, double longitude)
        {
            Amigo self = new Amigo { AmigoId = amigoId, Latitude = latitude, Longitude = longitude };
            List<AmigoDTO> list = _amigoService.ObterTodos(self);
            //var response = new ResponseModelDados<List<AmigoDTO>>
            //{
            //    Sucesso = gridPedidos.Count == 0 ? false : true,
            //    Dados = gridPedidos,
            //    MensagensErro = this.servicoPedido.MensagensErro
            //};
            return Ok(list);
        }
    }
}