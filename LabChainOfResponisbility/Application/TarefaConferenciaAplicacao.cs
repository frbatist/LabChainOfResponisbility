using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Application
{
    public class TarefaConferenciaAplicacao
    {
        private readonly IRepositorioConfiguracao _repositorioConfiguracao;
        private readonly ITarefaConferenciaServico _tarefaConferenciaServico;
        private readonly IRegraBlitzServico _regraBlitzServico;
        private readonly IServicoMensageria _servicoMensageria;

        public TarefaConferenciaAplicacao(IRepositorioConfiguracao repositorioConfiguracao, ITarefaConferenciaServico tarefaConferenciaServico, IRegraBlitzServico regraBlitzServico, IServicoMensageria servicoMensageria)
        {
            _repositorioConfiguracao = repositorioConfiguracao;
            _tarefaConferenciaServico = tarefaConferenciaServico;
            _regraBlitzServico = regraBlitzServico;
            _servicoMensageria = servicoMensageria;
        }

        public async Task CriarTarefa(TarefaDto dto)
        {            
            var configuracao = await _repositorioConfiguracao.ObterPorIdAsync(dto.IdArmazem);
            
            bool criacaoNecessaria = _tarefaConferenciaServico.VerificaNecessidadeCriarTarefa(dto, configuracao);
            if (criacaoNecessaria)
            {
                await _tarefaConferenciaServico.CriarTarefa(dto);
                await Commit();
                return;
            }

            var resultadoBlitz = await _regraBlitzServico.AplicarRegras(dto, configuracao);
            if (resultadoBlitz.Eleito)
            {
                var tarefaCriada = await _tarefaConferenciaServico.CriarTarefa(dto);
                if (tarefaCriada)
                {
                    _servicoMensageria.EnfileirarMensagem(new PaleteEleitoEmBlitzConferncia(dto.IdPalete, resultadoBlitz.Nome, resultadoBlitz.PercentualSorteio));

                    await Commit();
                    return;
                }
            }

            _servicoMensageria.EnfileirarMensagem(new PaleteEstaConforme(dto.IdPalete,
                dto.IdArmazem,
                dto.NumeroDocumento,
                dto.Placa,
                dto.DescricaoPalete,
                dto.Zona,
                dto.IdEndereco));

            await Commit();
            return;
           
        }

        private Task Commit()
        {
            throw new NotImplementedException();
        }
    }
}
