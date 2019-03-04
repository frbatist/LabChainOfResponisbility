using LabChainOfResponisbility.Domain.DTO;
using LabChainOfResponisbility.Domain.Repositorios;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public class VerificacaoBlitzConferencia : CriacaoTarefaHandler
    {
        private readonly IRegraBlitzServico _regraBlitzServico;
        private readonly IServicoMensageria _servicoMensageria;

        public VerificacaoBlitzConferencia(IRepositorioConfiguracao repositorioConfiguracao, ITarefaConferenciaServico tarefaConferenciaServico, 
            IRegraBlitzServico regraBlitzServico, IServicoMensageria servicoMensageria) : base(repositorioConfiguracao, tarefaConferenciaServico)
        {
            _regraBlitzServico = regraBlitzServico;
            _servicoMensageria = servicoMensageria;
        }

        protected override async Task<bool> TrataCriacaoTarefa(TarefaDto tarefaDto)
        {
            var configuracao = await ObterConfiguracao(tarefaDto);
            var resultadoBlitz = await _regraBlitzServico.AplicarRegras(tarefaDto, configuracao);
            if (resultadoBlitz.Eleito)
            {
                var criouTarefa = await _tarefaConferenciaServico.CriarTarefa(tarefaDto);
                if (criouTarefa)
                {
                    _servicoMensageria.EnfileirarMensagem(new PaleteEleitoEmBlitzConferncia(tarefaDto.IdPalete, resultadoBlitz.Nome, resultadoBlitz.PercentualSorteio));                    
                }
                return criouTarefa;
            }
            return false;
        }
    }
}
