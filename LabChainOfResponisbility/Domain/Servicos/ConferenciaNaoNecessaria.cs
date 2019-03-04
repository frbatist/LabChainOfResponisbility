using LabChainOfResponisbility.Domain.DTO;
using LabChainOfResponisbility.Domain.Repositorios;
using System;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public class ConferenciaNaoNecessaria : CriacaoTarefaHandler
    {
        private readonly IServicoMensageria _servicoMensageria;

        public ConferenciaNaoNecessaria(IRepositorioConfiguracao repositorioConfiguracao, ITarefaConferenciaServico tarefaConferenciaServico, 
            IServicoMensageria servicoMensageria) : base(repositorioConfiguracao, tarefaConferenciaServico)
        {
            _servicoMensageria = servicoMensageria;
        }

        protected override Task<bool> TrataCriacaoTarefa(TarefaDto tarefaDto)
        {
            Console.WriteLine("Não foi criada a tarefa de conferencia, palete ok!");

            _servicoMensageria.EnfileirarMensagem(new PaleteEstaConforme(tarefaDto.IdPalete,
                tarefaDto.IdArmazem,
                tarefaDto.NumeroDocumento,
                tarefaDto.Placa,
                tarefaDto.DescricaoPalete,
                tarefaDto.Zona,
                tarefaDto.IdEndereco));

            return Task.FromResult(false);
        }
    }
}
