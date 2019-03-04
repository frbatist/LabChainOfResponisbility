using LabChainOfResponisbility.Domain.DTO;
using LabChainOfResponisbility.Domain.Repositorios;
using System;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public class CriacaoTarefaNecessaria : CriacaoTarefaHandler
    {
        public CriacaoTarefaNecessaria(IRepositorioConfiguracao repositorioConfiguracao, ITarefaConferenciaServico tarefaConferenciaServico) : base(repositorioConfiguracao, tarefaConferenciaServico)
        {
        }

        protected override async Task<bool> TrataCriacaoTarefa(TarefaDto tarefaDto)
        {
            var configuracao = await ObterConfiguracao(tarefaDto);
            var criacaoNecessaria = VerificaNecessidadeCriarTarefa(tarefaDto, configuracao);
            if (criacaoNecessaria)
            {
                return await _tarefaConferenciaServico.CriarTarefa(tarefaDto);               
            }
            return false;
        }

        private bool VerificaNecessidadeCriarTarefa(TarefaDto tarefaDto, Configuracao configuracao)
        {
            if (configuracao.ConfereTodosOsPalletes)
                Console.WriteLine("Configurado para criar tarefa para todos os paletes.");
            else
                Console.WriteLine("Não configurado para criar tarefa para todos os paletes.");
            return configuracao.ConfereTodosOsPalletes;
        }
    }
}
