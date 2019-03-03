using LabChainOfResponisbility.Domain.DTO;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public interface IRegraBlitzServico
    {
        Task<ResultadoBliz> AplicarRegras(TarefaDto dto, Configuracao configuracao);
    }
}