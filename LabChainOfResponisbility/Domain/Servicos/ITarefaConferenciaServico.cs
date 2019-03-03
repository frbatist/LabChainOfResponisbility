using LabChainOfResponisbility.Domain.DTO;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public interface ITarefaConferenciaServico
    {
        bool VerificaNecessidadeCriarTarefa(TarefaDto dto, Configuracao configuracao);
        Task<bool> CriarTarefa(TarefaDto dto);
    }
}