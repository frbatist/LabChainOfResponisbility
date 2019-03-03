using LabChainOfResponisbility.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Repositorios
{
    public class RepositorioConfiguracao : IRepositorioConfiguracao
    {
        private static IEnumerable<Configuracao> _configuracoes = new List<Configuracao>
        {
            new Configuracao
            {
                IdArmazem = Guid.NewGuid(),
                BlitzConferenciaAtiva = false,
                ConfereTodosOsPalletes = true
            },
            new Configuracao
            {
                IdArmazem = Guid.NewGuid(),
                BlitzConferenciaAtiva = true,
                ConfereTodosOsPalletes = false
            },
            new Configuracao
            {
                IdArmazem = Guid.NewGuid(),
                BlitzConferenciaAtiva = false,
                ConfereTodosOsPalletes = false
            }
        };

        public Task<Configuracao> ObterPorIdAsync(Guid idArmazem)
        {
            return Task.FromResult(_configuracoes.FirstOrDefault(d => d.IdArmazem == idArmazem));
        }

        public Task<IEnumerable<Configuracao>> ObterTodas()
        {
            return Task.FromResult(_configuracoes);
        }
    }
}