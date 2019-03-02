using System;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Application
{
    public interface IRepositorioConfiguracao
    {
        Task<object> ObterPorIdAsync(Guid idArmazem);
    }
}