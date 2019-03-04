using LabChainOfResponisbility.Domain.DTO;
using LabChainOfResponisbility.Domain.Repositorios;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public interface ICriacaoTarefaHandler
    {
        Task Handle(TarefaDto tarefaDto);
        void AtribuirSucessor(ICriacaoTarefaHandler sucessor);
    }

    public abstract class CriacaoTarefaHandler : ICriacaoTarefaHandler
    {
        protected ICriacaoTarefaHandler _sucessor;
        protected readonly IRepositorioConfiguracao _repositorioConfiguracao;
        protected readonly ITarefaConferenciaServico _tarefaConferenciaServico;

        protected CriacaoTarefaHandler(IRepositorioConfiguracao repositorioConfiguracao, ITarefaConferenciaServico tarefaConferenciaServico)
        {
            _repositorioConfiguracao = repositorioConfiguracao;
            _tarefaConferenciaServico = tarefaConferenciaServico;
        }

        public async Task Handle(TarefaDto tarefaDto)
        {
            var criouTarefa = await TrataCriacaoTarefa(tarefaDto);

            if (criouTarefa)
                return;

            if (_sucessor != null)
            {
                await _sucessor.Handle(tarefaDto);
            }
        }

        public void AtribuirSucessor(ICriacaoTarefaHandler successor)
        {
            _sucessor = successor;
        }

        protected abstract Task<bool> TrataCriacaoTarefa(TarefaDto tarefaDto);

        protected async Task<Configuracao> ObterConfiguracao(TarefaDto tarefaDto)
        {
            return await _repositorioConfiguracao.ObterPorIdAsync(tarefaDto.IdArmazem);
        }
    }
}
