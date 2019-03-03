using LabChainOfResponisbility.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Repositorios
{
    public interface IRepositorioConfiguracao
    {
        Task<IEnumerable<Configuracao>> ObterTodas();
        Task<Configuracao> ObterPorIdAsync(Guid idArmazem);
    }
}