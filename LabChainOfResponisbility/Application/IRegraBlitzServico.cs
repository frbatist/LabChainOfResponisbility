using System.Threading.Tasks;

namespace LabChainOfResponisbility.Application
{
    public interface IRegraBlitzServico
    {
        Task<ResultadoBliz> AplicarRegras(TarefaDto dto, object configuracao);
    }
}