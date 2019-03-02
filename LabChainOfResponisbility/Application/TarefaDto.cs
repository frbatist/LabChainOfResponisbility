using System;

namespace LabChainOfResponisbility.Application
{
    public class TarefaDto
    {
        public Guid IdArmazem { get; internal set; }
        public Guid IdPalete { get; internal set; }
        public string Placa { get; internal set; }
        public string DescricaoPalete { get; internal set; }
        public string Zona { get; internal set; }
        public Guid IdEndereco { get; internal set; }
        public string NumeroDocumento { get; internal set; }
    }
}