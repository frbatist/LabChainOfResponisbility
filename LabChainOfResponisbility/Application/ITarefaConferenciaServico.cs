using System.Threading.Tasks;

namespace LabChainOfResponisbility.Application
{
    public interface ITarefaConferenciaServico
    {
        bool VerificaNecessidadeCriarTarefa(TarefaDto dto, object configuracao);
        Task<bool> CriarTarefa(TarefaDto dto);
    }
}