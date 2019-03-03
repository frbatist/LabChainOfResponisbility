using LabChainOfResponisbility.Domain.DTO;
using System;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public class RegraBlitzServico : IRegraBlitzServico
    {
        public Task<ResultadoBliz> AplicarRegras(TarefaDto dto, Configuracao configuracao)
        {
            var sorteioBlitz = new ResultadoBliz
            {
                Eleito = false,
                Nome = "",
                PercentualSorteio = 0
            };

            if (configuracao.BlitzConferenciaAtiva && dto.Blitz)
            {
                sorteioBlitz.Eleito = true;
                sorteioBlitz.PercentualSorteio = 100;
                Console.WriteLine("Palete eleito para blitz de conferencia.");
            }
            else
            {
                Console.WriteLine("Palete não eleito para blitz de conferencia.");
            }

            return Task.FromResult(sorteioBlitz);
        }
    }
}