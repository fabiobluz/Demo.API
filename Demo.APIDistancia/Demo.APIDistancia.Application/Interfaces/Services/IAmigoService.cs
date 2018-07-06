using Demo.APIDistancia.Application.DTO;
using Demo.APIDistancia.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Demo.APIDistancia.Application.Interfaces.Services
{
    public interface IAmigoService : IDisposable
    {
        List<AmigoDTO> ObterTodos(Amigo self);
    }
}
