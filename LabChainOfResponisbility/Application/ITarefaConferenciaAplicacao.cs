using System.Threading.Tasks;
using LabChainOfResponisbility.Domain.DTO;

namespace LabChainOfResponisbility.Application
{
    public interface ITarefaConferenciaAplicacao
    {
        Task CriarTarefa(TarefaDto dto);
    }
}