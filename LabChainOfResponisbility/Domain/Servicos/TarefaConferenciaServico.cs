using LabChainOfResponisbility.Domain.DTO;
using System;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Domain.Servicos
{
    public class TarefaConferenciaServico : ITarefaConferenciaServico
    {
        public bool VerificaNecessidadeCriarTarefa(TarefaDto dto, Configuracao configuracao)
        {
            if(configuracao.ConfereTodosOsPalletes)
                Console.WriteLine("Configurado para criar tarefa para todos os paletes.");
            else
                Console.WriteLine("Não configurado para criar tarefa para todos os paletes.");
            return configuracao.ConfereTodosOsPalletes;
        }

        public Task<bool> CriarTarefa(TarefaDto dto)
        {
            Console.WriteLine($"Criando tarefa de conferencia: {dto}");
            return Task.FromResult(true);
        }
    }
}