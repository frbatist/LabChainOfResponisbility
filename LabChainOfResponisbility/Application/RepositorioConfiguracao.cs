using System;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Application
{
    public class RepositorioConfiguracao : IRepositorioConfiguracao
    {
        public Task<Object> ObterPorIdAsync(Guid idArmazem)
        {
            throw new NotImplementedException();
        }
    }
}