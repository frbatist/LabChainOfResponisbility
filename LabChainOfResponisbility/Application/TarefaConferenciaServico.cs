using System;
using System.Threading.Tasks;

namespace LabChainOfResponisbility.Application
{
    public class TarefaConferenciaServico : ITarefaConferenciaServico
    {
        public bool VerificaNecessidadeCriarTarefa(TarefaDto dto, object configuracao)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CriarTarefa(TarefaDto dto)
        {
            throw new NotImplementedException();
        }
    }
}