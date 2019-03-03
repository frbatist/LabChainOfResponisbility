using LabChainOfResponisbility.Application;
using LabChainOfResponisbility.Domain.DTO;
using LabChainOfResponisbility.Domain.Repositorios;
using LabChainOfResponisbility.Domain.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabChainOfResponisbility
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorioConfiguracao = new RepositorioConfiguracao();
            var tarefaConferenciaServico = new TarefaConferenciaServico();
            var regraBlitzServico = new RegraBlitzServico();
            var servicoMensageria = new ServicoMensageria();
            var tarefaConferenciaAplicacao = new TarefaConferenciaAplicacao(repositorioConfiguracao, tarefaConferenciaServico, regraBlitzServico, servicoMensageria);

            var configuracoes = repositorioConfiguracao.ObterTodas().Result;

            Console.WriteLine("Método antigo, criando tarefa: ");
            AntigoGerandoConferencia(configuracoes, tarefaConferenciaAplicacao).Wait();
            Console.ReadKey();
            Console.WriteLine("Método antigo, blitz: ");
            AntigoGerandoConferenciaBlitz(configuracoes, tarefaConferenciaAplicacao).Wait();
            Console.ReadKey();
            Console.WriteLine("Método antigo, palete ok: ");
            AntigoPaleteOk(configuracoes, tarefaConferenciaAplicacao).Wait();

            Console.ReadKey();
        }

        private static async Task AntigoPaleteOk(IEnumerable<Configuracao> configuracoes, TarefaConferenciaAplicacao tarefaConferenciaAplicacao)
        {
            var configuracao = configuracoes.FirstOrDefault(d => !d.ConfereTodosOsPalletes && !d.BlitzConferenciaAtiva);
            var dto = new TarefaDto
            {
                IdArmazem = configuracao.IdArmazem,
                IdEndereco = Guid.NewGuid(),
                IdPalete = Guid.NewGuid(),
                NumeroDocumento = "123456",
                DescricaoPalete = "PL001",
                Placa = "ASD123",
                Zona = "A",
                Blitz = false
            };
            await tarefaConferenciaAplicacao.CriarTarefa(dto);
        }

        private static async Task AntigoGerandoConferencia(IEnumerable<Configuracao> configuracoes, TarefaConferenciaAplicacao tarefaConferenciaAplicacao)
        {
            var configuracao = configuracoes.FirstOrDefault(d => d.ConfereTodosOsPalletes && !d.BlitzConferenciaAtiva);
            var dto = new TarefaDto
            {
                IdArmazem = configuracao.IdArmazem,
                IdEndereco = Guid.NewGuid(),
                IdPalete = Guid.NewGuid(),
                NumeroDocumento = "123456",
                DescricaoPalete = "PL001",
                Placa = "ASD123",
                Zona = "A",
                Blitz = false
            };
            await tarefaConferenciaAplicacao.CriarTarefa(dto);
        }

        private static async Task AntigoGerandoConferenciaBlitz(IEnumerable<Configuracao> configuracoes, TarefaConferenciaAplicacao tarefaConferenciaAplicacao)
        {
            var configuracao = configuracoes.FirstOrDefault(d => !d.ConfereTodosOsPalletes && d.BlitzConferenciaAtiva);
            var dto = new TarefaDto
            {
                IdArmazem = configuracao.IdArmazem,
                IdEndereco = Guid.NewGuid(),
                IdPalete = Guid.NewGuid(),
                NumeroDocumento = "123456",
                DescricaoPalete = "PL001",
                Placa = "ASD123",
                Zona = "A",
                Blitz = true
            };
            await tarefaConferenciaAplicacao.CriarTarefa(dto);
        }
    }
}
