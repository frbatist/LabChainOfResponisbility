using System;

namespace LabChainOfResponisbility.Domain.DTO
{
    public class Configuracao
    {
        public Guid IdArmazem { get; set; }
        public bool ConfereTodosOsPalletes { get; set; }
        public bool BlitzConferenciaAtiva { get; set; }
    }
}
