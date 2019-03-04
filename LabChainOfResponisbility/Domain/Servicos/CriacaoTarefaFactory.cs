using LabChainOfResponisbility.Domain.Repositorios;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public class CriacaoTarefaFactory : ICriacaoTarefaFactory
    {
        private readonly IRepositorioConfiguracao _repositorioConfiguracao;
        private readonly ITarefaConferenciaServico _tarefaConferenciaServico;
        private readonly IRegraBlitzServico _regraBlitzServico;
        private readonly IServicoMensageria _servicoMensageria;

        public CriacaoTarefaFactory(IRepositorioConfiguracao repositorioConfiguracao, ITarefaConferenciaServico tarefaConferenciaServico, IRegraBlitzServico regraBlitzServico, IServicoMensageria servicoMensageria)
        {
            _repositorioConfiguracao = repositorioConfiguracao;
            _tarefaConferenciaServico = tarefaConferenciaServico;
            _regraBlitzServico = regraBlitzServico;
            _servicoMensageria = servicoMensageria;
        }

        public ICriacaoTarefaHandler ObterHandler()
        {
            var criacaoTarefaNecessaria = new CriacaoTarefaNecessaria(_repositorioConfiguracao, _tarefaConferenciaServico);
            var verificaBlitzConferencia = new VerificacaoBlitzConferencia(_repositorioConfiguracao, _tarefaConferenciaServico, _regraBlitzServico, _servicoMensageria);
            var conferenciaNaoNecessaria = new ConferenciaNaoNecessaria(_repositorioConfiguracao, _tarefaConferenciaServico, _servicoMensageria);

            criacaoTarefaNecessaria.AtribuirSucessor(verificaBlitzConferencia);
            verificaBlitzConferencia.AtribuirSucessor(conferenciaNaoNecessaria);

            return criacaoTarefaNecessaria;
        }
    }
}
